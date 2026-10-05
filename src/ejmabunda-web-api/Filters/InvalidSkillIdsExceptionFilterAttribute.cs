using ejmabunda_web_api.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ejmabunda_web_api.Filters;

/// <summary>
/// Translates an <see cref="InvalidSkillIdsException"/> thrown by any action on a
/// decorated controller into a 400 Bad Request, so individual actions don't each
/// need their own try/catch around the service call.
/// </summary>
public sealed class InvalidSkillIdsExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is not InvalidSkillIdsException e) return;

        context.Result = new BadRequestObjectResult(e.Message);
        context.ExceptionHandled = true;
    }
}
