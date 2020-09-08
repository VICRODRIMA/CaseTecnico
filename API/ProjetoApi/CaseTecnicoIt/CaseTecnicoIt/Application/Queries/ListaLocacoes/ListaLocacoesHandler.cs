using CaseTecnicoIt.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Application.Queries.ListaLocacoes
{
    public class ListaLocacoesHandler : IRequestHandler<ListaLocacoesporIDQuery, Response>
    {
        private readonly ILogger<ListaLocacoesHandler> _logger;
        private readonly ILocacaoRepository _locacaoRepository;
        public ListaLocacoesHandler(ILogger<ListaLocacoesHandler> logger, ILocacaoRepository locacaoRepository)
        {
            _logger = logger;
            _locacaoRepository = locacaoRepository;
        }
        public async Task<Response> Handle(ListaLocacoesporIDQuery request, CancellationToken cancellationToken)
        {
            Response response = new Response();

            _logger.LogInformation($"Iniciando o Handle de obter um locacao por ID: {request.Id}");

            var loca = await _locacaoRepository.buscaLocacaoID(request.Id);

            if (loca is null)
                response.AddError("Locacao não existe");

            response = new Response(loca);

            return response;
        }
    }
}