using MinhaAPIProduto.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaAPIProduto.Repositorio
{
    public interface InterfaceProduto
    {
        Task<IEnumerable<Produto>> Get();

        Task<Produto> Get(int id);

        Task<Produto> Create(Produto produto);

        Task<Produto> Update(Produto produto);

        Task Delete(int id);
    }
}
