using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaKora.MVC.Repository.IRepository;
using YallaKora.MVC.Settings;

namespace YallaKora.MVC.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {

        }
        private readonly IAppRepository _appRepository;
        private readonly AppToken _appToken;
        private ApplicationSetting _appSetting;
        public BaseController(IAppRepository appRepository , AppToken appToken , ApplicationSetting appSetting)
        {
            _appRepository = appRepository;
            _appToken = appToken;
            _appSetting = appSetting;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var result = await _appRepository.AppTokenValidationAsync(SD.UrlBasePath + "/api/Clients/ValidateToken", _appToken.Token);

            if (result)
                await next();
            else
            {
                result = await _appRepository.AppTokenGenerateAsync(SD.UrlBasePath + "/api/Clients/ValidateToken", _appSetting);
                if (result)
                    await next();
                else
                {
                    context.Result = new BadRequestObjectResult("UnAuthorized App !");
                }
            }
                
        }
    }
}
