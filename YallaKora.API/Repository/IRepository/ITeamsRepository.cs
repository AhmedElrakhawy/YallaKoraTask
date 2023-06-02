using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaKora.API.Models;

namespace YallaKora.API.Repository.IRepository
{
    public interface ITeamsRepository
    {
        List<Team> FilterTeams(SearchTerms search);
        List<Team> GetAllTeams();
        Team GetTeam(int id);
        Team GetTeam(string Name);

        int GetTeamTournamentId(int id);
        bool TeamExists(string Name);
        bool TeamExists(int id);
        bool CreateTeam(Team team);
        bool UpdateTeam(Team team);
        bool DeleteTeam(Team team);
        bool Save();
    }
}
