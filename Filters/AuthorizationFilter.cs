using System;
using System.Linq;
using DotNetPOC.Business;
using DotNetPOC.Interfaces;
using DotNetPOC.Persistence;
using DotNetPOC.Service;
using DotNetPOC.Utils;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetPOC.Filters
{
    public class AuthorizationFilter : Attribute, IActionFilter
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
            var programGroup = service.GetActual();

            if (programGroup != null)
                context.HttpContext.Items[Constants.ConnectionString] = programGroup.ConnectionStringKey;
        }
    }
}