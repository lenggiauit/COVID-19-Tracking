using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using C19Tracking.API.Resources;
using Newtonsoft.Json; 

namespace C19Tracking.API.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class RequiredPermissionAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string[] _permissions;

        public RequiredPermissionAttribute(string[] permissions)
        {
            _permissions = permissions;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User; 
            if (!user.Identity.IsAuthenticated)
            { 
                context.Result = new UnauthorizedResult();
                return;
            }
            if (_permissions != null && _permissions.Length > 0)
            { 
                var identity = (ClaimsIdentity)user.Identity;
                IEnumerable<Claim> claims = identity.Claims;
                UserResource account = JsonConvert.DeserializeObject<UserResource>(claims.FirstOrDefault(s => s.Type == ClaimTypes.UserData)?.Value);

                if (account != null)
                {
                    if (account.Permissions.Where(p => _permissions.Any(s => s.Equals(p.PermissionCode))).Count() == 0)
                        context.Result = new UnauthorizedResult();
                    return;
                }
                else
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            } 
        }
    }
}