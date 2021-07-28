using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_RESTFULL_HELPDESK_APP.Controllers.Conexion;
using API_RESTFULL_HELPDESK_APP.Controllers.Models;
using API_RESTFULL_HELPDESK_APP.Models;

namespace API_RESTFULL_HELPDESK_APP.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TUsuariosController : ControllerBase
    {
        private readonly ConexionApp _context;

        public TUsuariosController(ConexionApp context)
        {
            _context = context;
        }

        // GET: api/TUsuarios
        [HttpGet]
        public IEnumerable<TUsuarios> GetTUsuarios()
        {
            return _context.TUsuarios.ToList();
        }

        // GET: api/TUsuarios/5
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTUsuarios([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tUsuarios = await _context.TUsuarios.FindAsync(id);

            if (tUsuarios == null)
            {
                return NotFound();
            }

            return Ok(tUsuarios);
        }
        // GET: api/TUsuarios valida usuario existe en login
        [HttpGet("{user}/{pass}")]
        public ActionResult GetValidaUserPassword( string user, string pass)
        {
            UsuariosDao Dao = new UsuariosDao();
            try
            {
                Respuestas respuestas = Dao.sp_TUsuarios_getValidaUser(user, pass);
                return Ok(respuestas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        // PUT: api/TUsuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTUsuarios([FromRoute] int id, [FromBody] TUsuarios tUsuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tUsuarios.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(tUsuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TUsuariosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TUsuarios
        [HttpPost]
        public async Task<IActionResult> PostTUsuarios([FromBody] TUsuarios tUsuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TUsuarios.Add(tUsuarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTUsuarios", new { id = tUsuarios.IdUsuario }, tUsuarios);
        }

        // DELETE: api/TUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTUsuarios([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tUsuarios = await _context.TUsuarios.FindAsync(id);
            if (tUsuarios == null)
            {
                return NotFound();
            }

            _context.TUsuarios.Remove(tUsuarios);
            await _context.SaveChangesAsync();

            return Ok(tUsuarios);
        }

        private bool TUsuariosExists(int id)
        {
            return _context.TUsuarios.Any(e => e.IdUsuario == id);
        }
    }
}