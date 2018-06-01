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
using DotNetPOC.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

/*
Class responsible to validate request parameters and call service layer
 */

namespace DotNetPOC.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(AuthorizationFilter))]
    public class UsersController : Controller
    {
        private readonly IDomainUser domain;
        private readonly ILogger<UsersController> logger;

        public UsersController(IDomainUser domain, ILogger<UsersController> logger)
        {
            this.domain = domain;
            this.logger = logger;
        }
        // GET api/users
        [HttpGet]
        public IActionResult Get()
        {
            logger.LogInformation("Get Users");
            return Ok(domain.Get());
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = domain.Get(id);
            if (user != null)
                return Ok(domain.Get(id));
            return NotFound();
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody]UserResource userResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var savedUser = domain.Save(userResource);

                return Created(string.Format("/api/users/{0}", savedUser.UserId), savedUser);
            }
            catch(Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserResource userResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(domain.Update(id, userResource));
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            domain.Delete(id);
            return NoContent();
        }

        [HttpGet("search/{name?}/{email?}/{login?}")]
        public IActionResult Get(string name = "", string email = "", string login = "")
        {
            var users = domain.Get(name, email, login);
            if (users != null)
                return Ok(users);
            return NotFound();
        }
    }
}
