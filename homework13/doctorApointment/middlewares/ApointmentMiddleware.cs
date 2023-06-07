using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;


namespace doctorApointment.middlewares
{
    public class ApointmentMiddleware
    {
        private RequestDelegate _next;
        private IConfiguration _configuration;

        public ApointmentMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Method == "POST" && _configuration.GetValue<bool>("BookingNotAllowed"))
            {
                httpContext.Response.Redirect("/not-allowed");
                return;
            }

            await _next(httpContext);
        }
    }
}
