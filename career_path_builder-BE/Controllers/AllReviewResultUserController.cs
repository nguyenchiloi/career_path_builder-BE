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
        private readonly ILogger<AllReviewResultUserController> _logger;
        public AllReviewResultUserController(IAllReviewResultUserService allReviewResultUserService, ILogger<AllReviewResultUserController> logger)
        {
            _allReviewResultUserService = allReviewResultUserService;
            _logger = logger;
            _logger.LogInformation("AllReviewResultUserController Called");
        }

        [HttpGet]
        [Route("getAllReviewResultUser")]
        public async Task<IActionResult> GetAllStaff(int staffId)
        {
            _logger.LogInformation("getAllReviewResultUser method starting");
            var getStaff = _allReviewResultUserService.GetAllReviewResultUser(staffId);
            return Ok(getStaff);
        }
        [HttpGet]
        [Route("getAllReviewResultUserByKey")]
        public async Task<IActionResult> GetAllResultByKey(int staffId)
        {
            _logger.LogInformation("getAllReviewResultUserByKey method starting");
            var getStaff = _allReviewResultUserService.GetReviewResultUserByKey(staffId);
            return Ok(getStaff);
        }
    }
}
