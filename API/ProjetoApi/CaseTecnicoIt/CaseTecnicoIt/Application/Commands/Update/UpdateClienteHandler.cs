using CaseTecnicoIt.Domain.Interfaces;
using CaseTecnicoIt.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Application.Commands.Update
{
    public class UpdateClienteHandler : IRequestHandler<UpdateCliente, Response>
    {
        private readonly ILogger<UpdateClienteHandler> _logger;
        private readonly IClienteRepository _clienteRepository;
        public UpdateClienteHandler(ILogger<UpdateClienteHandler> logger, IClienteRepository clienteRepository)
        {
            _logger = logger;
            _clienteRepository = clienteRepository;
        }
        public async Task<Response> Handle(UpdateCliente request, CancellationToken cancellationToken)
        {
            Response response = new Response();

            _logger.LogInformation($"Iniciando o Handle de obter um cliente por ID: {request.nomeCliente}");

            var AtualizaClientes = new Cliente
            {
                nomeCliente = request.nomeCliente,
                idCliente = request.idCliente
            };

            await _clienteRepository.AtualizarCliente(AtualizaClientes);

            return response;
        }
    }
}