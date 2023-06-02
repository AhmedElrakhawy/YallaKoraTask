using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace YallaKora.API.Models
{
    [Table("Team")]
    public partial class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
            TournamentsTeams = new HashSet<TournamentsTeam>();
        }

        [Key]
        public int TeamId { get; set; }
        [StringLength(100)]
        public string TeamName { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Column("WebsiteURL")]
        [StringLength(100)]
        public string WebsiteUrl { get; set; }
        [StringLength(200)]
        public string Logo { get; set; }
        public string FoundationDate { get; set; }

        [InverseProperty(nameof(Player.Team))]
        public virtual ICollection<Player> Players { get; set; }
        [InverseProperty(nameof(TournamentsTeam.Team))]
        public virtual ICollection<TournamentsTeam> TournamentsTeams { get; set; }
    }
}
