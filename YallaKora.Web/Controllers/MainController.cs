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
    public class MainController : Controller
    {
        private readonly ITeamsRepository _TR;
        private readonly ITournamentsRepository _TourR;
        public MainController(ITeamsRepository TR, ITournamentsRepository TourR)
        {
            _TR = TR;
            _TourR = TourR;
        }
        [HttpGet("Index")]
        public async Task<IActionResult> IndexAsync(int? tourId)
        {
            var Model = new MainIndexVM();

            Model.TournamentId = tourId.HasValue ? tourId.Value : 1;

            Model.teamsDtos = await _TR.GetTeamsByTournamentId(SD.TeamsApiPath + "GetTeamsByTournamentId/", Model.TournamentId, "");
            Model.TournamentsDtos =  await _TourR.GetAllAsync(SD.TournamentsApiPath + "GetAllTournaments", "");
            Model.Tournament = await _TourR.GetAsync(SD.TournamentsApiPath, Model.TournamentId, "");
            Model.GallaryPhotos = await _TourR.GetGallaryPhotos(SD.TournamentsApiPath + "GetGallaryPhotos/", Model.TournamentId ,  "");

            if (FeatchAjaxRequest.IsAjaxRequest(Request))
            {
                return PartialView("Index", Model);
            }

            return View(Model);
        }
    }
}
