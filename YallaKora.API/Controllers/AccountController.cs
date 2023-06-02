using DTOs.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaKora.API.Repository.IRepository;

namespace YallaKora.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _UserRepository;
        public AccountController(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] UserDto Model)
        {
            var user = _UserRepository.Authenticate(Model.Email, Model.Password);
            if (user == null)
            {
                return BadRequest(new { Message = "Email or Passward is incorrect" });
            }
            return Ok(user);
        }
        [HttpPost("Register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] UserDto user)
        {
            var IfUserIsUnique = _UserRepository.IsUniqueUser(user.Email);
            if (!IfUserIsUnique)
            {
                return BadRequest(new { Message = "Email is Excist" });
            }
            var NewUser = _UserRepository.Register(user.Email, user.Password);
            if (NewUser == null)
            {
                return BadRequest(new { Message = "Something went wrong with registaring" });
            }
            return Ok();
        }
    }
}
