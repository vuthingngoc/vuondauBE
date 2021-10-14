using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace VuonDau.WebApi
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizedAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private string _appRoles;
        public CustomAuthorizedAttribute()
        {

        }
        public CustomAuthorizedAttribute(string appRoles)
        {
            _appRoles = appRoles;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                if (!Check(context))
                {
                    int statusCode = (int)HttpStatusCode.Unauthorized;
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = statusCode;
                    var result = JsonConvert.SerializeObject(
                new
                {
                    isError = true,
                    errorCode = statusCode,
                    model = string.Empty
                });
                    context.Result = new JsonResult(result);
                    await context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject("Unauthoried"));

                }
            }
        }
        private bool Check(AuthorizationFilterContext context)
        {
            if (string.IsNullOrEmpty(_appRoles)) return true;
            var roles = _appRoles?.Split(",");
            if (!roles.Any()) return true;
            if (!context.HttpContext.User.Claims.Where(w => w.Type == JwtClaimTypes.Role)
                .Select(s => s.Value).Intersect(roles).Any())
                return false;
            return true;
        }
    }
}