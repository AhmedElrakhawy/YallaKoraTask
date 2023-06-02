using DTOs.TokenDtos;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaKora.API.Settings;

namespace YallaKora.API.Managers
{
    public class ClientManager : IClientManager
    {
        private readonly ClientSetting _clientSetting;
        private readonly ICryptoService _cryptoService;

        public ClientManager(IOptions<ClientSetting> clientSetting, ICryptoService cryptoService)
        {
            _clientSetting = clientSetting.Value;
            _cryptoService = cryptoService;
        }

        public async Task<string> GenerateTokenAsync(ClientDto clientDto)
        {
            try
            {
                var existClient = _clientSetting.Clients
                    .FirstOrDefault(c => c.Id == clientDto.Id &&
                                         c.Name.Equals(clientDto.Name));

                if (existClient is null)
                    return "Client doesn't exist.";

                var token = new ApiTokenDto
                {
                    Id = existClient.Id,
                    Key = existClient.Key,
                    ExpireDate = DateTime.UtcNow.AddMinutes(10)
                };

                var tokenJson = JsonConvert.SerializeObject(token);

                var tokenByteArray = await _cryptoService.EncryptAsync(tokenJson, EncryptionInfo.Key, EncryptionInfo.IV);

                var tokenBase64 = Convert.ToBase64String(tokenByteArray);

                return tokenBase64;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<bool> ValidateTokenAsync(string Token)
        {
            try
            {
                var tokenByteArray = Convert.FromBase64String(Token);

                var tokenJson = await _cryptoService.DecryptAsync(tokenByteArray, EncryptionInfo.Key, EncryptionInfo.IV);

                var token = JsonConvert.DeserializeObject<ApiTokenDto>(tokenJson);

                var isClient = _clientSetting.Clients.Any(c => c.Id == token.Id && c.Key.Equals(token.Key));

                if (!isClient || token.ExpireDate < DateTime.UtcNow)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
