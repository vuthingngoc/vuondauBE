using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VuonDau.Data.Common.Constants;

namespace VuonDau.WebApi
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizedAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        public string AppRoles { get; set; }
        public CustomAuthorizedAttribute()
        {

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
            var configuration = context.HttpContext.RequestServices.GetService(typeof(IConfiguration)) as IConfiguration;
            var apps = new List<string>();
            apps.Add("Admin");
            apps.Add("Customer");
            apps.Add("Farmer");
            if (string.IsNullOrEmpty(AppRoles)) return true;
            var roles = AppRoles?.Split(",");
            if (!roles.Any()) return true;
            if (!apps.Intersect(roles).Any())
                return false;
            return true;
        }
    }
}
