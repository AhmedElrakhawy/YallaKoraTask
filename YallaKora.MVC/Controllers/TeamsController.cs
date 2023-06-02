using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YallaKora.MVC.Controllers
{
    public class TeamsController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
