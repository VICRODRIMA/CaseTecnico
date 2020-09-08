using CaseTecnicoIt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Domain.Interfaces
{
    public interface ILocacaoRepository
    {
        Task criarLocacao(Locacao locacao);
        Task AtualizaLocacao(Locacao locacao);
        Task<Locacao> buscaLocacaoID(string id);
    }
}
