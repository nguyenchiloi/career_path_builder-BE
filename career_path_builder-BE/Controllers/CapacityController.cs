using demo_model;
using demo_service;
using Microsoft.AspNetCore.Mvc;

namespace career_path_builder_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapacityController : ControllerBase
    {
        private readonly ICapacityService _capacityService;
        public CapacityController(ICapacityService capacityService) 
        {
            this._capacityService = capacityService;
        }
        [HttpPost]
        [Route("addCapacity")]
        public async Task<IActionResult> AddCapacity(Capacity capacity)
        {
            var addCapacity = _capacityService.AddCapacity(capacity);
            return Ok(addCapacity);
        }
    }
}
