using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using PersonasUsuariosAPI.Models;

namespace PersonasUsuariosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly UsuariosBdContext _context;

        public UsuariosController(UsuariosBdContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpPost]
        [Route("Usuario")]
        public async Task<IActionResult> Usuario(Usuario entidad)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Usuario1 == entidad.Usuario1 && x.Pass == entidad.Pass);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Usuarios
        [HttpPost]
        [Route("ListaUsuarios")]
        public async Task<IActionResult> ListaUsuarios()
        {
            try
            {
                var usuario = await _context.Usuarios.ToListAsync();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST api/Usuarios
        [HttpPost]
        [Route("CrearUsuario")]
        public async Task<IActionResult> CrearUsuario([FromBody] Usuario entidad)
        {
            try
            {
                _context.Usuarios.Add(entidad);
                await _context.SaveChangesAsync();

                return Ok(entidad);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
