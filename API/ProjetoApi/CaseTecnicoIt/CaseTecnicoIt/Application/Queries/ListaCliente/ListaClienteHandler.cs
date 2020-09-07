using CaseTecnicoIt.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Application.Queries.ListaCliente
{
    public class ListaClienteHandler : IRequestHandler<ListaClienteporIdQuery, Response>
    {
        private readonly ILogger<ListaClienteHandler> _logger;
        private readonly IClienteRepository _clienteRepository;
        public ListaClienteHandler(ILogger<ListaClienteporIdQuery> logger, IClienteRepository clienteRepository)
        {
            _logger = (ILogger<ListaClienteHandler>)logger;
            _clienteRepository = clienteRepository;
        }
        public async Task<Response> Handle(ListaClienteporIdQuery request, CancellationToken cancellationToken)
        {
            Response response = new Response();

            _logger.LogInformation($"Iniciando o Handle de obter filme por Id : {request.Id}");

            var cliente = await _clienteRepository.BuscaporId(request.Id);

            if (cliente is null)
                response.AddError("Cliente não encontrado");

            return response;
        }
    }
}
