using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Adopet.Models;
using Adopet.Data;

namespace Adopet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdotantesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdotantesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Adotantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adotante>>> GetAdotantes()
        {
            return await _context.Adotantes.ToListAsync();
        }

        // GET: api/Adotantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adotante>> GetAdotante(int id)
        {
            var adotante = await _context.Adotantes.FindAsync(id);

            if (adotante == null)
            {
                return NotFound();
            }

            return adotante;
        }

        // POST: api/Adotantes
        [HttpPost]
        public async Task<ActionResult<Adotante>> PostAdotante(Adotante adotante)
        {
            _context.Adotantes.Add(adotante);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAdotante), new { id = adotante.AdotanteId }, adotante);
        }

        // PUT: api/Adotantes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdotante(int id, Adotante adotante)
        {
            if (id != adotante.AdotanteId)
            {
                return BadRequest();
            }

            _context.Entry(adotante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdotanteExists(id))
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

        // DELETE: api/Adotantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdotante(int id)
        {
            var adotante = await _context.Adotantes.FindAsync(id);
            if (adotante == null)
            {
                return NotFound();
            }

            _context.Adotantes.Remove(adotante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdotanteExists(int id)
        {
            return _context.Adotantes.Any(e => e.AdotanteId == id);
        }
    }
}
