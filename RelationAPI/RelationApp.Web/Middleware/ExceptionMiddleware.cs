using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RelationApp.Core.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RelationApp.Web.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception exception)
            {
                var message = exception.Message;
                context.Response.ContentType = "application/json";

                switch (exception)
                {
                    case InvalidSortingPropertyException _:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        message = "Internal server error";
                        break;
                }

                await context.Response.WriteAsync(JsonConvert.SerializeObject(message));
            }
        }
    }
}
