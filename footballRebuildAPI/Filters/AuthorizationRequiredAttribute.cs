using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Filters
{
    public class AuthorizationRequiredAttribute : ActionFilterAttribute
    {
        private const string Token = "authenticationToken";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Headers.Any(x=>x.Key==Token && !string.IsNullOrEmpty(x.Value)))
            {

            }
            else
            {
                
                //filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                filterContext.Result = //new UnauthorizedResult() { };
                new ContentResult()
                {   StatusCode = 403,
                    Content = "Short circuit filter"
                };
            }

            base.OnActionExecuting(filterContext);

        }
    }
}
