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
    public class AnunciosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AnunciosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Anuncios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anuncio>>> GetAnuncio()
        {
            return await _context.Anuncios.ToListAsync();
        }

        // GET: api/Anuncios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anuncio>> GetAnuncio(Guid id)
        {
            var anuncio = await _context.Anuncios.FindAsync(id);

            if (anuncio == null)
            {
                return NotFound();
            }

            return anuncio;
        }

        // PUT: api/Anuncios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnuncio(Guid id, Anuncio anuncio)
        {
            if (id != anuncio.Id)
            {
                return BadRequest();
            }

            _context.Entry(anuncio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnuncioExists(id))
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

        // POST: api/Anuncios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Anuncio>> PostAnuncio(Anuncio anuncio)
        {
            _context.Anuncios.Add(anuncio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnuncio", new { id = anuncio.Id }, anuncio);
        }

        // DELETE: api/Anuncios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnuncio(Guid id)
        {
            var anuncio = await _context.Anuncios.FindAsync(id);
            if (anuncio == null)
            {
                return NotFound();
            }

            _context.Anuncios.Remove(anuncio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnuncioExists(Guid id)
        {
            return _context.Anuncios.Any(e => e.Id == id);
        }
    }
}
