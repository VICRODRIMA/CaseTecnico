namespace CaseTecnicoIt.Application.Queries.ListaCliente
{
    using CaseTecnicoIt.Domain.Interfaces;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    public class ListaClienteHandler : IRequestHandler<ListaClienteporIdQuery, Response>
    {
        private readonly ILogger<ListaClienteHandler> _logger;
        private readonly IClienteRepository  _clienteRepository;
        public ListaClienteHandler(ILogger<ListaClienteHandler> logger, IClienteRepository clienteRepository)
        {
            _logger = logger;
            _clienteRepository = clienteRepository;
        }
        public async Task<Response> Handle(ListaClienteporIdQuery request, CancellationToken cancellationToken)
        {
            Response response = new Response();

            _logger.LogInformation($"Iniciando o Handle de obter um cliente por ID: {request.Id}");

            var filme = await _clienteRepository.BuscaporId(request.Id);

            //aqui por exemplo vc pode verificar se o filme está com atraso de devolução entre outras regras.
            if (filme is null)
                response.AddError("Cliente não encontrado");

            return response;
        }
    }
}
