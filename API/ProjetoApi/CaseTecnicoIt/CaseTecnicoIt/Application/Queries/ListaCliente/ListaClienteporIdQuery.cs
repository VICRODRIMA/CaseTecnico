﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Application.Queries.ListaCliente
{
    public class ListaClienteporIdQuery : IRequest<Response>
    {
        public ListaClienteporIdQuery(string id)
        {
            Id = id;
        }
        public string Id { get; private set; }

    }
}
