using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Application.Commands.Update
{
    public class UpdateCliente : IRequest<Response>
    {
        public UpdateCliente(int idClient ,string nomeClient)
        {
            idCliente = idClient;
            nomeCliente = nomeClient;

        }
        public int idCliente { get; private set; }
        public string nomeCliente { get; private set; }

    }
}
