using DTOs.ApplicationDtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using YallaKora.Web.Repository.IRepository;

namespace YallaKora.Web.Repository
{
    public class TournamentsRepository : Repository<TournamentDto>, ITournamentsRepository
    {
        private readonly IHttpClientFactory _Client;
        private readonly IConfiguration _Config;

        public TournamentsRepository(IHttpClientFactory ClientFactory , IConfiguration configuration) : base(ClientFactory , configuration)
        {
            _Client = ClientFactory;
            _Config = configuration;
        }
    }
}
