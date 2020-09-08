using CaseTecnicoIt.Domain.Interfaces;
using CaseTecnicoIt.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Application.Commands.Insert
{
    public class InsertClienteHandler : IRequestHandler<InsertClienteHandler, Response>
    {
        private readonly ILogger<InsertClienteHandler> _logger;
        private readonly IClienteRepository _clienteRepository;



        public InsertClienteHandler(ILogger<InsertClienteHandler> logger, IClienteRepository clienteRepository)
        {
            _logger = logger;
            _clienteRepository = clienteRepository;
        }
        public async Task<Response> Handle(InsertClienteHandler request, CancellationToken cancellationToken)
        {
            Response response = new Response();

            _logger.LogInformation($"Iniciando o Handle de inserção um cliente");

            var client = new Cliente()
            {
                IdCliente = Guid.NewGuid(),
                nomeCliente = "victor"
            };

            await _clienteRepository.CriarCliente(client);



            return response;
        }



    }
}
