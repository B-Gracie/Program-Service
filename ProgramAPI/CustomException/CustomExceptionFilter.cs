namespace ProgramAPI.CustomException;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly ILogger<CustomExceptionFilterAttribute> _logger;

    public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
    {
        _logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "An unhandled exception occurred.");

        context.Result = new ObjectResult(new
        {
            StatusCode = 500,
            Message = "An internal server error occurred."
        })
        {
            StatusCode = 500
        };
    }
}
