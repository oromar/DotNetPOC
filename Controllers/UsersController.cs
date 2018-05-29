using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetPOC.Business;
using DotNetPOC.Models;
using DotNetPOC.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DotNetPOC.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UserBO userBO;
        public UsersController(UsersDbContext context)
        {
            this.userBO = new UserBO(context);
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(userBO.Get());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(userBO.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            return Ok(userBO.Save(user));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]User user)
        {
            return Ok(userBO.Update(id, user));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            userBO.Delete(id);
            return NoContent();
        }
    }
}
