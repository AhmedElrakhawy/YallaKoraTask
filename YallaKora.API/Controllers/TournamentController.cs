using AutoMapper;
using DTOs;
using DTOs.ApplicationDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaKora.API.Models;
using YallaKora.API.Repository.IRepository;

namespace YallaKora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournmentRepository _TourRepository;
        private readonly IMapper _Mapper;
        private readonly ITeamTournamentRepository _teamTourRepository;
        public TournamentController(ITournmentRepository TourRepository, IMapper mapper, ITeamTournamentRepository teamTournamentRepository)
        {
            _TourRepository = TourRepository;
            _Mapper = mapper;
            _teamTourRepository = teamTournamentRepository;
        }

        [HttpGet("GetAllTournaments")]
        public IActionResult GetAllTournaments()
        {
            try
            {
                var TournamentsList = _TourRepository.GetAllTournaments();
                var TournamentsDtoList = new List<TournamentDto>();
                foreach (var tournament in TournamentsList)
                    TournamentsDtoList.Add(_Mapper.Map<TournamentDto>(tournament));

                return Ok(TournamentsDtoList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("FilterTournaments")]
        public IActionResult FilterTournaments([FromBody] SearchTerms search)
        {
            try
            {
                var TournamentsList = _TourRepository.FilterTournaments(search);
                var TournamentsDtoList = new List<TournamentDto>();
                foreach (var tournament in TournamentsList)
                    TournamentsDtoList.Add(_Mapper.Map<TournamentDto>(tournament));

                return Ok(TournamentsDtoList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("CreateTournament")]
        public IActionResult CreateTournament([FromBody] TournamentDto tourDto)
        {
            if (tourDto == null)
                return BadRequest(ModelState);
            if (_TourRepository.TournamentExists(tourDto.TournamentName))
            {
                ModelState.AddModelError("", "Team Is Exists");
                return StatusCode(404, ModelState);
            }

            var tour = _Mapper.Map<Tournament>(tourDto);
            if (tourDto != null)
            {
                if (!_TourRepository.CreateTournament(tour))
                {
                    ModelState.AddModelError("", $"Something went wrong on saving {tourDto.TournamentName}");
                    return StatusCode(500, ModelState);
                }
            }
            else
            {
                ModelState.AddModelError("", $"Something went wrong on saving {tourDto.TournamentName}");
                return StatusCode(500, ModelState);
            }

            var link = Url.Link("GetTeam", new { Id = tour.TournamentId });
            return Created(link, null);

        }
        [HttpGet("{Id}", Name = "GetTournament")]
        public IActionResult GetTeam(int Id)
        {
            if (Id <= 0)
                return BadRequest(ModelState);
            var tour = _TourRepository.GetTournament(Id);

            if (tour == null)
            {
                return NotFound();
            }

            var tourDto = _Mapper.Map<Tournament>(tour);

            return Ok(tourDto);
        }
        [HttpDelete("{Id:int}", Name = "DeleteTournament")]
        public IActionResult DeleteTournament(int Id)
        {
            var tour = new Tournament();
            if (Id > 0)
                tour = _TourRepository.GetTournament(Id);

            if (tour != null)
            {
                if (!_TourRepository.DeleteTournament(tour))
                    return NotFound();
            }
            else
            {
                ModelState.AddModelError("", $"{tour.TournamentName} Tournament Not Found");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpGet("GetTournamentTeams")]
        public IActionResult GetTournamentTeams(int Id)
        {
            var tourTeamsDtoList = new List<TournamentsTeamsDto>();
            var tourteamslist = new List<TournamentsTeam>();
            if (Id > 0)
                tourteamslist = _teamTourRepository.GetTournamentTeams(Id);

            foreach (var tourTeam in tourteamslist)
                tourTeamsDtoList.Add(_Mapper.Map<TournamentsTeamsDto>(tourTeam));

            return Ok(tourTeamsDtoList);
        }

        [HttpPost("AssignTeams")]
        public IActionResult AssignTeams([FromBody] TournamentsTeamsDto tourTeamDto)
        {
            if (tourTeamDto != null)
            {
                var tourTeam = _Mapper.Map<TournamentsTeam>(tourTeamDto);
                var result = _teamTourRepository.AssignTourTeamsTeams(tourTeam);
                if (result)
                    return Ok();
            }


            return StatusCode(500, ModelState);
        }
        [HttpPost("DeleteAssignTeam")]
        public IActionResult DeleteAssignTeam([FromBody] TournamentsTeamsDto tourTeamDto)
        {
            if (tourTeamDto != null)
            {
                var tourTeam = _Mapper.Map<TournamentsTeam>(tourTeamDto);
                var result = _teamTourRepository.DeleteAssignTeam(tourTeam);
                if (result)
                    return Ok();
            }


            return StatusCode(500, ModelState);
        }

        [HttpPost("AddTournamentGalary")]
        public IActionResult AddTournamentGalary([FromBody] GallaryDto gallaryDto)
        {
            if (gallaryDto != null)
            {
                var tourGallary = new TournamentGalary()
                {
                    TournamentId = gallaryDto.TournamentId,
                    Image1 = gallaryDto.Images[0],
                    Image2 = gallaryDto.Images[1],
                    Image3 = gallaryDto.Images[2],
                };
                var result = _TourRepository.AddTournamentGalary(tourGallary);
                if (result)
                    return Ok();
            }


            return StatusCode(500, ModelState);
        }


        [HttpGet("GetGallaryPhotos/{Id}")]
        public IActionResult GetGallaryPhotos( int Id)
        {
            if (Id > 0)
            {
                var galary = new List<string>();
                var tourGallary = _TourRepository.GetGallaryPhotos(Id);
                if (tourGallary != null)
                {
                    galary.Add(tourGallary.Image1);
                    galary.Add(tourGallary.Image2);
                    galary.Add(tourGallary.Image3);
                }

                 return Ok(galary);
            }
            return StatusCode(500, ModelState);
        }
    }
}
