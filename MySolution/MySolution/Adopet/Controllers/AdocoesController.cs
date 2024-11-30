using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Adopet.Models;
using Adopet.Data;

namespace Adopet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdocoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdocoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Adocoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adocao>>> GetAdocoes()
        {
            return await _context.Adocoes.Include(a => a.Animal).Include(a => a.Adotante).ToListAsync();
        }

        // GET: api/Adocoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adocao>> GetAdocao(int id)
        {
            var adocao = await _context.Adocoes.Include(a => a.Animal).Include(a => a.Adotante).FirstOrDefaultAsync(a => a.AdocaoId == id);

            if (adocao == null)
            {
                return NotFound();
            }

            return adocao;
        }

        // POST: api/Adocoes
        [HttpPost]
        public async Task<ActionResult<Adocao>> PostAdocao(Adocao adocao)
        {
            var animal = await _context.Animais.FindAsync(adocao.AnimalId);
            if (animal == null || !animal.DisponivelParaAdocao)
            {
                return BadRequest(new { message = "Animal não disponível para adoção" });
            }

            _context.Adocoes.Add(adocao);
            animal.DisponivelParaAdocao = false; // Atualiza a disponibilidade do animal
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAdocao), new { id = adocao.AdocaoId }, adocao);
        }

        // PUT: api/Adocoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdocao(int id, Adocao adocaoAtualizada)
        {
            if (id != adocaoAtualizada.AdocaoId)
            {
                return BadRequest();
            }

            var adocao = await _context.Adocoes.FindAsync(id);
            if (adocao == null)
            {
                return NotFound();
            }

            adocao.Status = adocaoAtualizada.Status;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Adocoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdocao(int id)
        {
            var adocao = await _context.Adocoes.FindAsync(id);
            if (adocao == null)
            {
                return NotFound();
            }

            _context.Adocoes.Remove(adocao);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}