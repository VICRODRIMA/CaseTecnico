using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Application.Commands.Update
{
    public class UpdateFilme : IRequest<Response>
    {
        public UpdateFilme(int idFilm, string nomeFilm, string anoLancament)
        {
            idFilme = idFilm;
            nomeFilme = nomeFilm;
            anoLancamento = anoLancament;

        }
        public int idFilme { get; private set; }
        public string nomeFilme { get; private set; }
        public string anoLancamento { get; set; }
    }
}
