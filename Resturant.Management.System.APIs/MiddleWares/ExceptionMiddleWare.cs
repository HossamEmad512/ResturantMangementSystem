using Microsoft.AspNetCore.Http;
using Resturant.Management.System.APIs.Errors;
using System.Net;
using System.Text.Json;

namespace Resturant.Management.System.APIs.MiddleWares
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleWare> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleWare(RequestDelegate Next , ILogger<ExceptionMiddleWare> logger , IHostEnvironment env)
        {
            _next = Next;
            _logger = logger;
            _env = env;
        }

        //InvokeAsync
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex , ex.Message);
                //production => log ex in database

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;
                
                if (_env.IsDevelopment())
                {
                    var Response = new ApiExceptionResponse(500, ex.Message , ex.StackTrace.ToString());
                    var Options = new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                    var JsonResponse = JsonSerializer.Serialize(Response , Options);
                    context.Response.WriteAsync(JsonResponse);
                }
                else
                {
                    var Response = new ApiResponse(500);
                    var Options = new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                    var JsonResponse = JsonSerializer.Serialize(Response, Options);
                    context.Response.WriteAsync(JsonResponse);
                }
                
            }
        }
    }
}
