using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Domain.Models
{
    public class Locacao
    {
        public int? idLocacao { get; set; }
        public int idLocador { get; set; }
        public int idCliente { get; set; }
        public int idFilme { get; set; }
        public string dtLocacao { get; set; }
        public string dtDevolucao { get; set; }
    }
}
