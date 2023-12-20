using demo_common;
using demo_service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

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
        [Route("getAllReviewResultUserId")]
        public async Task<IActionResult> GetAllReviewResultUserId(int staffId, int reviewid,int reviewresultid)
        {
            _logger.LogInformation("getAllReviewResultUser method starting");
            var getStaff = _allReviewResultUserService.GetReviewResultUserByUserid(staffId, reviewid, reviewresultid);
            return Ok(getStaff);
        }
        [HttpGet]
        [Route("getAllReviewResultUserByKey")]
        public async Task<IActionResult> GetAllResultByKey(int staffId, int pathid, int reviewid)
        {
            _logger.LogInformation("getAllReviewResultUserByKey method starting");
            var getStaff = _allReviewResultUserService.GetReviewResultUserByKey(staffId, pathid, reviewid);
            return Ok(getStaff);
        }
        [HttpGet]
        [Route("getUserCompare")]
        public IActionResult GetUserCompare(int pathid, int reviewid, int userid1, int userid2)
        {
            _logger.LogInformation("getAvarageReviewResult method starting");
            var getStaff = _allReviewResultUserService.GetUserCompare(pathid, reviewid, userid1, userid2);
            return Ok(getStaff);
        }
        /*[HttpGet]
        [Route("getAvarageReviewResult1")]
        public IActionResult GetAvarageReviewResult1(int pathid)
        {
            ResponseMessage response = new ResponseMessage();
            _logger.LogInformation("getAvarageReviewResult method starting");
            var getStaff = JsonConvert.SerializeObject(_allReviewResultUserService.GetAverageReviewResultOnlyUser(pathid));
            response.data = getStaff;
            return Ok(response);
        }*/
    }
}
