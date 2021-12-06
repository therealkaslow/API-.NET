using Microsoft.EntityFrameworkCore;
using MinhaAPIProduto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAPIProduto.Repositorio
{
    public class UsuarioRepositorio : InterfaceUsuario
    {
        public readonly UsuarioContext _context;
        public UsuarioRepositorio(UsuarioContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Create(Usuario Usuario)
        {
            _context.Usuarios.Add(Usuario);
             await _context.SaveChangesAsync();

            return Usuario;
        }

        public async Task Delete(int id)
        {
            var UsuarioDeletar = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(UsuarioDeletar);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> Get()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> Get(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task Update(Usuario Usuario)
        {
            _context.Entry(Usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        Task<Usuario> InterfaceUsuario.Update(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
