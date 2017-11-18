using Football.Crosscutting.ViewModels.User;
using Football.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Filters
{
    public class AuthorizationRequiredAttribute : ActionFilterAttribute
    {
        private const string Token = "authenticationToken";
        private IUserService _userService;

        public AuthorizationRequiredAttribute(IUserService userService)
        {
            _userService = userService;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Headers.Any(x=>x.Key==Token && !string.IsNullOrEmpty(x.Value)))
            {
                var tokenAndAuthenticationTypeJSON = filterContext.HttpContext.Request.Headers.FirstOrDefault(x=>x.Key==Token).Value;

                var jsonSerializerSettings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                };

                var token = JsonConvert.DeserializeObject<TokenAuthenticationType>(tokenAndAuthenticationTypeJSON, jsonSerializerSettings);
                

                var task = Task.Run(() => _userService.Login(token.AuthenticationType, "", token.Token, false));
                var eo = task.Result;

                if (eo == null)
                {
                    filterContext.Result = //new UnauthorizedResult() { };
                        new ContentResult()
                        {
                            StatusCode = 403,
                            Content = "Short circuit filter"
                        };
                }
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
