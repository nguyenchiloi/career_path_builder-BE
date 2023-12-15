using demo_model;
using demo_service;
using Microsoft.AspNetCore.Mvc;

namespace career_path_builder_BE.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AssessorController : ControllerBase
    {
        private readonly IAssessorService _assessorService;
        public AssessorController(IAssessorService assessorService)
        {
            this._assessorService = assessorService;
        }
        [HttpPost]
        [Route("/addAssensor")]
        public async Task<IActionResult> AddAssessor([FromBody] List<Assessor> assessors)
        {
            var addAssensor = _assessorService.AddAssessor(assessors);
            return Ok(addAssensor);
        }
        [HttpGet]
        [Route("/getAllUserByAssessorIDReviewID")]
        public async Task<IActionResult> GetAllUserByAssessorIDReviewID(int assessorid, int reviewid)
        {
            var addAssensor = _assessorService.GetAllUserByAssessorIDReviewID(assessorid, reviewid);
            return Ok(addAssensor);
        }
    }
}
