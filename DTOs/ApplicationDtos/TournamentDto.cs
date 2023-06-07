using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.ApplicationDtos
{
    public class TournamentDto
    {
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public string Description { get; set; }
        public string TournamentVideo { get; set; }
        public string Logo { get; set; }
        public int[] TeamsIds { get; set; }
    }
}
