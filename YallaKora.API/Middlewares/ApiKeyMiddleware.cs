using DTOs.TokenDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaKora.API.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http.Extensions;

namespace YallaKora.API.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ApiKeyHeaderName = "Api-Key-Auth";
        private readonly ClientSetting _clientSetting;
        private readonly IServiceProvider _serviceProvider;
        private const string ExcludedApiName = "/api/Clients/GenerateToken";
        private const string ExcludedApiName2 = "/api/Clients/ValidateToken";

        public ApiKeyMiddleware(RequestDelegate next,
                                IOptions<ClientSetting> clientSetting,
                                IServiceProvider serviceProvider)
        {
            _next = next;
            _clientSetting = clientSetting.Value;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var cryptoService = _serviceProvider.GetService<ICryptoService>();

            var endpoint = context.Request.Path.ToString();
            
            if (endpoint is not null && (!ExcludedApiName.Equals(endpoint) && !ExcludedApiName2.Equals(endpoint)))
            {
                if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Api key was not provided.");
                    return;
                }

                var tokenByteArray = Convert.FromBase64String(extractedApiKey);

                var decryptedJson = await cryptoService.DecryptAsync(tokenByteArray, EncryptionInfo.Key, EncryptionInfo.IV);

                var token = JsonConvert.DeserializeObject<ApiTokenDto>(decryptedJson);

                if (token.ExpireDate < DateTime.UtcNow)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Expired.");
                    return;
                }

                var isClient = _clientSetting.Clients.Any(c => c.Id == token.Id && c.Key.Equals(token.Key));

                if (!isClient)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized.");
                    return;
                }
            }

            await _next(context);
        }
    }

}
