using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotNetPOC.Business;
using DotNetPOC.Resources;
using DotNetPOC.Models;
using DotNetPOC.Persistence;
using DotNetPOC.Service;
using Microsoft.AspNetCore.Mvc;

/*
Class responsible to validate request parameters and call service layer
 */

namespace DotNetPOC.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UserService service;

        public UsersController(Persistence.AppContext context, IMapper mapper)
        {
            this.service = new UserService(context, mapper);
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.Get());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(service.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]UserResource userResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(service.Save(userResource));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserResource userResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(service.Update(id, userResource));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return NoContent();
        }
    }
}
