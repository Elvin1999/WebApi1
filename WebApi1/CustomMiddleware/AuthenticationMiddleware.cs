using System.Security.Claims;
using System.Text;

namespace WebApi1.CustomMiddleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader == null)
            {
                context.Response.StatusCode = 401;
                await _next(context);
                return;
            }
            //basic  ruslan1234
            if (authHeader != null && authHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
            {
                var token = authHeader.Substring(6).Trim();
                string credentialString = "";
                try
                {
                    credentialString = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                }
                catch (Exception)
                {
                    context.Response.StatusCode = 501;
                }
                var credentials = credentialString.Split(':');
                if (credentials[0] == "elvin" && credentials[1] == "12345")
                {
                    var claims = new[]
                    {
                        new Claim("name",credentials[0]),
                        new Claim(ClaimTypes.Role,"Admin")
                    };
                    var identity = new ClaimsIdentity(claims, "Basic");
                    context.User = new ClaimsPrincipal(identity);
                }
                else
                {
                    context.Response.StatusCode = 401;
                }
            }
            await _next(context);
        }
    }
}
