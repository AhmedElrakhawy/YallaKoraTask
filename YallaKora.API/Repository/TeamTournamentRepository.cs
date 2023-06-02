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
        private readonly YallaKoraSystemDbContext _DB;
        public TeamTournamentRepository(YallaKoraSystemDbContext DB)
        {
            _DB = DB;
        }
        public bool Creat(TournamentsTeam tournamentsTeam)
        {
            _DB.TournamentsTeams.Add(tournamentsTeam);
            return _DB.SaveChanges() > 0; 
        }
    }
}
