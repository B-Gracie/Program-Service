using Microsoft.AspNetCore.Mvc;
using ProgramAPI.CustomException;
using ServiceLayer.ServiceInterface;

namespace ProgramAPI.Controllers;

[ApiController]
[Route("api/program-previews")]
[ServiceFilter(typeof(CustomExceptionFilterAttribute))]
public class ProgramPreviewController : ControllerBase
{
    private readonly IProgramPreviewService _programPreviewService;

    public ProgramPreviewController(IProgramPreviewService programPreviewService)
    {
        _programPreviewService = programPreviewService;
    }

    [HttpGet("{programId}")]
    public async Task<IActionResult> GetProgramPreviewAsync(string programId)
    {
        try
        {
            var programPreview = await _programPreviewService.GetProgramPreviewAsync(programId);
            if (programPreview == null)
            {
                return NotFound();
            }
            return Ok(programPreview);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
