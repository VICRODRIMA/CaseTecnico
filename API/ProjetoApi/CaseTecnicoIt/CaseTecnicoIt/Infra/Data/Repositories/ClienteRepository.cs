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
    public class ClienteRepository : Repository, IClienteRepository
    {
        public ClienteRepository(ILogger logger, IOptions<ConnectionStringOptions> connectionString) : base(logger, connectionString)
        {
        }

        public async Task CriarCliente(Cliente client) => await ExecutarRegistrar(client);
        public async Task<Cliente> BuscaporId(string id)
         => await GetConnection().QueryFirstOrDefaultAsync<Cliente>("select * from cliente where idcliente = @id", new { id });

        private async Task ExecutarRegistrar(Cliente cliente)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    await conn.ExecuteAsync("",
                        new
                        {
                            cliente.IdCliente,
                            cliente.nomeCliente
                        });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Falha ao cadastrar o cliente");
                throw;
            }
        }
    }
}
