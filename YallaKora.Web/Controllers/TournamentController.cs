using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaKora.Web.Healpers;
using YallaKora.Web.Repository.IRepository;
using YallaKora.Web.VM;

namespace YallaKora.Web.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ITournamentsRepository _TourR;

        public TournamentController(ITournamentsRepository TourR)
        {
            _TourR = TourR;
        }

        public async Task<IActionResult> Index(int? PageNum, string Search)
        {
            var token = HttpContext.Session.GetString("JwtToken");
            var Model = new TournamentsTableVM();
            Model.Search = new SearchTerms();

            if (!string.IsNullOrEmpty(Search))
                Model.Search.SearchName = Search;

            PageNum = PageNum.HasValue ? PageNum.Value : 1;
            Model.Search.PageNum = PageNum;

            Model.Tournaments = await _TourR.GetAllAsync(SD.TournamentsApiPath + "GetAllTournaments", token);

            Model.Pager = new Pager(Model.Tournaments.Count(), PageNum, 5);

            if (FeatchAjaxRequest.IsAjaxRequest(Request))
            {
                return PartialView("TeamsTable", Model);
            }
            return View(Model);
        }
    }
}
