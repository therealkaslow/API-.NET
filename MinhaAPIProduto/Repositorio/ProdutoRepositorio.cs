using Microsoft.EntityFrameworkCore;
using MinhaAPIProduto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAPIProduto.Repositorio
{

    public class ProdutoRepositorio : InterfaceProduto
    {
        public readonly ProdutoContext _context;
        public ProdutoRepositorio(ProdutoContext context)
        {
            _context = context;
        }

        public async Task<Produto> Create(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task Delete(int Id)
        {
            var produtoDeletar = await _context.Produtos.FindAsync(Id);
            _context.Produtos.Remove(produtoDeletar);
            await _context.SaveChangesAsync();
        } 

        public async Task<IEnumerable<Produto>> Get()
        {
          return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> Get(int Id)
        {
            return await _context.Produtos.FindAsync(Id);
        }

        public async Task Update(Produto Produto)
        {
            _context.Entry(Produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        Task<Produto> InterfaceProduto.Update(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
