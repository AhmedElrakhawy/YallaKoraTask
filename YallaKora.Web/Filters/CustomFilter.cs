using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using YallaKora.Web.Repository.IRepository;
using YallaKora.Web.Settings;

namespace YallaKora.Web.Filters
{
    public class CustomFilter : IAsyncActionFilter
    {
        private readonly IAppRepository _appRepository;
        private readonly AppToken _appToken;
        private ApplicationSetting _appSetting;
        public CustomFilter(IAppRepository appRepository, IOptions<AppToken> appToken, IOptions<ApplicationSetting> appSetting)
        {
            _appRepository = appRepository;
            _appToken = appToken.Value;
            _appSetting = appSetting.Value;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var Token = _appToken.Token;
            var result = await _appRepository.AppTokenValidationAsync(SD.UrlBasePath + "/api/Clients/ValidateToken", Token);

            if (result)
                await next();
            else
            {
                result = await _appRepository.AppTokenGenerateAsync(SD.UrlBasePath + "/api/Clients/GenerateToken", _appSetting);
                if (result)
                {

                    await next();
                }
                else
                {
                    context.Result = new BadRequestObjectResult("UnAuthorized App !");
                }
            }
        }
    }
}
