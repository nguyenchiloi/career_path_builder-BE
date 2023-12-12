using demo_model;
using demo_service;
using Microsoft.AspNetCore.Mvc;


namespace career_path_builder_BE.Controllers
{
    [Route("api/")]
    [ApiController]
    public class Criteria_LevelsController : ControllerBase
    {
        private readonly ICriteria_LevelsService _criteria_levelsService;
        public Criteria_LevelsController(ICriteria_LevelsService criteria_levelsService)
        {
            this._criteria_levelsService = criteria_levelsService;
        }
        [HttpPost]
        [Route("/addCriteriaToLevel")]
        public async Task<IActionResult> AddCriteriaToLevel(Levels_Criteria levels_Criteria)
        {
            var addCriteriaToLevel = _criteria_levelsService.AddCriteriaToLevels(levels_Criteria);
            return Ok(addCriteriaToLevel);
        }

        [HttpGet]
        [Route("/GetCriteriaByLevelId")]
        public async Task<IActionResult> GetCriteriaByLevelId(int levelId)
        {
            var getCriteriaByLevelId = _criteria_levelsService.GetCriteriaByLevel(levelId);
            return Ok(getCriteriaByLevelId);
        }
    }
}
