using CornerstoneManager.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CornerstoneManager.Filter;

public class ValidateShiftStartAtEndAt : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        var shift = context.ActionArguments["shift"] as Shift;

        if (shift != null && shift.StartAt < DateTime.Now)
            context.ModelState.AddModelError("startAt", "Shift can't start in the past");

        if (shift != null && shift.EndAt < shift.StartAt)
            context.ModelState.AddModelError("endAt", "Shift can't end before start");

        if (context.ModelState.ErrorCount <= 0) return;

        var problemDetails = new ValidationProblemDetails(context.ModelState)
        {
            Status = StatusCodes.Status400BadRequest
        };

        context.Result = new BadRequestObjectResult(problemDetails);
    }
}