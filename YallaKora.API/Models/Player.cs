using System;
using System.Collections.Generic;

#nullable disable

namespace YallaKora.API.Models
{
    public partial class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int? Age { get; set; }
        public int? TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
