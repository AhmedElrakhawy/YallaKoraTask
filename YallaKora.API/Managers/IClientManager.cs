using DTOs.TokenDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YallaKora.API.Managers
{
    public interface IClientManager
    {
        Task<string> GenerateTokenAsync(ClientDto clientDto);
        Task<bool> ValidateTokenAsync(string Token);
    }
}
