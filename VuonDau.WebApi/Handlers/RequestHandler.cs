using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace VuonDau.WebApi.Handlers
{
    public class RequestHandler
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _accessor;
        public RequestHandler(RequestDelegate next, IConfiguration configuration, IHttpContextAccessor accessor)
        {
            _next = next;
            _configuration = configuration;
            _accessor = accessor;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var key = context.Request.Headers["secret"];
            var secretKey = _configuration["SecretKey"];
            if (!string.IsNullOrWhiteSpace(_configuration["SecretKey"])
                && !secretKey.Equals(key)
                )
            {
                int statusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(JsonConvert.SerializeObject("Bad request"));
                return;
            }
            await _next(context);
        }
    }

    public class TokenAttribute : Attribute
    {

    }
}
