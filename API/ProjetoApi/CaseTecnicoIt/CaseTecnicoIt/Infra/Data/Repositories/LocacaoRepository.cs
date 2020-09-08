using CaseTecnicoIt.Domain.Interfaces;
using CaseTecnicoIt.Domain.Models;
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

        private async Task ExecutarRegistrar(Locacao film)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    await conn.ExecuteAsync("",
                        new
                        {
                            film.idLocacao,
                            film.idCliente,
                            film.dtLocacao
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