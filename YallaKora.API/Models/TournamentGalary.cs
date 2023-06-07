using System;
using System.Collections.Generic;

#nullable disable

namespace YallaKora.API.Models
{
    public partial class TournamentGalary
    {
        public int TournamentGalaryId { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public int? TournamentId { get; set; }

        public virtual Tournament Tournament { get; set; }
    }
}
