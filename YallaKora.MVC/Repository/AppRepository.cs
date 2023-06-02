using DTOs.TokenDtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YallaKora.MVC.Repository.IRepository;
using YallaKora.MVC.Settings;

namespace YallaKora.MVC.Repository
{
    public class AppRepository : IAppRepository
    {
        private readonly IHttpClientFactory _ClientFactory;
        public AppRepository(IHttpClientFactory ClientFactory)
        {
            _ClientFactory = ClientFactory;
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
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> AppTokenValidationAsync(string Url ,string Token)
        {
            var Request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Url),
            };

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
