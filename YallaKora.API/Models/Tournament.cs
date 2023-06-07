using System;
using System.Collections.Generic;

#nullable disable

namespace YallaKora.API.Models
{
    public partial class Tournament
    {
        public Tournament()
        {
            TournamentGalaries = new HashSet<TournamentGalary>();
            TournamentsTeams = new HashSet<TournamentsTeam>();
        }

        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public string Description { get; set; }
        public string TournamentVideo { get; set; }
        public string Logo { get; set; }

        public virtual ICollection<TournamentGalary> TournamentGalaries { get; set; }
        public virtual ICollection<TournamentsTeam> TournamentsTeams { get; set; }
    }
}
