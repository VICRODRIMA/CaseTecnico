using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Domain.Models
{
    public class Locacoes
    {
        public Guid idLocacao { get; set; }
        public int idCliente { get; set; }
        public string dtLocacao { get; set; }

    }
}
