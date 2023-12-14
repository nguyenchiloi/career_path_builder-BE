using demo_model;
using demo_service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace career_path_builder_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly ILevelService _levelService;
        private readonly ILogger<LevelController> _logger;
        public LevelController(ILevelService levelService, ILogger<LevelController> logger)
        {
            _levelService = levelService;
            _logger = logger;
            _logger.LogInformation("Level controller called");
        }
        [HttpPost]
        [Route("addLevel")]
        public async Task<IActionResult> AddLevel(Level level)
        {
            _logger.LogInformation("addLevel starting");
            var add = _levelService.AddLevel(level);
            return Ok(add);
        }
        [HttpGet]
        [Route("addLevel")]
        public async Task<IActionResult> GetLevel(int pathid)
        {
            _logger.LogInformation("Level get method starting");
            var add = _levelService.GetLevelByPathid(pathid);
            return Ok(add);
        }
        [HttpGet]
        [Route("getTreeLevel")]
        public async Task<IActionResult> GetTreeLevel(int pathid)
        {
            _logger.LogInformation("Level get method starting");
            var add = _levelService.GetTreeByPathid(pathid);
            return Ok(add);
        }
    }
}
