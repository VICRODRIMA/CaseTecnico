using MediatR;

namespace CaseTecnicoIt.Application.Queries.ListaLocacoes
{
    public class ListaLocacoesporIDQuery : IRequest<Response>
    {
        public ListaLocacoesporIDQuery(string id)
        {
            Id = id;
        }
        public string Id { get; private set; }
    }
}
