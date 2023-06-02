using DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaKora.API.Models;
using YallaKora.API.Repository.IRepository;

namespace YallaKora.API.Repository
{
    public class TeamRepository : ITeamsRepository
    {
        private readonly YallaKoraSystemDbContext _DB;
        public TeamRepository(YallaKoraSystemDbContext DB)
        {
            _DB = DB;
        }
        public bool CreateTeam(Team team)
        {
            try
            {
                if (team == null)
                    return false;
                else
                {
                    _DB.Teams.Add(team);
                }
                return Save();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteTeam(Team team)
        {
            try
            {
                if (team == null)
                    return false;
                else
                    _DB.Teams.Remove(team);

                return Save();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Team> FilterTeams(SearchTerms search)
        {
            try
            {
                var Teams = _DB.Teams.AsEnumerable();
                if (search.Id.HasValue)
                {
                    var teamsIds = _DB.TournamentsTeams.Where(x => x.TournamentId == search.Id).Select(i => i.TeamId);
                    foreach (var teamId in teamsIds)
                    {
                        Teams = Teams.Where(x => x.TeamId == teamId);
                    }
                }
                if (!string.IsNullOrEmpty(search.SearchName))
                {
                    Teams = Teams.Where(x => x.TeamName.ToLower().Contains(search.SearchName.ToLower()));
                }
                int SkipCount = (search.PageNum.Value - 1) * 5;

                return Teams.Skip(SkipCount).Take(5).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Team> GetAllTeams()
        {
            try
            {
               return _DB.Teams.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Team GetTeam(int id)
        {
            try
            {
                if (id <= 0)
                    return null;
                else
                    return _DB.Teams.FirstOrDefault(x => x.TeamId == id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Team GetTeam(string Name)
        {
            try
            {
                if (Name != null)
                    return null;
                else
                    return _DB.Teams.FirstOrDefault(x => x.TeamName == Name);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetTeamTournamentId(int id)
        {
            try
            {
                if (id <= 0)
                    return 0;
                else
                    return _DB.TournamentsTeams.FirstOrDefault(x => x.TeamId == id).TournamentId.Value;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Save()
        {
            return _DB.SaveChanges() > 0;
        }

        public bool TeamExists(string Name)
        {
            try
            {
                if (string.IsNullOrEmpty(Name))
                    return false;
                else
                    return _DB.Teams.Any(x => x.TeamName == Name);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool TeamExists(int id)
        {
            try
            {
                if (id <= 0)
                    return false;
                else
                    return _DB.Teams.Any(x => x.TeamId == id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateTeam(Team team)
        {
            try
            {
                if (team == null)
                    return false;
                else
                    _DB.Teams.Update(team);

                return Save();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
