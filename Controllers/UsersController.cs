using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotNetPOC.Business;
using DotNetPOC.Resources;
using DotNetPOC.Models;
using DotNetPOC.Persistence;
using DotNetPOC.Interfaces;
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
        private readonly IServiceUser service;

        public UsersController(IServiceUser service)
        {
            this.service = service;
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
            var user = service.Get(id);
            if (user != null)
                return Ok(service.Get(id));
            return NotFound();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]UserResource userResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var savedUser = service.Save(userResource);

                return Created(string.Format("/api/users/{0}", savedUser.UserId), savedUser);
            }
            catch(Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            
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

        [HttpGet("search/{name?}/{email?}/{login?}")]
        public IActionResult Get(string name = "", string email = "", string login = "")
        {
            var users = service.Get(name, email, login);
            if (users != null)
                return Ok(users);
            return NotFound();
        }
    }
}
