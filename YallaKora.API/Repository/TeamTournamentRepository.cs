using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaKora.API.Models;
using YallaKora.API.Repository.IRepository;

namespace YallaKora.API.Repository
{
    public class TeamTournamentRepository : ITeamTournamentRepository
    {
        private readonly YallaKoraSystemContext _DB;
        public TeamTournamentRepository(YallaKoraSystemContext DB)
        {
            _DB = DB;
        }
        public bool Creat(TournamentsTeam tournamentsTeam)
        {
            _DB.TournamentsTeams.Add(tournamentsTeam);
            return _DB.SaveChanges() > 0; 
        }

        public List<TournamentsTeam> GetTournamentTeams(int Id)
        {
            if (Id > 0)
                return _DB.TournamentsTeams.Where(x => x.TournamentId == Id).ToList();
            else
                return null;
        }

        public bool AssignTourTeamsTeams(TournamentsTeam tournamentsTeam)
        {
            if (tournamentsTeam != null)
            {
                if (_DB.TournamentsTeams.Any(x => x.TeamId == tournamentsTeam.TeamId && x.TournamentId == tournamentsTeam.TournamentId))
                {
                    return false;
                }
                 _DB.TournamentsTeams.Add(tournamentsTeam);
                return _DB.SaveChanges() > 0;
            }
            return false;
        }

        public bool DeleteAssignTeam(TournamentsTeam tournamentsTeam)
        {
            if (tournamentsTeam != null)
            {
                var entity = _DB.TournamentsTeams.FirstOrDefault(x => x.TeamId == tournamentsTeam.TeamId && x.TournamentId == tournamentsTeam.TournamentId);
                _DB.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                return _DB.SaveChanges() > 0;
            }
            return false;
        }
    }
}
