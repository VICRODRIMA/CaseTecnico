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
    public class UpdateFilmeHandler : IRequestHandler<UpdateFilme, Response>
    {
        private readonly ILogger<UpdateFilmeHandler> _logger;
        private readonly IFilmesRepository _filmesRepository;
        public UpdateFilmeHandler(ILogger<UpdateFilmeHandler> logger, IFilmesRepository filmesRepository)
        {
            _logger = logger;
            _filmesRepository = filmesRepository;
        }
        public async Task<Response> Handle(UpdateFilme request, CancellationToken cancellationToken)
        {
            Response response = new Response();

            _logger.LogInformation($"Iniciando o Handle de obter o filme:  {request.nomeFilme}");

            var atualizafilme = new Filmes
            {
                idFilme = request.idFilme,
                nomeFilme = request.nomeFilme,
                anoLancamento = request.anoLancamento
            };

            await _filmesRepository.AtualizarFilme(atualizafilme);

            return response;
        }
    }
}