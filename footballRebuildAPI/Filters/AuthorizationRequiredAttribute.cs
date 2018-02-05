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
        private string[] _roles;

        public AuthorizationRequiredAttribute(IUserService userService, string[] roles = null)
        {
            _userService = userService;
            _roles = roles;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Headers.Any(x=>x.Key.ToLower()==Token.ToLower() && !string.IsNullOrEmpty(x.Value)))
            {
                var tokenAndAuthenticationTypeJSON = filterContext.HttpContext.Request.Headers.FirstOrDefault(x=> x.Key.ToLower() == Token.ToLower()).Value;

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
                            Content = "User not authorised - authentication token invalid"
                        };
                }
                else
                {
                    if (_roles!=null && !_roles.Contains(eo.Role))
                    {
                        filterContext.Result = //new UnauthorizedResult() { };
                        new ContentResult()
                        {
                            StatusCode = 403,
                            Content = "User not authorised - Not enough privileges to access"
                        };
                    }
                }
            }
            else
            {               
                //filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                filterContext.Result = //new UnauthorizedResult() { };
                new ContentResult()
                {   StatusCode = 403,
                    Content = "Missing authentication token in the request"
                };
                //ver headers = string.Join(",", filterContext.HttpContext.Request.Headers.ToArray()).ToString()
            }

            base.OnActionExecuting(filterContext);

        }
    }
}
