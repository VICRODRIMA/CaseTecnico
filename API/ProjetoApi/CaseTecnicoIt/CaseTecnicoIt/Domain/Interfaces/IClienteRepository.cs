using CaseTecnicoIt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task CriarCliente(Cliente client);
        Task AtualizarCliente(Cliente client);
        Task<Cliente> BuscaporId(string id);
        Task<Cliente> BuscaporNome(string nomeCliente);
        //Task<Cliente> ListaClientes();

    }
}
