using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace YallaKora.API.Models
{
    [Table("Player")]
    public partial class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [StringLength(100)]
        public string PlayerName { get; set; }
        public int? Age { get; set; }
        public int? TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        [InverseProperty("Players")]
        public virtual Team Team { get; set; }
    }
}
