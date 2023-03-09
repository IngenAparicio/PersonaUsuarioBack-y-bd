using Microsoft.AspNetCore.Mvc;
using PersonasUsuariosAPI.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace PersonasUsuariosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : Controller
    {
        private readonly UsuariosBdContext _context;

        public PersonasController(UsuariosBdContext context)
        {
            _context = context;
        }


        // GET: api/<ComprasController>
        [HttpPost]
        [Route("ListaPersonas")]
        public async Task<IActionResult> GetListaPersonas()
        {
            try
            {
                StringBuilder query = new StringBuilder("exec [dbo].[ObtenerPersonas] ");
                var entidad = await _context.ListaPersona.FromSqlRaw(query.ToString()).ToListAsync();
                if (entidad != null)
                {
                    return Ok(entidad);
                }
                return BadRequest("Consulta vacía");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/<ComprasController>
        [HttpGet]
        [Route("Personas")]
        public async Task<IActionResult> GetPersonas(int id)
        {
            try
            {
                var listProducts = await _context.Personas.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(listProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST api/<ComprasController>
        [HttpPost]
        [Route("CrearPersona")]
        public async Task<IActionResult> CrearPersonas([FromBody] Persona entidad)
        {
            try
            {
                _context.Personas.Add(entidad);
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
