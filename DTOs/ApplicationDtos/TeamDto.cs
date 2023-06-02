using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.ApplicationDtos
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string Description { get; set; }
        public string WebSiteURL { get; set; }
        public string Logo { get; set; }
        public string FoundationDate { get; set; }
        public int TournamentId { get; set; }
    }
}
