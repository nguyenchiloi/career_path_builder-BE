using demo_model;
using demo_service;
using Microsoft.AspNetCore.Mvc;

namespace career_path_builder_BE.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AssensorController : ControllerBase
    {
        private readonly IAssensorService _assensorService;
        public AssensorController(IAssensorService assensorService)
        {
            this._assensorService = assensorService;
        }
        [HttpPost]
        [Route("/addAssensor")]
        public async Task<IActionResult> AddAssensor(Assensor assensor)
        {
            var addAssensor = _assensorService.AddAssensor(assensor);
            return Ok(addAssensor);
        }
    }
}
