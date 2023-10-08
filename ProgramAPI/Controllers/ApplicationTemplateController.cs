using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using ProgramAPI.CustomException;
using ServiceLayer.ServiceInterface;

namespace ProgramAPI.Controllers
{
    [ApiController]
    [Route("api/applicationtemplates")]
    [ServiceFilter(typeof(CustomExceptionFilterAttribute))]
    public class ApplicationTemplateController : ControllerBase
    {
        private readonly IApplicationTemplateService _templateService;

        public ApplicationTemplateController(IApplicationTemplateService templateService)
        {
            _templateService = templateService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationTemplateAsync(string id)
        {
            try
            {
                var template = await _templateService.GetApplicationTemplateAsync(id);
                if (template == null)
                {
                    return NotFound();
                }
                return Ok(template);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{templateId}/questions")]
        public async Task<IActionResult> AddQuestionAsync(string templateId, [FromBody] ApplicationQuestionModel question)
        {
            try
            {
                var addedQuestion = await _templateService.AddQuestionAsync(templateId, question);
                if (addedQuestion == null)
                {
                    return NotFound();
                }
                return CreatedAtAction("GetQuestion", new { templateId, questionId = addedQuestion.Id }, addedQuestion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{templateId}/questions/{questionId}")]
        public async Task<IActionResult> GetQuestionAsync(string templateId, string questionId)
        {
            try
            {
                var question = await _templateService.GetQuestionAsync(templateId, questionId);
                if (question == null)
                {
                    return NotFound();
                }
                return Ok(question);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{templateId}/questions/{questionId}")]
        public async Task<IActionResult> UpdateQuestionAsync(string templateId, string questionId, [FromBody] ApplicationQuestionModel question)
        {
            try
            {
                var updatedQuestion = await _templateService.UpdateQuestionAsync(templateId, question);
                if (updatedQuestion == null)
                {
                    return NotFound();
                }
                return Ok(updatedQuestion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{templateId}/questions/{questionId}")]
        public async Task<IActionResult> DeleteQuestionAsync(string templateId, string questionId)
        {
            try
            {
                var result = await _templateService.DeleteQuestionAsync(templateId, questionId);
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
}
