using DTOs.TokenDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaKora.API.Managers;

namespace YallaKora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientManager _clientManager;

        public ClientsController(IClientManager clientManager)
        {
            _clientManager = clientManager;
        }

        [HttpPost("GenerateToken")]
        public async Task<IActionResult> GenerateToken(ClientDto clientDto)
        {
            var result = await _clientManager.GenerateTokenAsync(clientDto);

            if (result is null)
                return BadRequest();
            else
                return Ok(result);
        }
        [HttpPost("ValidateToken")]
        public async Task<IActionResult> ValidateToken([FromHeader(Name = "Api-Key-Auth")]string Token)
        {
            var result = await _clientManager.ValidateTokenAsync(Token);

            if (result)
                return Ok();
            else
                return BadRequest();
        }
    }
}
