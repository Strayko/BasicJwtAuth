using Microsoft.AspNetCore.Mvc;
using SofthouseDev.Api.Models.Request;
using SofthouseDev.Api.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofthouseDev.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ApiController
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterClient request)
        {
            var user = _userRepository.Registration(request);
            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginClient request)
        {
            var user = _userRepository.Authenticate(request);

            if (user != null)
                return Ok(user);

            return Unauthorized(new { errors = "Invalid Credentials"});
        }
    }
}
