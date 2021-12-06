using Microsoft.AspNetCore.Mvc;
using MinhaAPIProduto.Model;
using MinhaAPIProduto.Repositorio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaAPIProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepositorio _interfaceusuario;
        public UsuarioController(UsuarioRepositorio usuarioRepositorio)
        {
            _interfaceusuario = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<IEnumerable<Usuario>> GetBooks()
        {
            return await _interfaceusuario.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            return await _interfaceusuario.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario([FromBody] Usuario Usuario)
        {
            var newUsuario = await _interfaceusuario.Create(Usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = newUsuario.Id }, newUsuario);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var UsuarioDeletar = await _interfaceusuario.Get(id);

            if (UsuarioDeletar == null)
                return NotFound();

            await _interfaceusuario.Delete(UsuarioDeletar.Id);
            return NoContent();


        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Usuario Usuario)
        {
            if (id != Usuario.Id)
                return BadRequest();

            await _interfaceusuario.Update(Usuario);

            return NoContent();
        }
    }
}
