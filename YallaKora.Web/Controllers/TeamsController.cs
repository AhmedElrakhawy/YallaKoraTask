using DTOs;
using DTOs.ApplicationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using YallaKora.Web.Filters;
using YallaKora.Web.Healpers;
using YallaKora.Web.Repository.IRepository;
using YallaKora.Web.VM;

namespace YallaKora.Web.Controllers
{
    [ServiceFilter(typeof(CustomFilter))]
    [Authorize(Roles = "Admin")]
    public class TeamsController : Controller
    {
        private readonly ITeamsRepository _TR;
        private readonly ITournamentsRepository _TourR;

        public TeamsController(ITeamsRepository TR, ITournamentsRepository TourR)
        {
            _TR = TR;
            _TourR = TourR;
        }
        [Authorize(Roles ="Admin")]

        public async Task<IActionResult> Index(int? TourId, int? PageNum, string Search)
        {
            var token = HttpContext.Session.GetString("JwtToken");
            var Model = new TeamsTableVM();
            Model.Search = new SearchTerms();
            if (TourId.HasValue)
                Model.Search.Id = TourId.Value;
            if (!string.IsNullOrEmpty(Search))
                Model.Search.SearchName = Search;

            PageNum = PageNum.HasValue ? PageNum.Value : 1;
            Model.Search.PageNum = PageNum;

            Model.Teams = await _TR.FilterTeams(SD.TeamsApiPath + "FilterTeams", Model.Search, token);


            Model.Tournaments = await _TourR.GetAllAsync(SD.TournamentsApiPath + "GetAllTournaments", token);
            var Teams = await _TR.GetAllAsync(SD.TeamsApiPath + "GetAllTeams", token);
            var TeamCount = Teams.Count();

            Model.Pager = new Pager(TeamCount, PageNum, 5);

            if (FeatchAjaxRequest.IsAjaxRequest(Request))
            {
                return PartialView("TeamsTable", Model);
            }
            return View(Model);
        }



        [HttpGet("CreateTeam")]
        public async Task<IActionResult> CreateTeam()
        {
            var token = HttpContext.Session.GetString("JwtToken");
            var Model = new CreateTeamVM();
            Model.Tournaments = await _TourR.GetAllAsync(SD.TournamentsApiPath + "GetAllTournaments", token);
            return PartialView(Model);
        }

        [HttpPost("CreateTeam")]
        public async Task<JsonResult> CreateTeam(TeamDto team)
        {
            try
            {
                var token = HttpContext.Session.GetString("JwtToken");
                var result = await _TR.CreateAsync(SD.TeamsApiPath + "CreateTeam", team, token);

                return Json(result);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("EditTeam")]
        public async Task<IActionResult> EditTeam(int Id)
        {
            var token = HttpContext.Session.GetString("JwtToken");
            var Model = new CreateTeamVM();
            var team = await _TR.GetAsync(SD.TeamsApiPath, Id, token);
            if (team != null)
            {
                Model.TeamId = team.TeamId;
                Model.TeamName = team.TeamName;
                Model.WebSiteURL = team.WebSiteURL;
                Model.TournamentId = team.TournamentId;
                Model.Logo = team.Logo;
                Model.FoundationDate = team.FoundationDate;
                Model.Description = team.Description;
            }


            Model.Tournaments = await _TourR.GetAllAsync(SD.TournamentsApiPath + "GetAllTournaments", token);
            return PartialView(Model);
        }

        [HttpPost("EditTeam")]
        public async Task<JsonResult> EditTeam(TeamDto team)
        {
            try
            {
                var token = HttpContext.Session.GetString("JwtToken");
                var result = await _TR.UpdateAsync(SD.TeamsApiPath + team.TeamId, team, token);

                return Json(result);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("DeleteTeam")]
        public async Task<JsonResult> DeleteTeam(int Id)
        {
            try
            {
                var token = HttpContext.Session.GetString("JwtToken");
                var result = await _TR.DeleteAsync(SD.TeamsApiPath , Id, token);

                return Json(result);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
