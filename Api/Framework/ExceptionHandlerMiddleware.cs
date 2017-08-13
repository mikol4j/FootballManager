using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.Framework
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext ctx)
        {
            try
            {
                await _next(ctx);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(ctx, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext ctx, Exception ex)
        {
            var errorCode = "error";
            var statusCode = HttpStatusCode.BadRequest;
            var exceptionType = ex.GetType();
            switch(ex)
            {
                case Exception e when exceptionType == typeof(UnauthorizedAccessException):
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                //TODO: Custom exception
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }
            var response = new { code = errorCode, message = ex.Message };
            var payload = JsonConvert.SerializeObject(response);
            ctx.Response.ContentType = "application/json";
            ctx.Response.StatusCode = (int)statusCode;

            return ctx.Response.WriteAsync(payload);
        }
    }
}
