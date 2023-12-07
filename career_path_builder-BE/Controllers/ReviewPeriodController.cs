using demo_common;
using demo_core;
using demo_service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace career_path_builder_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewPeriodController : ControllerBase
    {
        private readonly IReviewPeriodService _reviewperiod;
        public ReviewPeriodController(IReviewPeriodService reviewPeriod)
        {
            _reviewperiod = reviewPeriod;
        }

        [HttpGet]
        [Route("getAllReviewPeriod")]
        public async Task<IActionResult> getallreviewperiod()
        {
            var getlist = _reviewperiod.GetAllReviewPeriodResponse();
            return Ok(getlist);
        }
    }

    
}
