using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using ProgramAPI.CustomException;
using ServiceLayer.ServiceInterface;

namespace ProgramAPI.Controllers;

[ApiController]
[Route("api/workflows")]
[ServiceFilter(typeof(CustomExceptionFilterAttribute))]
public class WorkFlowController : ControllerBase
{
    private readonly IWorkFlowService _workFlowService;

    public WorkFlowController(IWorkFlowService workFlowService)
    {
        _workFlowService = workFlowService;
    }

    [HttpGet("{workFlowId}")]
    public async Task<IActionResult> GetWorkFlowAsync(string workFlowId)
    {
        try
        {
            var workflow = await _workFlowService.GetWorkFlowAsync(workFlowId);
            if (workflow == null)
            {
                return NotFound();
            }
            return Ok(workflow);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{workFlowId}/stages/{stageId}")]
    public async Task<IActionResult> GetStageAsync(string workFlowId, string stageId)
    {
        try
        {
            var stage = await _workFlowService.GetStageAsync(workFlowId, stageId);
            if (stage == null)
            {
                return NotFound();
            }
            return Ok(stage);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("{workFlowId}/stages")]
    public async Task<IActionResult> CreateOrUpdateStageAsync(string workFlowId, [FromBody] WorkflowStageModel stage)
    {
        try
        {
            var createdOrUpdatedStage = await _workFlowService.CreateOrUpdateStageAsync(workFlowId, stage);
            return CreatedAtAction("GetStage", new { workFlowId = workFlowId, stageId = createdOrUpdatedStage.Id }, createdOrUpdatedStage);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{workFlowId}/stages/{stageId}")]
    public async Task<IActionResult> DeleteStageAsync(string workFlowId, string stageId)
    {
        try
        {
            var result = await _workFlowService.DeleteStageAsync(workFlowId, stageId);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
