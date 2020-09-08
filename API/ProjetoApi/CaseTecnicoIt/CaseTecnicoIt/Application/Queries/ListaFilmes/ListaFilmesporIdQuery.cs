using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Application.Queries.ListaFilmes
{

    public class ListaFilmesporIdQuery : IRequest<Response>
    {
        public ListaFilmesporIdQuery(string id)
        {
            Id = id;
        }
        public string Id { get; private set; }
    }
}
