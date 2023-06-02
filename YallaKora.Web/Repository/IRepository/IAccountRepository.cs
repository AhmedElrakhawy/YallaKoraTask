using DTOs.UserDtos;
using System.Threading.Tasks;

namespace YallaKora.Web.Repository.IRepository
{
    public interface IAccountRepository : IRepository<UserDto>
    {
        Task<UserDto> LoginAsync(string Url, UserDto user);
        Task<bool> RegisterAsync(string Url, UserDto userToCreate);
    }
}
