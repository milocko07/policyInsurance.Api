using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using policyInsurance.Entities;

namespace policyInsurance.WebApi.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 500;

            context.Result = new JsonResult(new Error()
            {
                StatusCode = context.HttpContext.Response.StatusCode,
                Message = context.Exception.Message
            });

            base.OnException(context);
        }
    }
}
