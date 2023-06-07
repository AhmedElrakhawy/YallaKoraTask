using DTOs.ApplicationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YallaKora.Web.VM
{
    public class MainIndexVM
    {
        public List<TeamDto> teamsDtos { get; set; }
        public List<TournamentDto> TournamentsDtos { get; set; }
        public int TournamentId { get; set; }
        public TournamentDto Tournament { get; set; }
        public List<string> GallaryPhotos { get; set; }
    }
}
