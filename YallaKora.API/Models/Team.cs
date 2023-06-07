using System;
using System.Collections.Generic;

#nullable disable

namespace YallaKora.API.Models
{
    public partial class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
            TournamentsTeams = new HashSet<TournamentsTeam>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string Description { get; set; }
        public string WebsiteUrl { get; set; }
        public string Logo { get; set; }
        public string FoundationDate { get; set; }

        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<TournamentsTeam> TournamentsTeams { get; set; }
    }
}
