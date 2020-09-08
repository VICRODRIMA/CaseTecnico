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
    public class InsertLocacaoHandler : IRequestHandler<InsertLocacao, Response>
    {
        private readonly ILogger<InsertLocacaoHandler> _logger;
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly IFilmesRepository _filmeRepository;
        public InsertLocacaoHandler(ILogger<InsertLocacaoHandler> logger, ILocacaoRepository locacaoRepository)
        {
            _logger = logger;
            _locacaoRepository = locacaoRepository;
        }
        public async Task<Response> Handle(InsertLocacao request, CancellationToken cancellationToken)
        {
            Response response = new Response();

            _logger.LogInformation($"Iniciando o Handle de insercao locacao: {request.idLocador}");

            var locaca = new Locacao
            {

                idLocador = request.idLocador,
                idCliente = request.idCliente,
                idFilme = request.idFilme,
                dtDevolucao = request.dtDevolucao

            };


            var filmeAtivo = _filmeRepository.BuscaFilmeAtivoPorID(request.idFilme.ToString());

            if (!(filmeAtivo is null))
            {
                await _locacaoRepository.criarLocacao(locaca);
            }
           else
                response.AddError("Filme não ativo, não é possivel locar");

            return response;
        }



    }
}