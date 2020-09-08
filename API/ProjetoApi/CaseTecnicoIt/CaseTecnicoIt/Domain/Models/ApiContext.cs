using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Domain.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
         : base(options)
        { }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Filmes> Filme { get; set; }
        public DbSet<Locacoes> Locacao { get; set; }

    }
}
