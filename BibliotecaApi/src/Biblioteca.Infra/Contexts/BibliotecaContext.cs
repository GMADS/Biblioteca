using Microsoft.EntityFrameworkCore;
using Biblioteca.Domain;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Infra.Contexts
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {

        }

        public DbSet<Livro> Bibliotecas { get; set; }

    }
}