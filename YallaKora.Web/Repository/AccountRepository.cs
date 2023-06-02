using DTOs.UserDtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YallaKora.Web.Repository.IRepository;
using YallaKora.Web.Settings;

namespace YallaKora.Web.Repository
{
    public class AccountRepository : Repository<UserDto>, IAccountRepository
    {
        private readonly IHttpClientFactory _ClientFactory;
        private readonly IConfiguration _Config;
        public AccountRepository(IHttpClientFactory ClientFactory , IConfiguration configuration , IOptions<AppToken> appToken) : base(ClientFactory , configuration)
        {
            _ClientFactory = ClientFactory;
            _Config = configuration;
        }

        public async Task<UserDto> LoginAsync(string Url, UserDto user)
        {
            var Request = new HttpRequestMessage(HttpMethod.Post, Url);
            if (user != null)
            {
                Request.Content = new StringContent(
                    JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var APIKey = _Config.GetSection("AppToken:Token").Value;
                Request.Headers.Add("Api-Key-Auth", APIKey);
            }
            else
            {
                return new UserDto();
            }
            var Client = _ClientFactory.CreateClient();
            var Response = await Client.SendAsync(Request);
            if (Response.StatusCode == HttpStatusCode.OK)
            {
                var jsonString = await Response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserDto>(jsonString);
            }
            else
            {
                return new UserDto();
            }
        }

        public async Task<bool> RegisterAsync(string Url, UserDto userToCreate)
        {
            var Request = new HttpRequestMessage(HttpMethod.Post, Url);
            if (userToCreate != null)
            {
                Request.Content = new StringContent(
                    JsonConvert.SerializeObject(userToCreate), Encoding.UTF8, "application/json");
                var APIKey = _Config.GetSection("AppToken:Token").Value;
                Request.Headers.Add("Api-Key-Auth", APIKey);
            }
            else
            {
                return false;
            }
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
