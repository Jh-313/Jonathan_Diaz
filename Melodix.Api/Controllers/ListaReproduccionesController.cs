using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Melodix;

namespace Melodix.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaReproduccionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ListaReproduccionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ListaReproducciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListaReproduccion>>> GetListaReproduccion()
        {
            return await _context.ListaReproducciones.ToListAsync();
        }

        // GET: api/ListaReproducciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListaReproduccion>> GetListaReproduccion(Guid id)
        {
            var listaReproduccion = await _context.ListaReproducciones.FindAsync(id);

            if (listaReproduccion == null)
            {
                return NotFound();
            }

            return listaReproduccion;
        }

        // PUT: api/ListaReproducciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListaReproduccion(Guid id, ListaReproduccion listaReproduccion)
        {
            if (id != listaReproduccion.Id)
            {
                return BadRequest();
            }

            _context.Entry(listaReproduccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListaReproduccionExists(id))
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

        // POST: api/ListaReproducciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ListaReproduccion>> PostListaReproduccion(ListaReproduccion listaReproduccion)
        {
            _context.ListaReproducciones.Add(listaReproduccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListaReproduccion", new { id = listaReproduccion.Id }, listaReproduccion);
        }

        // DELETE: api/ListaReproducciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListaReproduccion(Guid id)
        {
            var listaReproduccion = await _context.ListaReproducciones.FindAsync(id);
            if (listaReproduccion == null)
            {
                return NotFound();
            }

            _context.ListaReproducciones.Remove(listaReproduccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListaReproduccionExists(Guid id)
        {
            return _context.ListaReproducciones.Any(e => e.Id == id);
        }
    }
}
