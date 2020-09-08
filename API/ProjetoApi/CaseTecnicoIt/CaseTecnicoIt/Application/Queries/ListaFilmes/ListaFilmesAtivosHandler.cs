using CaseTecnicoIt.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Application.Queries.ListaFilmes
{
    public class ListaFilmesAtivosHandler : IRequestHandler<ListaFilmesAtivos, Response>
    {
        private readonly ILogger<ListaFilmesAtivosHandler> _logger;
        private readonly IFilmesRepository _filmesRepository;
        public ListaFilmesAtivosHandler(ILogger<ListaFilmesAtivosHandler> logger, IFilmesRepository filmeRepository)
        {
            _logger = logger;
            _filmesRepository = filmeRepository;
        }
        public async Task<Response> Handle(ListaFilmesAtivos request, CancellationToken cancellationToken)
        {
            Response response = new Response();

            _logger.LogInformation($"Iniciando o Handle de obter um filme ativo por ID: {request.Id}");

            var filme = await _filmesRepository.BuscaFilmeAtivoPorID(request.Id);

            if (filme is null)
                response.AddError("Filme não esta ativo");

            response = new Response(filme);

            return response;
        }
    }
}
