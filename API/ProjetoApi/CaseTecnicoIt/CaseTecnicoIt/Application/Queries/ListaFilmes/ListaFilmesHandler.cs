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

    public class ListaFilmesHandler : IRequestHandler<ListaFilmesporIdQuery, Response>
    {
        private readonly ILogger<ListaFilmesHandler> _logger;
        private readonly IFilmesRepository _filmesRepository;
        public ListaFilmesHandler(ILogger<ListaFilmesHandler> logger, IFilmesRepository filmeRepository)
        {
            _logger = logger;
            _filmesRepository = filmeRepository;
        }
        public async Task<Response> Handle(ListaFilmesporIdQuery request, CancellationToken cancellationToken)
        {
            Response response = new Response();

            _logger.LogInformation($"Iniciando o Handle de obter um filme por ID: {request.Id}");

            var filme = await _filmesRepository.BuscaFilmePorId(request.Id);

            if (filme is null)
                response.AddError("Filme não existe");

            response = new Response(filme);

            return response;
        }
    }
}
