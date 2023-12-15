using demo_service;
using Microsoft.AspNetCore.Mvc;

namespace career_path_builder_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriteriaByCapacityController : ControllerBase
    {
        private readonly ICriteriaByCapacityService _criteriaByCapacityService;
        public CriteriaByCapacityController(ICriteriaByCapacityService criteriaByCapacityService)
        {
            this._criteriaByCapacityService = criteriaByCapacityService;
        }
        [HttpGet]
        [Route("getAllCriterialByCapacity")]
        public async Task<IActionResult> GetAllCriterialByCapacity(int capacityid)
        {
            var getCriterial = _criteriaByCapacityService.GetAllCriteriaByCapacity(capacityid);
            return Ok(getCriterial);
        }
        [HttpGet]
        [Route("getAllCriterialByPath")]
        public async Task<IActionResult> GetAllCriterialByPath(int pathid)
        {
            var getCriterial = _criteriaByCapacityService.GetAllCriteriaByPathid(pathid);
            return Ok(getCriterial);
        }
    }
}
