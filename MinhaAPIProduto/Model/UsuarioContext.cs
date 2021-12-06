using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MinhaAPIProduto.Model
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
