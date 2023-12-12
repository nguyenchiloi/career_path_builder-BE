using demo_model;
using demo_service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace career_path_builder_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeLevelController : ControllerBase
    {
        private readonly ITreeLevelService _treeLevelService;
        public TreeLevelController(ITreeLevelService treeLevelService)
        {
            _treeLevelService = treeLevelService;
        }

        [HttpGet]
        [Route("getAllLevel")]
        public async Task<IActionResult> GetAllStaff()
        {
            var getStaff = _treeLevelService.GetAllLevel();
            return Ok(getStaff);
        }
        [HttpGet]
        [Route("get-all-tree")]
        public IActionResult GetStructure()
        {
            NodeGetTreeLevelStructure getTreeEmployeeStructure = new NodeGetTreeLevelStructure();
            getTreeEmployeeStructure = _treeLevelService.GetTreeByUsername();
            return Ok(getTreeEmployeeStructure);
        }
    }
}
