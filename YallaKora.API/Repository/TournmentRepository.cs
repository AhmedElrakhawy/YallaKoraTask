using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaKora.API.Models;
using YallaKora.API.Repository.IRepository;

namespace YallaKora.API.Repository
{
    public class TournmentRepository : ITournmentRepository
    {
        private readonly YallaKoraSystemContext _DB;
        public TournmentRepository(YallaKoraSystemContext DB)
        {
            _DB = DB;
        }

        public bool AddTournamentGalary(TournamentGalary TG)
        {
            try
            {
                if (TG == null)
                    return false;
                else
                    _DB.TournamentGalaries.Add(TG);

                return Save();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CreateTournament(Tournament tournament)
        {
            try
            {
                if (tournament == null)
                    return false;
                else
                    _DB.Tournaments.Add(tournament);

                return Save();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteTournament(Tournament tournament)
        {
            try
            {
                if (tournament == null)
                    return false;
                else
                {
                    var teamtour = _DB.TournamentsTeams.Where(t => t.TournamentId == tournament.TournamentId);
                    if (teamtour != null)
                        _DB.TournamentsTeams.RemoveRange(teamtour);
                    _DB.Tournaments.Remove(tournament);
                }

                return Save();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Tournament> FilterTournaments(SearchTerms search)
        {
            try
            {
                var Touranments = _DB.Tournaments.AsEnumerable();

                if (!string.IsNullOrEmpty(search.SearchName))
                {
                    Touranments = Touranments.Where(x => x.TournamentName.ToLower().Contains(search.SearchName.ToLower()));
                }
                int SkipCount = (search.PageNum.Value - 1) * 5;

                return Touranments.Skip(SkipCount).Take(5).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Tournament> GetAllTournaments()
        {
            try
            {
                return _DB.Tournaments.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public TournamentGalary GetGallaryPhotos(int TournamentId)
        {
            try
            {
                return _DB.TournamentGalaries.Where(x => x.TournamentId == TournamentId).FirstOrDefault();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Tournament GetTournament(int id)
        {
            try
            {
                if (id <= 0)
                    return null;
                else
                    return _DB.Tournaments.FirstOrDefault(x => x.TournamentId == id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Save()
        {
            return _DB.SaveChanges() > 0;
        }

        public bool TournamentExists(string Name)
        {
            try
            {
                if (string.IsNullOrEmpty(Name))
                    return false;
                else
                    return _DB.Tournaments.Any(x => x.TournamentName == Name);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool TournamentExists(int id)
        {
            try
            {
                if (id > 0)
                    return false;
                else
                    return _DB.Tournaments.Any(x => x.TournamentId == id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateTournament(Tournament tournament)
        {
            try
            {
                if (tournament == null)
                    return false;
                else
                    _DB.Tournaments.Update(tournament);

                return Save();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
 }
