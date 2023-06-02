using DTOs.TokenDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaKora.MVC.Settings;

namespace YallaKora.MVC.Repository.IRepository
{
    public interface IAppRepository
    {
        Task<bool> AppTokenValidationAsync(string Url, string Token);
        Task<bool> AppTokenGenerateAsync(string Url, ApplicationSetting appSetting);
    }
}
