using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MinhaAPIProduto.Model
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext (DbContextOptions<ProdutoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Produto> Produtos { get; set; }   
    }
}
