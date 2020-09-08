using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Application.Queries.ListaFilmes
{
    public class ListaFilmesAtivos : IRequest<Response>
    {
        public ListaFilmesAtivos(string id)
        {
            Id = id;
        }
        public string Id { get; private set; }
    }
}
