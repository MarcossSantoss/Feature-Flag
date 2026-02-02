using FeatureFlag.Application.DTOs;
using FeatureFlag.Application.Services;
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
    }
}
