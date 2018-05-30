using DotNetPOC.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetPOC.Filters
{
    public class AuthorizationFilter : IActionFilter
    {
        private readonly IProgramGroupService service;
        public AuthorizationFilter(IProgramGroupService service) : base()
        {
            this.service = service;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //does nothing            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var programGroups = service.Get();
        }
    }
}