using DTOs.UserDtos;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YallaKora.MVC.Repository.IRepository;

namespace YallaKora.MVC.Repository
{
    public class AccountRepository : Repository<UserDto>, IAccountRepository
    {
        private readonly IHttpClientFactory _ClientFactory;
        public AccountRepository(IHttpClientFactory ClientFactory) : base(ClientFactory)
        {
            _ClientFactory = ClientFactory;
        }

        public async Task<UserDto> LoginAsync(string Url, UserDto user)
        {
            var Request = new HttpRequestMessage(HttpMethod.Post, Url);
            if (user != null)
            {
                Request.Content = new StringContent(
                    JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
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
