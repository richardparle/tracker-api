using Microsoft.AspNetCore.Mvc;
using tracker_api.Models;
using tracker_api.Services;

namespace tracker_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeightController : ControllerBase
    {
        private readonly IWeightService _weightService;

        public WeightController(IWeightService weightService)
        {
            _weightService = weightService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<WeightEntry>>> GetAllWeightEntriesByUserId(Guid userId)
        {
            var userWeightEntries = await _weightService.GetAllWeightEntriesByUserIdAsync(userId);

            if (userWeightEntries == null) return NotFound();

            return Ok(userWeightEntries);
        }
    }
}