using FeatureFlag.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FeatureFlag.Infrastructure.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class GoogleAuthAttribute : Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var googleAuthService = context.HttpContext.RequestServices.GetRequiredService<IGoogleAuthService>();

            var authHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                context.Result = new UnauthorizedObjectResult(new { error = "No token provided" });
                return;
            }

            var token = authHeader.Substring("Bearer ".Length).Trim();

            try
            {
                var payload = await googleAuthService.ValidateTokenAsync(token);

                context.HttpContext.Items["User"] = new
                {
                    Email = payload.Email,
                    Name = payload.Name,
                    Subject = payload.Subject,
                    Picture = payload.Picture
                };
            }

            catch (UnauthorizedAccessException)
            {
                context.Result = new UnauthorizedObjectResult(new { error = "Invalid token" });
            }
        }
    }
}