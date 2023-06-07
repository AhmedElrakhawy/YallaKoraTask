using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YallaKora.Web.VM
{
    public class AssignTeamVM
    {
        public List<AvailableTeamsVM> AvailableTeams { get; set; }
        public List<AvailableTeamsVM> AssignedTeams { get; set; }
        public int TournamentId { get; set; }
    }
}
