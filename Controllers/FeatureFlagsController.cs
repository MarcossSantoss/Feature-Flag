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

        [HttpPost]
        public async Task<IActionResult> CreateFlag([FromBody] CreateFeatureFlagDto dto)
        {
            await _service.CreateFlagAsync(dto);
            return Created(string.Empty, null);
        }

        [HttpGet]
        public async Task<IActionResult> GetFlags([FromQuery] string env)
        {
            var flags = await _service.GetFlagsAsync(env);
            return Ok(flags);
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> GetFlagByKey(string key, [FromQuery] string env)
        {
            var flag = await _service.GetFlagByKeyAsync(key, env);

            if (flag == null)
                return NotFound();

            return Ok(flag);
        }
    }
}
