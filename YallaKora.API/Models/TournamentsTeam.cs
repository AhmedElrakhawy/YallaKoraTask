using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace YallaKora.API.Models
{
    [Table("Tournaments_Teams")]
    public partial class TournamentsTeam
    {
        [Key]
        [Column("Tournaments_TeamsId")]
        public int TournamentsTeamsId { get; set; }
        public int? TournamentId { get; set; }
        public int? TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        [InverseProperty("TournamentsTeams")]
        public virtual Team Team { get; set; }
        [ForeignKey(nameof(TournamentId))]
        [InverseProperty("TournamentsTeams")]
        public virtual Tournament Tournament { get; set; }
    }
}
