
using AutoMapper;
using DataAccessLayer.DTOs;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using ProgramAPI.CustomException;
using ServiceLayer.ServiceInterface;

namespace ProgramAPI.Controllers;

[ApiController]
[Route("api/programs")]
[ServiceFilter(typeof(CustomExceptionFilterAttribute))]
public class ProgramController : ControllerBase
{
    private readonly IProgramService _programService;
    private readonly IMapper _mapper;

    public ProgramController(IProgramService programService, IMapper mapper)
    {
        _programService = programService;
        _mapper = mapper;
    }

    [HttpGet("GetPrograms")]
    public async Task<IActionResult> GetProgramsAsync()
    {
        var programs = await _programService.GetProgramsAsync();
        return Ok(programs);
    }

    [HttpGet("GetProgramById/{id}")]
    public async Task<IActionResult> GetProgramAsync(string id)
    {
        var program = await _programService.GetProgramAsync(id);
        return Ok(program);
    }
    
    
    [HttpPost("CreateProgram")]
    public async Task<IActionResult> CreateProgramAsync([FromBody] ProgramDto programDto)
    {
        try
        {
            // Generate a unique id on the server-side
            string uniqueId = Guid.NewGuid().ToString();
        
            // Set the 'id' property in the programDto
            programDto.Id = uniqueId;

            // Call the service method to create the program
            var createdProgram = await _programService.CreateProgramAsync(programDto);

            // Return a successful response
            return Ok(createdProgram);
        }
        catch (Exception ex)
        {
            // Handle exceptions and return an appropriate error response
            return StatusCode(500, ex.Message);
        }
    }







    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProgramAsync(string id)
    {
        var result = await _programService.DeleteProgramAsync(id);
        if (result)
        {
            return NoContent();
        }
        return NotFound();
    }
}