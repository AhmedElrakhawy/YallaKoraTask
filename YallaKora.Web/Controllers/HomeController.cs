using DTOs.UserDtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using YallaKora.Web.Repository.IRepository;
using YallaKora.Web.Settings;
using Microsoft.Extensions.Configuration;
using YallaKora.Web.Filters;
using Microsoft.AspNetCore.Authorization;

namespace YallaKora.Web.Controllers
{
    [ServiceFilter(typeof(CustomFilter))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountRepository _AccountRepository;
        public HomeController(ILogger<HomeController> logger, IAccountRepository accountRepository ) 
        {
            _logger = logger;
            _AccountRepository = accountRepository;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            var User = new UserDto();
            return View(User);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserDto user)
        {
            var UserObj = await _AccountRepository.LoginAsync(SD.AccountApiPath + "Authenticate/", user);
            if (UserObj.Token == null)
                return View();

            var Identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            Identity.AddClaim(new Claim(ClaimTypes.Email, UserObj.Email));
            Identity.AddClaim(new Claim(ClaimTypes.Role, UserObj.Role));
            var Principal = new ClaimsPrincipal(Identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, Principal);
            HttpContext.Session.SetString("JwtToken", UserObj.Token);
            TempData["alert"] = "Welcome " + UserObj.Email;
            return RedirectToAction("Index");
        }
    }
}
