using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CRMSBI.Helper
{
    public class UserPermissionAttribute : ActionFilterAttribute
    {
        public string? kodeMenu { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (true)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Login" }));
            }
            context.HttpContext.Items["currentMenu"] = kodeMenu;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
        }
    }
}