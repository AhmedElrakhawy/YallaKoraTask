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
using YallaKora.Web.VM;

namespace YallaKora.Web.Repository
{
    public class TournamentsRepository : Repository<TournamentDto>, ITournamentsRepository
    {
        private readonly IHttpClientFactory _Client;
        private readonly IConfiguration _Config;

        public TournamentsRepository(IHttpClientFactory ClientFactory , IConfiguration configuration) : base(ClientFactory , configuration)
        {
            _Client = ClientFactory;
            _Config = configuration;
        }
        public async Task<List<TournamentDto>> FilterTournament(string URL, SearchTerms search, string token)
        {
            var Request = new HttpRequestMessage(HttpMethod.Get, URL);
            var Client = _Client.CreateClient();
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
                return JsonConvert.DeserializeObject<List<TournamentDto>>(JsonString);
            }
            else
            {
                return null;
            }
        }

        public async Task<List<TournamentsTeamsDto>> GetTournamentTeams(string URL, string token)
        {
            var Request = new HttpRequestMessage(HttpMethod.Get, URL);
            var Client = _Client.CreateClient();
            //if (token != null && token.Length > 0)
            //{

            //}
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var APIToken = _Config.GetSection("AppToken:Token").Value;
            Request.Headers.Add("Api-Key-Auth", APIToken);
            var Response = await Client.SendAsync(Request);
            if (Response.StatusCode == HttpStatusCode.OK)
            {
                var JsonString = await Response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TournamentsTeamsDto>>(JsonString);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> AssignTournamentTeam(string Url, TournamentsTeamsDto ObjToAdd, string token)
        {
            var Request = new HttpRequestMessage(HttpMethod.Post, Url);
            if (ObjToAdd != null)
            {
                Request.Content = new StringContent(
                    JsonConvert.SerializeObject(ObjToAdd), Encoding.UTF8, "application/json");
                var APIToken = _Config.GetSection("AppToken:Token").Value;
                Request.Headers.Add("Api-Key-Auth", APIToken);
            }
            var Client = _Client.CreateClient();
            //if (token != null && token.Length > 0)
            //{
            //}
            //Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage Response = await Client.SendAsync(Request);
            if (Response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteAssignTeam(string Url, TournamentsTeamsDto ObjToAdd, string token)
        {
            var Request = new HttpRequestMessage(HttpMethod.Post, Url);
            if (ObjToAdd != null)
            {
                Request.Content = new StringContent(
                    JsonConvert.SerializeObject(ObjToAdd), Encoding.UTF8, "application/json");
                var APIToken = _Config.GetSection("AppToken:Token").Value;
                Request.Headers.Add("Api-Key-Auth", APIToken);
            }
            var Client = _Client.CreateClient();
            //if (token != null && token.Length > 0)
            //{
            //}
            //Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage Response = await Client.SendAsync(Request);
            if (Response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> AddTournamentGalary(string Url, GallaryVM ObjToAdd, string token)
        {
            var Request = new HttpRequestMessage(HttpMethod.Post, Url);
            if (ObjToAdd != null)
            {
                Request.Content = new StringContent(
                    JsonConvert.SerializeObject(ObjToAdd), Encoding.UTF8, "application/json");
                var APIToken = _Config.GetSection("AppToken:Token").Value;
                Request.Headers.Add("Api-Key-Auth", APIToken);
            }
            var Client = _Client.CreateClient();
            //if (token != null && token.Length > 0)
            //{
            //}
            //Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage Response = await Client.SendAsync(Request);
            if (Response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<String>> GetGallaryPhotos(string Url, int Id, string token)
        {
            var Request = new HttpRequestMessage(HttpMethod.Get, Url + Id);
            var Client = _Client.CreateClient();
            //if (token != null && token.Length > 0)
            //{

            //}
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var APIToken = _Config.GetSection("AppToken:Token").Value;
            Request.Headers.Add("Api-Key-Auth", APIToken);
            var Response = await Client.SendAsync(Request);
            if (Response.StatusCode == HttpStatusCode.OK)
            {
                var JsonString = await Response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<string>>(JsonString);
            }
            else
            {
                return null;
            }
        }
    }
}
