using demo_service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace career_path_builder_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreterialLevelController : ControllerBase
    {
        private readonly ICreterialLevelService _service;
        private readonly ILogger<CreterialLevelController> _logger;
        public CreterialLevelController(ICreterialLevelService service, ILogger<CreterialLevelController> logger)
        {
            _service = service;
            _logger = logger;
            _logger.LogInformation("CreterialLevelController called");
        }
        [HttpGet]
        [Route("getAllCriterialLevel")]
        public async Task<IActionResult> GetAllCriterialLevel(int pathid)
        {
            _logger.LogInformation(" getAllCriterialLevel called");
            var getStaff = _service.GetAllCreterialLevel(pathid);
            return Ok(getStaff);
        }
    }
}
