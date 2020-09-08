
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
      public class InsertFilmeHandler : IRequestHandler<InsertFilme, Response>
    {
        private readonly ILogger<InsertFilmeHandler> _logger;
        private readonly IFilmesRepository _filmerepository;
        public InsertFilmeHandler(ILogger<InsertFilmeHandler> logger, IFilmesRepository filmesRepository)
        {
            _logger = logger;
            _filmerepository = filmesRepository;
        }
        public async Task<Response> Handle(InsertFilme request, CancellationToken cancellationToken)
        {
            Response response = new Response();

            _logger.LogInformation($"Iniciando o Handle de obter o filme: {request.nomeFilme}");

            var film = new Filmes
            {
                nomeFilme = request.nomeFilme,
                anoLancamento = request.anoLancamento
            };

            await _filmerepository.CriarFilme(film);

            return response;
        }
    }
}