using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Web.Middlewares
{
    public class NotAuthenticatedMiddleware
    {
        private readonly RequestDelegate _next;

        public NotAuthenticatedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.ToString().Contains("not-authorised") && context.Request.Query.ContainsKey("redirect"))
            {
                context.Response.Redirect(context.Request.Path.ToString());
            }

            await _next(context);
        }
    }
}
