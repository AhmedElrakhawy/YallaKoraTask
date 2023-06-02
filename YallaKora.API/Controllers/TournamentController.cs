using AutoMapper;
using DTOs.ApplicationDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaKora.API.Repository.IRepository;

namespace YallaKora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournmentRepository _TourRepository;
        private readonly IMapper _Mapper;
        public TournamentController(ITournmentRepository TourRepository, IMapper mapper)
        {
            _TourRepository = TourRepository;
            _Mapper = mapper;
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
    }
}
