using CornerstoneManager.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CornerstoneManager.Filter;

public class ValidateIdAttribute<T> : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        
        var id = (int)(context.ActionArguments["id"] ?? 0);
        if (id > 0)
        {
            var svc = context.HttpContext.RequestServices;
            var repository = svc.GetService<IRepository<T>>();
            if (repository is null)
                throw new Exception();

            if (repository.Exists(id)) return;
            
            context.ModelState.AddModelError("id", "Not found, id: " + id);
            var problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status404NotFound
            };
            context.Result = new BadRequestObjectResult(problemDetails);
        }
        else
        {
            context.ModelState.AddModelError("id", "Id is invalid.");
            var problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest
            };
            context.Result = new BadRequestObjectResult(problemDetails);
        }
    }
}