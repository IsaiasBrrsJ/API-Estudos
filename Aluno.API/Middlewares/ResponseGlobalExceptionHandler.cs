using System.Net;
using System.Text.Json;

namespace Aluno.API.Middlewares
{
    public class ResponseGlobalExceptionHandler
    {
        private readonly RequestDelegate _Next;
        public ResponseGlobalExceptionHandler(RequestDelegate next)
        =>  _Next = next;
        

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _Next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode status;
            string stackTrace = String.Empty;
            string message = String.Empty;
            var exceptionType = ex.GetType();


            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            context.Response.ContentType = "application/json";
            stackTrace = ex.StackTrace!;
            message = ex.Message;
            status = HttpStatusCode.Forbidden;

            var result = JsonSerializer.Serialize(new { status, message, stackTrace });


            return context.Response.WriteAsync(result);
        }
    }
}
