using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace LasApi.Filters
{
    public class ExampleFilter : IActionFilter
    {
        //istek tamamlanınca
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string controller = context.Controller.ToString();
            Debug.WriteLine($"OnActionExecuted: {controller}");
        }

        //istek çalışırken
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string controller = context.Controller.ToString();
            string action = context.ActionDescriptor.DisplayName;
            Debug.WriteLine($"OnActionExecuting: {controller} Action : {action}");
        }
    }
}
