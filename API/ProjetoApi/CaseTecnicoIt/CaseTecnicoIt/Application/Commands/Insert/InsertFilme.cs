using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Application.Commands.Insert
{
    public class InsertFilme : IRequest<Response>
    {
        public InsertFilme(string nomeFilm, string anoLancament)
        {

            nomeFilme = nomeFilm;
            anoLancamento = anoLancament;

        }
        public string nomeFilme { get; private set; }
        public string anoLancamento { get; set; }

    }
}
