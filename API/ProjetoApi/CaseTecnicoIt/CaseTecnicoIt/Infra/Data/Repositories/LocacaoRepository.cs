using CaseTecnicoIt.Domain.Interfaces;
using CaseTecnicoIt.Domain.Models;
using CaseTecnicoIt.Infra.Data.Repositories.Statements;
using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Infra.Data.Repositories
{
    public class LocacaoRepository : Repository, ILocacaoRepository
    {
        public LocacaoRepository(ILoggerFactory logger, IOptions<ConnectionStringOptions> connectionString)
            : base(logger.CreateLogger<LocacaoRepository>(), connectionString)
        {
        }
        public async Task criarLocacao(Locacao locacao) => await ExecutarRegistrar(locacao);
        public async Task<Locacao> buscaLocacaoID(string id)
         => await GetConnection().QueryFirstOrDefaultAsync<Locacao>("select * from Locacao where idLocacao = @id", new { id });


        public async Task AtualizaLocacao(Locacao client) => await ExecutarAtualizar(client);

        private async Task ExecutarAtualizar(Locacao client)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    //MoviesStatament.Atualizar
                    await conn.ExecuteAsync(locacaoStatement.Atualizar,
                        new
                        {
                            client.idLocacao,
                            client.dtDevolucao
                        });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Falha ao atualizar o cliente.");
                throw;
            }
        }


        private async Task ExecutarRegistrar(Locacao film)
        {
            try
            {
                using (var conn = GetConnection())
                {   
                    await conn.ExecuteAsync(locacaoStatement.Inserir,
                        new
                        {
                            film.idLocador,
                            film.idCliente,
                            film.idFilme,
                            film.dtLocacao,
                            film.dtDevolucao
                        });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Falha ao locar");
                throw;
            }
        }

    }
}
