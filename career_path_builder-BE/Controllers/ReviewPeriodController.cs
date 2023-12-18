using demo_common;
using demo_core;
using demo_model;
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

        [HttpGet]
        [Route("GetAllReviewPeriodByReviewId")]
        public async Task<IActionResult> GetAllReviewPeriodByReviewId(int reviewid, int pathid)
        {
            var getlist = _reviewperiod.GetAllReviewPeriodByReview(reviewid,pathid);
            return Ok(getlist);
        }

        [HttpGet]
        [Route("GetAllReviewPeriodByPathId")]
        public async Task<IActionResult> GetAllReviewPeriodByPathId(int id)
        {
            var getlist = _reviewperiod.GetAllReviewPeriodByPath(id);
            return Ok(getlist);
        }

        [HttpPost]
        [Route("addReviewPeriod")]
        public async Task<IActionResult> addreviewperiod(Review_Period review_Period)
        {
            var add = _reviewperiod.AddReviewPeriod(review_Period);
            return Ok(add);
        }
    }

    
}
