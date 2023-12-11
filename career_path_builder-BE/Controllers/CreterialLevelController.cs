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
        public CreterialLevelController(ICreterialLevelService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("getAllCriterialLevel")]
        public async Task<IActionResult> GetAllCriterialLevel(int pathid)
        {
            var getStaff = _service.GetAllCreterialLevel(pathid);
            return Ok(getStaff);
        }
    }
}
