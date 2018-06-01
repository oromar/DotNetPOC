using System;
using System.Linq;
using DotNetPOC.Business;
using DotNetPOC.Interfaces;
using DotNetPOC.Persistence;
using DotNetPOC.Utils;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetPOC.Filters
{
    public class AuthorizationFilter : Attribute, IActionFilter
    {
        private readonly IProgramGroupDomain domain;
        public AuthorizationFilter(IProgramGroupDomain domain) : base()
        {
            this.domain = domain;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //does nothing            
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var programGroup = domain.GetActual();

            if (programGroup != null)
                context.HttpContext.Items[Constants.ConnectionString] = programGroup.ConnectionStringKey;
        }
    }
}