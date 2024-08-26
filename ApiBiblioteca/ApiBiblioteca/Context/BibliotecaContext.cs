using ApiBiblioteca.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiBiblioteca.Context
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base (options) 
        {
        
        }

        public DbSet<Livro> Livros { get; set; }
    }
}
