using Microsoft.AspNetCore.Mvc;
using MinhaAPIProduto.Model;
using MinhaAPIProduto.Repositorio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaAPIProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoRepositorio _interfaceproduto;
        public ProdutoController(ProdutoRepositorio produtoRepositorio)
        {
            _interfaceproduto = produtoRepositorio;
        }

        [HttpGet]
        public async Task<IEnumerable<Produto>> GetBooks()
        {
            return await _interfaceproduto.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetBooks(int id)
        {
            return await _interfaceproduto.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostBooks([FromBody] Produto Produto)
        {
            var newBook = await _interfaceproduto.Create(Produto);
            return CreatedAtAction(nameof(GetBooks), new { id = newBook.Id }, newBook);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var ProdutoDeletar = await _interfaceproduto.Get(id);

            if (ProdutoDeletar == null)
                return NotFound();

            await _interfaceproduto.Delete(ProdutoDeletar.Id);
            return NoContent();


        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Produto Produto)
        {
            if (id != Produto.Id)
                return BadRequest();

            await _interfaceproduto.Update(Produto);

            return NoContent();
        }
    }
}
