using demo_service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace career_path_builder_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllReviewResultUserController : ControllerBase
    {
        private readonly IAllReviewResultUserService _allReviewResultUserService;
        public AllReviewResultUserController(IAllReviewResultUserService allReviewResultUserService)
        {
            _allReviewResultUserService = allReviewResultUserService;
        }

        [HttpGet]
        [Route("getAllReviewResultUser")]
        public async Task<IActionResult> GetAllStaff(int staffId)
        {
            var getStaff = _allReviewResultUserService.GetAllReviewResultUser(staffId);
            return Ok(getStaff);
        }
        [HttpGet]
        [Route("getAllReviewResultUserByKey")]
        public async Task<IActionResult> GetAllResultByKey(int staffId)
        {
            var getStaff = _allReviewResultUserService.GetReviewResultUserByKey(staffId);
            return Ok(getStaff);
        }
    }
}
