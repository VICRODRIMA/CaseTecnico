using CaseTecnicoIt.Domain.Interfaces;
using CaseTecnicoIt.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Application.Commands.Insert
{
    public class InsertClienteHandler : IRequestHandler<InsertCliente, Response>
    {
        private readonly ILogger<InsertClienteHandler> _logger;
        private readonly IClienteRepository _clienteRepository;
        public InsertClienteHandler(ILogger<InsertClienteHandler> logger, IClienteRepository clienteRepository)
        {
            _logger = logger;
            _clienteRepository = clienteRepository;
        }
        public async Task<Response> Handle(InsertCliente request, CancellationToken cancellationToken)
        {
            Response response = new Response();

            _logger.LogInformation($"Iniciando o Handle de obter um cliente por ID: {request.nomeCliente}");

            var testecliente = new Cliente
            {
                nomeCliente = request.nomeCliente
            };

            await _clienteRepository.CriarCliente(testecliente);

            return response;
        }
    }
}