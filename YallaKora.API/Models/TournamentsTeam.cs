using System;
using System.Collections.Generic;

#nullable disable

namespace YallaKora.API.Models
{
    public partial class TournamentsTeam
    {
        public int TournamentsTeamsId { get; set; }
        public int? TournamentId { get; set; }
        public int? TeamId { get; set; }

        public virtual Team Team { get; set; }
        public virtual Tournament Tournament { get; set; }
    }
}
