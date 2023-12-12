using demo_model;
using demo_service;
using Microsoft.AspNetCore.Mvc;

namespace career_path_builder_BE.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PathController : ControllerBase
    {
        private readonly IPathService _pathService;
        public PathController(IPathService pathService)
        {
            _pathService = pathService;
        }

        [HttpGet]
        [Route("getAllPath")]
        public async Task<IActionResult> GetAllPath()
        {
            var getallpath = _pathService.GetAllPath();
            return Ok(getallpath);
        }
        [HttpPost]
        [Route("addPath")]
        public async Task<IActionResult> addPath(demo_model.Path path)
        {
            var addpath = _pathService.AddPath(path);
            return Ok(addpath);
        }
    }
}
