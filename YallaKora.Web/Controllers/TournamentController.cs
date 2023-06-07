using DTOs;
using DTOs.ApplicationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaKora.Web.Filters;
using YallaKora.Web.Healpers;
using YallaKora.Web.Repository.IRepository;
using YallaKora.Web.VM;

namespace YallaKora.Web.Controllers
{
    [ServiceFilter(typeof(CustomFilter))]
    [Authorize(Roles ="Admin")]
    public class TournamentController : Controller
    {
        private readonly ITournamentsRepository _TourR;
        private readonly ITeamsRepository _TR;

        public TournamentController(ITournamentsRepository TourR, ITeamsRepository TR)
        {
            _TourR = TourR;
            _TR = TR;
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

            Model.Tournaments = await _TourR.FilterTournament(SD.TournamentsApiPath + "FilterTournaments", Model.Search, token);
            var tours = await _TourR.GetAllAsync(SD.TournamentsApiPath + "GetAllTournaments", token);
            var TournamentsCount = tours.Count();

            Model.Pager = new Pager(TournamentsCount, PageNum, 5);

            if (FeatchAjaxRequest.IsAjaxRequest(Request))
            {
                return PartialView("TournamentsTable", Model);
            }
            return View(Model);
        }

        [HttpGet("CreateTournament")]
        public IActionResult CreateTournament()
        {
            return PartialView();
        }

        [HttpPost("CreateTournament")]
        public async Task<JsonResult> CreateTournament(TournamentDto tour)
        {
            try
            {
                var token = HttpContext.Session.GetString("JwtToken");
                var result = await _TourR.CreateAsync(SD.TournamentsApiPath + "CreateTournament", tour, token);

                return Json(result);
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet("EditTournament")]
        public async Task<IActionResult> EditTournament(int Id)
        {
            var token = HttpContext.Session.GetString("JwtToken");
            var tour = await _TourR.GetAsync(SD.TournamentsApiPath, Id, token);

            return PartialView(tour);
        }

        [HttpPost("EditTournament")]
        public async Task<JsonResult> EditTournament(TournamentDto tour)
        {
            try
            {
                var token = HttpContext.Session.GetString("JwtToken");
                var result = await _TourR.UpdateAsync(SD.TournamentsApiPath + tour.TournamentId, tour, token);

                return Json(result);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("DeleteTournament")]
        public async Task<JsonResult> DeleteTournament(int Id)
        {
            try
            {
                var token = HttpContext.Session.GetString("JwtToken");
                var result = await _TourR.DeleteAsync(SD.TournamentsApiPath, Id, token);

                return Json(result);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("AssignTeams")]
        public async Task<IActionResult> AssignTeams(int Id)
        {
            try
            {
                var Model = new AssignTeamVM();
                Model.AvailableTeams = new List<AvailableTeamsVM>();
                Model.AssignedTeams = new List<AvailableTeamsVM>();

                Model.TournamentId = Id;


                var teamDtos = await _TR.GetTeamsByTournamentId(SD.TeamsApiPath + "GetTeamsByTournamentId/", Id, "");
                foreach (var team in teamDtos)
                {
                    Model.AssignedTeams.Add(new AvailableTeamsVM()
                    {
                        TeamId = team.TeamId,
                        TeamName = team.TeamName
                    });
                }

                var AvailableTeams = await _TR.GetAvailableTeamsBasedOnTournamentId(SD.TeamsApiPath + "GetAvailableTeamsBasedOnTournamentId/", Id, "");

                foreach (var team in AvailableTeams)
                {
                    Model.AvailableTeams.Add(new AvailableTeamsVM()
                    {
                        TeamId = team.TeamId,
                        TeamName = team.TeamName
                    });
                }


                return PartialView(Model);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost("AssignTeams")]
        public async Task<IActionResult> AssignTeams(TournamentsTeamsDto tourTeamDto)
        {
            var result = await _TourR.AssignTournamentTeam(SD.TournamentsApiPath + "AssignTeams", tourTeamDto, "");

            return RedirectToAction("AssignTeams", new { Id = tourTeamDto.TournamentId });
        }

        [HttpPost("DeleteAssignTeam")]
        public async Task<IActionResult> DeleteAssignTeam(int TournamentId ,  int TeamId)
        {
            var tourTeamDto = new TournamentsTeamsDto()
            {
                TeamId = TeamId,
                TournamentId = TournamentId
            };
            var result = await _TourR.DeleteAssignTeam(SD.TournamentsApiPath + "DeleteAssignTeam", tourTeamDto, "");

            return RedirectToAction("AssignTeams", new { Id = tourTeamDto.TournamentId });
        }
        [HttpGet("AddTournamentGalary")]
        public IActionResult AddTournamentGalary(int TournamentId)
        {
            
            return PartialView(TournamentId);
        }
        [HttpPost("AddTournamentGalary")]
        public async Task<IActionResult> AddTournamentGalaryAsync(List<string> Images , int TournamentId)
        {
            var result = false;
            if (Images.Count() > 0)
            {
                var Model = new GallaryVM()
                {
                    TournamentId = TournamentId,
                    Images = Images
                };
                 result = await _TourR.AddTournamentGalary(SD.TournamentsApiPath + "AddTournamentGalary", Model, "");
            }
            return Json(result);
        }
    }
}
