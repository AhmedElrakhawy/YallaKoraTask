using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaKora.API.Models;

namespace YallaKora.API.Repository.IRepository
{
    public interface ITournmentRepository
    {
        List<Tournament> FilterTournaments(SearchTerms search);
        List<Tournament> GetAllTournaments();
        Tournament GetTournament(int id);
        bool TournamentExists(string Name);
        bool TournamentExists(int id);
        bool CreateTournament(Tournament tournament);
        bool UpdateTournament(Tournament tournament);
        bool DeleteTournament(Tournament tournament);
        bool AddTournamentGalary(TournamentGalary tournamentGalary);
        TournamentGalary GetGallaryPhotos(int TournamentId);
        bool Save();
    }
}
