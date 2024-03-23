using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aluno.API.Filters
{
    public class ResponseFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           var modelState = context.ModelState;

            if(modelState.IsValid is false)
            {
                var messageError = modelState.Values
                                   .SelectMany(x => x.Errors)
                                   .Select(x => x.ErrorMessage).ToList();


                context.Result = new BadRequestObjectResult(messageError);
            }
        }
    }
}
