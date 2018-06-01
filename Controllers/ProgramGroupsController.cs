using DotNetPOC.Interfaces;
using DotNetPOC.Resources;
using Microsoft.AspNetCore.Mvc;
namespace DotNetPOC.Controllers
{
    [Route("api/[controller]")]
    public class ProgramGroupsController : Controller
    {
        private readonly IProgramGroupDomain domain;

        public ProgramGroupsController(IProgramGroupDomain domain)
        {
            this.domain = domain;
        }        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(domain.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody]ProgramGroupResource programGroupResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(domain.Save(programGroupResource));
        }
        [HttpPost("{id}")]
        public IActionResult Post(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            domain.Set(id);

            return Ok();
        }
    }
}