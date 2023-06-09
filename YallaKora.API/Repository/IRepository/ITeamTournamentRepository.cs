﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaKora.API.Models;

namespace YallaKora.API.Repository.IRepository
{
    public interface ITeamTournamentRepository
    {
        bool Creat(TournamentsTeam tournamentsTeam);
        List<TournamentsTeam> GetTournamentTeams(int Id);
        bool AssignTourTeamsTeams(TournamentsTeam tournamentsTeam);
        bool DeleteAssignTeam(TournamentsTeam tournamentsTeam);
    }
}
