using DotNetPOC.Interfaces;
using DotNetPOC.Resources;
using Microsoft.AspNetCore.Mvc;
namespace DotNetPOC.Controllers
{
    [Route("api/[controller]")]
    public class ProgramGroupsController : Controller
    {
        private readonly IProgramGroupService service;

        public ProgramGroupsController(IProgramGroupService service)
        {
            this.service = service;
        }        

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProgramGroupResource programGroupResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(service.Save(programGroupResource));
        }

        [HttpPost("{id}")]
        public IActionResult Post(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.Set(id);

            return Ok();
        }
    }
}