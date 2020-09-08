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
    public class ClienteRepository : Repository, IClienteRepository
    {
        public ClienteRepository(ILoggerFactory logger, IOptions<ConnectionStringOptions> connectionString)
            : base(logger.CreateLogger<ClienteRepository>(), connectionString)
        {
        }

        public async Task CriarCliente(Cliente client) => await ExecutarRegistrar(client);  

        public async Task<Cliente> BuscaporId(string id)
         => await GetConnection().QueryFirstOrDefaultAsync<Cliente>("select * from clientes where idcliente = @id", new { id });
        public async Task<Cliente> BuscaporNome(string nomeCliente)
       => await GetConnection().QueryFirstOrDefaultAsync<Cliente>("select * from clientes where nomeCliente = @nomeCliente", new { nomeCliente });
        private async Task ExecutarRegistrar(Cliente client)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    await conn.ExecuteAsync(clienteStatement.Inserir,
                        new
                        {
                            client.nomeCliente
                        });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Falha ao cadastrar o cliente");
                throw;
            }
        }

        public async Task AtualizarCliente(Cliente client) => await ExecutarAtualizar(client);

        private async Task ExecutarAtualizar(Cliente client)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    //MoviesStatament.Atualizar
                    await conn.ExecuteAsync(clienteStatement.Atualizar,
                        new
                        {
                            client.nomeCliente,
                            client.idCliente
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