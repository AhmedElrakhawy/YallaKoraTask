using DTOs.ApplicationDtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace YallaKora.Web.VM
{
    public class EditTournamentVM
    {
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public string Description { get; set; }
        public string TournamentVideo { get; set; }
        public string Logo { get; set; }
        public List<SelectListItem> Teams { get; set; }
        public int[] TeamsIds { get; set; }
    }
}
