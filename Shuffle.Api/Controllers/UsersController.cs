using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shuffle.Core.Models;
using Shuffle.Core.Services;

namespace Shuffle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<User> GetAll([FromQuery] string authId)
        {
            return _userService.GetUsers(authId);
        }

        // GET api/values/5
        [HttpGet("{authId}")]
        public User Get(string authId)
        {
            return _userService.GetUser(authId);
        }

        // GET api/values/5
        [HttpGet("username/{username}")]
        public User GetByUsername(string username)
        {
            return _userService.GetUserByUsername(username);
        }

        // POST api/values
        [HttpPost]
        public User Post([FromBody] User user)
        {
            return _userService.CreateUser(user);
        }

        // PUT api/values/5
        [HttpPut("{authId}")]
        public User Put(string authId, [FromBody] User user)
        {
            return _userService.UpdateUser(authId, user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}