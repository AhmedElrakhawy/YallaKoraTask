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
            CreateMap<Team, TeamDto>().ReverseMap();
            CreateMap<Tournament, TournamentDto>().ReverseMap();
        }
    }
}
