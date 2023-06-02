using DTOs.ApplicationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YallaKora.Web.VM
{
    public class CreateTeamVM
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string Description { get; set; }
        public string WebSiteURL { get; set; }
        public string FoundationDate { get; set; }
        public string Logo { get; set; }
        public int TournamentId { get; set; }
        public List<TournamentDto> Tournaments { get; set; }
    }
}
