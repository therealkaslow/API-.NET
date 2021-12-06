using MinhaAPIProduto.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaAPIProduto.Repositorio
{
    public interface InterfaceUsuario
    {
        Task<IEnumerable<Usuario>> Get();

        Task<Usuario> Get(int id);

        Task<Usuario> Create(Usuario Usuario);

        Task<Usuario> Update(Usuario Usuario);

        Task Delete(int id);
    }
}
