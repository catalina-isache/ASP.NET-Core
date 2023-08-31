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
            var userId = jwtUtils.ValidateJwtToken(token);

            if (userId != Guid.Empty)
            {
                // httpContext.Items["User"] = teacherService.GetById(userId);
                var x = userService.GetById(userId);
                if (x == null)
                {
                    Console.WriteLine("not ok");
                }

                httpContext.Items["User"] = userService.GetById(userId);

            }

            await _next(httpContext);
        }
    } 
}
