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

        [HttpGet]
        [Route("getAllReviewDetailByReviewId")]
        public async Task<IActionResult> getallreviewdetailbyreviewid(int id)
        {
            var getlist = _result.GetAllReviewDetailByReviewID(id);
            return Ok(getlist);
        }

        [HttpGet]
        [Route("getAllReviewDetailByUserId")]
        public async Task<IActionResult> getallreviewdetailbyuserid(int id)
        {
            var getlist = _result.GetAllReviewDetailByUserID(id);
            return Ok(getlist);
        }

        [HttpPost]
        [Route("addReviewResult")]
        public async Task<IActionResult> addReviewResult(Review_Result review_Result)
        {
            var getlist = _result.AddReviewResult(review_Result);
            return Ok(getlist);
        }
    }
}
