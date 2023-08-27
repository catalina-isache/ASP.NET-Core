using Proiect.Helpers.JwtUtils;
using Proiect.Services.AdminService;

namespace Proiect.Helpers.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IAdminService adminService, IJwtUtils jwtUtils)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var userId = jwtUtils.ValidateJwtToken(token);

            if (userId != Guid.Empty)
            {
                // httpContext.Items["User"] = teacherService.GetById(userId);

                httpContext.Items["Admin"] = adminService.GetById(userId);

            }

            await _next(httpContext);
        }
    } 
}
