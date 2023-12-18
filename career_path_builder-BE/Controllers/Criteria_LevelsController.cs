using demo_model;
using demo_service;
using Microsoft.AspNetCore.Mvc;


namespace career_path_builder_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Criteria_LevelsController : ControllerBase
    {
        private readonly ICriteria_LevelsService _criteria_levelsService;
        private readonly ILogger<Criteria_LevelsController> _logger;
        public Criteria_LevelsController(ICriteria_LevelsService criteria_levelsService, ILogger<Criteria_LevelsController> logger)
        {
            this._criteria_levelsService = criteria_levelsService;
            _logger = logger;
            _logger.LogInformation("Criteria_LevelsController called");
        }
        [HttpPost]
        [Route("addCriteriaToLevel")]
        public async Task<IActionResult> AddCriteriaToLevel(Levels_Criteria levels_Criteria)
        {
            _logger.LogInformation("addCriteriaToLevel called");
            var addCriteriaToLevel = _criteria_levelsService.AddCriteriaToLevels(levels_Criteria);
            return Ok(addCriteriaToLevel);
        }
        [HttpPost]
        [Route("addListCriteriaToLevel")]
        public async Task<IActionResult> AddListCriteriaToLevel(List<Levels_Criteria> listCriterial)
        {
            _logger.LogInformation("addCriteriaToLevel called");
            var addCriteriaToLevel = _criteria_levelsService.AddListCriterialToLevels(listCriterial);
            return Ok(addCriteriaToLevel);
        }
        [HttpGet]
        [Route("GetCriteriaByLevelId")]
        public async Task<IActionResult> GetCriteriaByLevelId(int levelId)
        {
            _logger.LogInformation("GetCriteriaByLevelId called");
            var getCriteriaByLevelId = _criteria_levelsService.GetCriteriaByLevel(levelId);
            return Ok(getCriteriaByLevelId);
        }
    }
}
