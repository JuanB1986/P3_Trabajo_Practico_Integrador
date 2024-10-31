using System.Net;
using System.Text.Json;

namespace TPI_Viajes_Compartidos.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Ejecuta la solicitud HTTP
                await _next(context);
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción lanzada.
                await HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Define el tipo de excepción y devuelve un código de estado apropiado
            var code = HttpStatusCode.InternalServerError;

            if (exception is KeyNotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            var response = new
            {
                status = context.Response.StatusCode,
                message = exception.Message
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}