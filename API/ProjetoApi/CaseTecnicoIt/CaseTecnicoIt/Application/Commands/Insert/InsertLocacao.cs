using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Application.Commands.Insert
{
    public class InsertLocacao : IRequest<Response>
    {
        public InsertLocacao(int idLocado, int idFilm, int idClient, string dtDevoluca)
        {
            idLocador = idLocado;
            idFilme = idFilm;
            idCliente = idClient;
            dtDevolucao = dtDevoluca;
        }
        public int idLocador { get; private set; }
        public int idFilme { get; private set; }
        public int idCliente{ get; private set; }
        public string dtDevolucao { get; private set; }

    }
}
