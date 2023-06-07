using DTOs.UserDtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using YallaKora.API.Models;
using YallaKora.API.Repository.IRepository;

namespace YallaKora.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly YallaKoraSystemContext _Db;
        private readonly AppSettings _appsetting;
        public UserRepository(YallaKoraSystemContext Db, IOptions<AppSettings> appsettings)
        {
            _Db = Db;
            _appsetting = appsettings.Value;
        }
        public UserDto Authenticate(string Email, string Passward)
        {
            var user = _Db.UserMasters.Include(x => x.Role).FirstOrDefault(x => x.Email == Email && x.Password == Passward);
            if (user == null)
            {
                return null;
            }

            var TokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(_appsetting.Secret);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role,user.Role.RoleName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key)
                , SecurityAlgorithms.HmacSha256Signature)
            };
            var Token = TokenHandler.CreateToken(TokenDescriptor);
            var userDto = new UserDto()
            {
                Email = user.Email,
                Role = user.Role.RoleName,
                Token = TokenHandler.WriteToken(Token),
            };
            return userDto;
        }

        public bool IsUniqueUser(string Email)
        {
            var User = _Db.UserMasters.SingleOrDefault(x => x.Email == Email);
            if (User == null)
                return true;

            return false;
        }

        public UserDto Register(string Email, string Password)
        {
            var User = new UserMaster
            {
                Email = Email,
                Password = Password,
                RoleId = _Db.Roles.FirstOrDefault(x => x.RoleName == "Admin").RoleId
            };
            _Db.UserMasters.Add(User);
            _Db.SaveChanges();
            var userDto = new UserDto()
            {
                Email = User.Email,
                Role = User.Role.RoleName,
            };

            return userDto;
        }
    }
}
