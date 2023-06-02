using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace YallaKora.API.Models
{
    public partial class Tournament
    {
        public Tournament()
        {
            TournamentsTeams = new HashSet<TournamentsTeam>();
        }

        [Key]
        public int TournamentId { get; set; }
        [StringLength(100)]
        public string TournamentName { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(200)]
        public string TournamentVideo { get; set; }
        [StringLength(200)]
        public string Logo { get; set; }

        [InverseProperty(nameof(TournamentsTeam.Tournament))]
        public virtual ICollection<TournamentsTeam> TournamentsTeams { get; set; }
    }
}
