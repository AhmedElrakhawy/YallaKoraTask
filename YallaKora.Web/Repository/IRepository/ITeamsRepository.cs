using DTOs;
using DTOs.ApplicationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YallaKora.Web.Repository.IRepository
{
    public interface ITeamsRepository : IRepository<TeamDto>
    {
        Task<List<TeamDto>> FilterTeams(string URL , SearchTerms search , string token);
    }
}
