using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Application.Commands.Insert
{
    public class InsertCliente : IRequest<Response>
    {
        public InsertCliente(string nomeClient)
        {
     
            nomeCliente = nomeClient;

        }
        public string nomeCliente { get; private set; }

    }
}
