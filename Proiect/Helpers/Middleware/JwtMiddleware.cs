using Proiect.Helpers.JwtUtils;
using Proiect.Services.AdminService;
using Proiect.Services.UserService;

namespace Proiect.Helpers.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var ok = httpContext;
            //var userId = jwtUtils.ValidateJwtToken(token);
            if (token != null)
            {
                var userId = jwtUtils.ValidateJwtToken(token);
                if (userId != Guid.Empty)
                {
                    var user = userService.GetById(userId);
                    if (user != null)
                    {
                        httpContext.Items["User"] = user;
                    }
                }
            }
           
            await _next(httpContext);
        }
    } 
}
