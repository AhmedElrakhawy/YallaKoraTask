using DTOs;
using DTOs.ApplicationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaKora.Web.VM;

namespace YallaKora.Web.Repository.IRepository
{
    public interface ITournamentsRepository : IRepository<TournamentDto>
    {
        Task<List<TournamentDto>> FilterTournament(string URL, SearchTerms search, string token);
        Task<List<TournamentsTeamsDto>> GetTournamentTeams(string URL, string token);
        Task<bool> AssignTournamentTeam(string Url, TournamentsTeamsDto ObjToAdd, string token);
        Task<bool> DeleteAssignTeam(string Url, TournamentsTeamsDto ObjToAdd, string token);
        Task<bool> AddTournamentGalary(string Url, GallaryVM ObjToAdd, string token);
        Task<List<string>> GetGallaryPhotos(string Url, int Id, string token);
    }
}
