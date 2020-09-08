using CaseTecnicoIt.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Application.Queries.ListaCliente
{
    public class ListClientHandler : IRequestHandler<ListaClienteQuery, Response>
    {
        private readonly ILogger<ListClientHandler> _logger;
        private readonly IClienteRepository _clienteRepository;
        public ListClientHandler(ILogger<ListaClienteQuery> logger, IClienteRepository clienteRepository)
        {
            _logger = (ILogger<ListClientHandler>)logger;
            _clienteRepository = clienteRepository;
        }
        public async Task<Response> Handle(ListaClienteQuery request, CancellationToken cancellationToken)
        {
            Response response = new Response();

            _logger.LogInformation($"Iniciando o Handle de obter lista de clientes");

            var filme = await _clienteRepository.ListaClientes();


            return response;
        }



    }
}
