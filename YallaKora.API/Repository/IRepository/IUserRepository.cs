
using DTOs.UserDtos;

namespace YallaKora.API.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string Email);
        UserDto Authenticate(string Email, string Passward);
        UserDto Register(string Email, string Password);
    }
}
