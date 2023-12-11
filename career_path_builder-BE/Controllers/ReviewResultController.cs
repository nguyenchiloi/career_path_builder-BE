using demo_model;
using demo_service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace career_path_builder_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewResultController : ControllerBase
    {
        private readonly IReviewResultService _result;
        public ReviewResultController(IReviewResultService result)
        {
            _result = result;
        }

        [HttpGet]
        [Route("getAllReviewResult")]
        public async Task<IActionResult> getallreviewperiod()
        {
            var getlist = _result.GetAllReviewResult();
            return Ok(getlist);
        }
    }
}
