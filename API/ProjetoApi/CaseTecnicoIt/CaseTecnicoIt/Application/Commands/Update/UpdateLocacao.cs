using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Application.Commands.Update
{
    public class UpdateLocacao : IRequest<Response>
    {
        public UpdateLocacao(int idlocacao, string dtDevolucao)
        {
            idlocaca = idlocacao;
            dtDevoluca = dtDevolucao;

        }
        public int idlocaca { get; private set; }
        public string dtDevoluca { get; private set; }
        public string anoLancamento { get; set; }
    }
}
