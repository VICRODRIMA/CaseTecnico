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
    public class UpdateLocacaoHandler : IRequestHandler<UpdateLocacao, Response>
    {
        private readonly ILogger<UpdateLocacaoHandler> _logger;
        private readonly ILocacaoRepository _LocacaoRepository;
        public UpdateLocacaoHandler(ILogger<UpdateLocacaoHandler> logger, ILocacaoRepository LocacaoRepository)
        {
            _logger = logger;
            _LocacaoRepository = LocacaoRepository;
        }
        public async Task<Response> Handle(UpdateLocacao request, CancellationToken cancellationToken)
        {
            Response response = new Response();

            _logger.LogInformation($"Iniciando o Handle Locacao:  {request.idlocaca}");

            var atualizafilme = new Locacao
            {
                idLocacao = request.idlocaca,
                dtDevolucao = request.dtDevoluca
            };

            await _LocacaoRepository.AtualizaLocacao(atualizafilme);

            return response;
        }
    }
}