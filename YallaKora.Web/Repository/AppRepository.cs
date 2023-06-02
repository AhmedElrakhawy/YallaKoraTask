using DTOs.TokenDtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YallaKora.Web.Repository.IRepository;
using YallaKora.Web.Settings;
using static System.Net.Mime.MediaTypeNames;

namespace YallaKora.Web.Repository
{
    public class AppRepository : IAppRepository
    {
        private readonly IHttpClientFactory _ClientFactory;
        private readonly AppToken _appToken;
        private IConfiguration _Config;

        public AppRepository(IHttpClientFactory ClientFactory, IOptions<AppToken> appToken, IConfiguration configuration)
        {
            _ClientFactory = ClientFactory;
            _appToken = appToken.Value;
            _Config = configuration;
        }
        public async Task<bool> AppTokenGenerateAsync(string Url, ApplicationSetting appSetting)
        {

            var Request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Url),
                Content = new StringContent(JsonConvert.SerializeObject(appSetting), Encoding.UTF8, "application/json")
            };

            var Client = _ClientFactory.CreateClient();

            var Response = await Client.SendAsync(Request);

            if (Response.StatusCode == HttpStatusCode.OK)
            {
                var val = await Response.Content.ReadAsStringAsync();

                _Config.GetSection("AppToken:Token").Value = val;
                var val2 = _Config.GetSection("AppToken:Token").Value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> AppTokenValidationAsync(string Url, string Token)
        {
            var Request = new HttpRequestMessage(HttpMethod.Post, Url);

            //Request.Headers.Accept.Add()
            Request.Headers.Add("Api-Key-Auth", Token);

            var Client = _ClientFactory.CreateClient();

            var Response = await Client.SendAsync(Request);

            if (Response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
