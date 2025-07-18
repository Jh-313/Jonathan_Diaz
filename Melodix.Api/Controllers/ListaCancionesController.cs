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
    public class ListaCancionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ListaCancionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ListaCanciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListaCancion>>> GetListaCancion()
        {
            return await _context.ListaCanciones.ToListAsync();
        }

        // GET: api/ListaCanciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListaCancion>> GetListaCancion(Guid id)
        {
            var listaCancion = await _context.ListaCanciones.FindAsync(id);

            if (listaCancion == null)
            {
                return NotFound();
            }

            return listaCancion;
        }

        // PUT: api/ListaCanciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListaCancion(Guid id, ListaCancion listaCancion)
        {
            if (id != listaCancion.Id)
            {
                return BadRequest();
            }

            _context.Entry(listaCancion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListaCancionExists(id))
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

        // POST: api/ListaCanciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ListaCancion>> PostListaCancion(ListaCancion listaCancion)
        {
            _context.ListaCanciones.Add(listaCancion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListaCancion", new { id = listaCancion.Id }, listaCancion);
        }

        // DELETE: api/ListaCanciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListaCancion(Guid id)
        {
            var listaCancion = await _context.ListaCanciones.FindAsync(id);
            if (listaCancion == null)
            {
                return NotFound();
            }

            _context.ListaCanciones.Remove(listaCancion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListaCancionExists(Guid id)
        {
            return _context.ListaCanciones.Any(e => e.Id == id);
        }
    }
}
