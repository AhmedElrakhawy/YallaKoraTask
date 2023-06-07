using AutoMapper;
using DTOs.ApplicationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaKora.API.Models;

namespace YallaKora.API.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Team, TeamDto>().ForMember(x => x.TournamentsTeamsDtos, m => m.MapFrom(a => a.TournamentsTeams)).ReverseMap();
            CreateMap<Tournament, TournamentDto>().ReverseMap();
            CreateMap<TournamentsTeam, TournamentsTeamsDto>().ReverseMap();
        }
    }
}
