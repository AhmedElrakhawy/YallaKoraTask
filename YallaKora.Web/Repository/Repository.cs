using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using YallaKora.Web.Repository.IRepository;

namespace YallaKora.Web.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IHttpClientFactory _ClientFactory;
        private readonly IConfiguration _Config;
        public Repository(IHttpClientFactory ClientFactory , IConfiguration configuration)
        {
            _ClientFactory = ClientFactory;
            _Config = configuration;
        }
        public async Task<bool> CreateAsync(string Url, T ObjToCreate, string token = "")
        {
            var Request = new HttpRequestMessage(HttpMethod.Post, Url);
            if (ObjToCreate != null)
            {
                Request.Content = new StringContent(
                    JsonConvert.SerializeObject(ObjToCreate), Encoding.UTF8, "application/json");
                var APIToken = _Config.GetSection("AppToken:Token").Value;
                Request.Headers.Add("Api-Key-Auth", APIToken);
            }
            var Client = _ClientFactory.CreateClient();
            //if (token != null && token.Length > 0)
            //{
            //}
            //Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage Response = await Client.SendAsync(Request);
            if (Response.StatusCode == HttpStatusCode.Created)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string Url, int Id, string token = "")
        {
            var Request = new HttpRequestMessage(HttpMethod.Delete, Url + Id);
            var Client = _ClientFactory.CreateClient();
            if (token != null && token.Length > 0)
            {
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var APIToken = _Config.GetSection("AppToken:Token").Value;
                Request.Headers.Add("Api-Key-Auth", APIToken);
            }
            var Response = await Client.SendAsync(Request);
            if (Response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<T>> GetAllAsync(string Url, string token = "")
        {
            var Request = new HttpRequestMessage(HttpMethod.Get, Url);
            var Client = _ClientFactory.CreateClient();
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
                return JsonConvert.DeserializeObject<List<T>>(JsonString);
            }
            else
            {
                return null;
            }
        }

        public async Task<T> GetAsync(string Url, int Id, string token = "")
        {
            var Request = new HttpRequestMessage(HttpMethod.Get, Url + Id);
            var Client = _ClientFactory.CreateClient();
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
                return JsonConvert.DeserializeObject<T>(JsonString);
            }
            else
            {
                return null;
            }

        }

        public async Task<bool> UpdateAsync(string Url, T ObjToUpdate, string token = "")
        {
            var Request = new HttpRequestMessage(HttpMethod.Patch, Url);
            if (ObjToUpdate != null)
            {
                Request.Content = new StringContent(
                    JsonConvert.SerializeObject(ObjToUpdate), Encoding.UTF8, "application/json");
                var APIToken = _Config.GetSection("AppToken:Token").Value;
                Request.Headers.Add("Api-Key-Auth", APIToken);
            }
            else
            {
                return false;
            }
            var Client = _ClientFactory.CreateClient();
            if (token != null && token.Length > 0)
            {
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var APIToken = _Config.GetSection("AppToken:Token").Value;
                Request.Headers.Add("Api-Key-Auth", APIToken);
            }
            var Response = await Client.SendAsync(Request);
            if (Response.StatusCode == HttpStatusCode.NoContent)
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
