using DTOs;
using DTOs.ApplicationDtos;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using YallaKora.Web.Repository.IRepository;

namespace YallaKora.Web.Repository
{
    public class TeamsRepository : Repository<TeamDto>, ITeamsRepository
    {
        private readonly IHttpClientFactory _ClientFactory;
        private readonly IConfiguration _Config;

        public TeamsRepository(IHttpClientFactory ClientFactory, IConfiguration configuration) : base(ClientFactory, configuration)
        {
            _ClientFactory = ClientFactory;
            _Config = configuration;
        }

        public async Task<List<TeamDto>> FilterTeams(string URL, SearchTerms search, string token)
        {
            var Request = new HttpRequestMessage(HttpMethod.Get, URL);
            var Client = _ClientFactory.CreateClient();
            //if (token != null && token.Length > 0)
            //{

            //}

            
            var obj = new StringContent(
                  JsonConvert.SerializeObject(search), Encoding.UTF8, "application/json");
            Request.Content = obj;
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var APIToken = _Config.GetSection("AppToken:Token").Value;
            Request.Headers.Add("Api-Key-Auth", APIToken);

            var Response = await Client.SendAsync(Request);
            if (Response.StatusCode == HttpStatusCode.OK)
            {
                var JsonString = await Response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TeamDto>>(JsonString);
            }
            else
            {
                return null;
            }
        }
    }
}
