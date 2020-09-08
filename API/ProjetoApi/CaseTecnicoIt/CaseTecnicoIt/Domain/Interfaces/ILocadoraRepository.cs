using CaseTecnicoIt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Domain.Interfaces
{
    public interface ILocadoraRepository
    {
        Task criarLocacao(Locacoes locacao);
        Task<Locacoes> buscaLocacaoID(string id);
    }
}
