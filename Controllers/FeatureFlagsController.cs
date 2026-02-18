using FeatureFlag.Infrastructure.Auth;    
using FeatureFlag.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FeatureFlag.Api.Controllers
{
    [ApiController]
    [Route("flags")]
    public class FeatureFlagsController : ControllerBase
    {
        private readonly IFeatureFlagService _service;

        public FeatureFlagsController(IFeatureFlagService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetFeaturePercentageAsync()
        {
            var percentage = await _service.GetPercentage();
            return Ok(percentage);
        }

        [HttpPost("admin")]
        [GoogleAuth] 
        public async Task<IActionResult> SetFeaturePercentage([FromBody] int percentage)
        {
            var user = HttpContext.Items["User"] as dynamic;

            Console.WriteLine($"User {user?.Email} is setting percentage to {percentage}");

            await _service.SetPercentageAsync(percentage);

            return Ok(new
            {
                success = true,
                message = "Percentage updated successfully",
                updatedBy = user?.Email
            });
        }
    }
}