using CaseTecnicoIt.Domain.Interfaces;
using CaseTecnicoIt.Domain.Models;
using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Infra.Data.Repositories
{
    public class FilmesRepository : Repository, IFilmesRepository
    {
        public FilmesRepository(ILoggerFactory logger, IOptions<ConnectionStringOptions> connectionString)
            : base(logger.CreateLogger<FilmesRepository>(), connectionString)
        {
        }
        public async Task CriarFilme(Filmes film) => await ExecutarRegistrar(film);
        public async Task<Filmes> BuscaFilmePorId(string id)
         => await GetConnection().QueryFirstOrDefaultAsync<Filmes>("select * from filmes where idFilme = @id", new { id });

        private async Task ExecutarRegistrar(Filmes film)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    await conn.ExecuteAsync("",
                        new
                        {
                            film.idFilme,
                            film.nomeFilme,
                            film.anoLancamento
                        });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Falha ao criar o filme");
                throw;
            }
        }

    }
}