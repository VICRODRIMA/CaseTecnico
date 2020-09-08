using CaseTecnicoIt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Domain.Interfaces
{
    public interface IFilmesRepository
    {
        Task CriarFilme(Filmes film);
        Task<Filmes> BuscaFilmePorId(string id);
        Task<Filmes> BuscaFilmeAtivoPorID(string id);
        Task<Filmes> BuscaFilmePorNome(string nomeFilme);
        Task AtualizarFilme(Filmes film);
    }
}
