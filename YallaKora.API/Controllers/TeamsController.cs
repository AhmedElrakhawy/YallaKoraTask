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
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsRepository _TeamRepository;
        private readonly ITournmentRepository _tourRepository;
        private readonly ITeamTournamentRepository _teamTourRepository;
        private readonly IMapper _Mapper;
        public TeamsController(ITeamsRepository teamsRepository , IMapper mapper , ITournmentRepository tournmentRepository ,ITeamTournamentRepository teamTournamentRepository)
        {
            _TeamRepository = teamsRepository;
            _tourRepository = tournmentRepository;
            _Mapper = mapper;
            _teamTourRepository = teamTournamentRepository;
        }
        [HttpGet("FilterTeams")]
        public IActionResult FilterTeams([FromBody]SearchTerms search)
        {
            try
            {
                var TeamsList = _TeamRepository.FilterTeams(search);
                var TeamsDtoList = new List<TeamDto>();
                foreach (var team in TeamsList)
                    TeamsDtoList.Add(_Mapper.Map<TeamDto>(team));

                return Ok(TeamsDtoList);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("GetTeam/{Id}")]
        public IActionResult GetTeam(int Id)
        {
            if (Id <= 0)
                return BadRequest(ModelState);
            var team = _TeamRepository.GetTeam(Id);

            if (team == null)
            {
                return NotFound();
            }

            var teamDto = _Mapper.Map<TeamDto>(team);
            teamDto.TournamentId = _TeamRepository.GetTeamTournamentId(Id);
            
            return Ok(teamDto);
        }

        [HttpGet("GetAllTeams")]
        public IActionResult GetAllTeams()
        {
            var TeamsDto = new LinkedList<TeamDto>();
            var teams = _TeamRepository.GetAllTeams();
            if (teams != null)
            {
                foreach (var team in teams)
                    TeamsDto.AddFirst(_Mapper.Map<TeamDto>(team));

            }

            return Ok(TeamsDto);
        }
        [HttpGet("EditTeam")]
        public IActionResult EditTeam(TeamDto teamDto)
        {
            if (teamDto == null)
            {
                return NotFound();
            }

            var team = _Mapper.Map<TeamDto>(teamDto);

            return Ok(team);
        }
        [HttpPost("CreateTeam")]
        public IActionResult CreateTeam([FromBody] TeamDto teamDto)
        {
            if (teamDto == null)
                return BadRequest(ModelState);
            if (_TeamRepository.TeamExists(teamDto.TeamName))
            {
                ModelState.AddModelError("", "Team Is Exists");
                return StatusCode(404, ModelState);
            }

            var team = _Mapper.Map<Team>(teamDto);
            Tournament tr = _tourRepository.GetTournament(teamDto.TournamentId);
            TournamentsTeam tournamentsTeam = new TournamentsTeam();
            tournamentsTeam.TournamentId = tr.TournamentId;
            tournamentsTeam.TeamId = _TeamRepository.GetTeam(teamDto.TeamName).TeamId;
            _teamTourRepository.Creat(tournamentsTeam);
            if (!_TeamRepository.CreateTeam(team))
            {
                ModelState.AddModelError("", $"Something went wrong on saving {team.TeamName}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetTeam" , new {TeamId = team.TeamId });
        }
    }
}
