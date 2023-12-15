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
        [Route("getAllReviewResultUser")]
        public async Task<IActionResult> GetAllStaff(int staffId)
        {
            _logger.LogInformation("getAllReviewResultUser method starting");
            var getStaff = _allReviewResultUserService.GetAllReviewResultUser(staffId);
            return Ok(getStaff);
        }
        [HttpGet]
        [Route("getAllReviewResultUserId")]
        public async Task<IActionResult> GetAllReviewResultUserId(int staffId)
        {
            _logger.LogInformation("getAllReviewResultUser method starting");
            var getStaff = _allReviewResultUserService.GetReviewResultUserByUserid(staffId);
            return Ok(getStaff);
        }
        [HttpGet]
        [Route("getAllReviewResultUserByKey")]
        public async Task<IActionResult> GetAllResultByKey(int staffId, int pathid)
        {
            _logger.LogInformation("getAllReviewResultUserByKey method starting");
            var getStaff = _allReviewResultUserService.GetReviewResultUserByKey(staffId, pathid);
            return Ok(getStaff);
        }
        [HttpGet]
        [Route("getAvarageReviewResultCompare")]
        public IActionResult GetAvarageReviewResultCompare(int userid, int pathid)
        {
            _logger.LogInformation("getAvarageReviewResult method starting");
            var getStaff = _allReviewResultUserService.GetAverageReviewResultUser(userid, pathid);
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
