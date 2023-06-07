using System.Collections.Generic;
using System.Threading.Tasks;

namespace YallaKora.Web.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(string Url, int Id, string token);
        Task<List<T>> GetAllAsync(string Url, string token);
        Task<bool> CreateAsync(string Url, T ObjToCreate, string token);
        Task<bool> UpdateAsync(string Url, T ObjToUpdate, string token);
        Task<bool> DeleteAsync(string Url, int Id, string token);
        Task<List<T>> GetTeamsByTournamentId(string Url, int Id, string token);
        Task<List<T>> GetAvailableTeamsBasedOnTournamentId(string Url, int Id, string token);

    }
}
