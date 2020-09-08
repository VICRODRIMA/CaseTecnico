using CaseTecnicoIt.Domain.Interfaces;
using CaseTecnicoIt.Domain.Models;
using CaseTecnicoIt.Infra.Data.Repositories.Statements;
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
        public async Task AtualizarFilme(Filmes film) => await ExecutarAtualizar(film);
        public async Task<Filmes> BuscaFilmePorNome(string nomeFilme)
                => await GetConnection().QueryFirstOrDefaultAsync<Filmes>("select * from filmes where nomeFilme = @nomeFilme", new { nomeFilme });

        public async Task<Filmes> BuscaFilmePorId(string id)
         => await GetConnection().QueryFirstOrDefaultAsync<Filmes>("select * from filmes where idFilme = @id", new { id });

        private async Task ExecutarRegistrar(Filmes film)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    await conn.ExecuteAsync(filmeStatement.Inserir,
                        new
                        {
                            
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

        private async Task ExecutarAtualizar(Filmes filme)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    
                    await conn.ExecuteAsync(filmeStatement.Atualizar,
                        new
                        {
                            filme.idFilme,
                            filme.nomeFilme,
                            filme.anoLancamento
                        });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Falha ao atualizar o cliente.");
                throw;
            }
        }
    }
}