using Microsoft.AspNetCore.Mvc;
using Adopet.Data;
using Adopet.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AbrigosController : ControllerBase
{
    private readonly AppDbContext _context;

    public AbrigosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Abrigo>>> GetAbrigos()
    {
        return await _context.Abrigos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Abrigo>> GetAbrigo(int id)
    {
        var abrigo = await _context.Abrigos.FindAsync(id);
        if (abrigo == null)
        {
            return NotFound();
        }
        return abrigo;
    }

    [HttpPost]
    public async Task<ActionResult<Abrigo>> PostAbrigo(Abrigo abrigo)
    {
        _context.Abrigos.Add(abrigo);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAbrigo), new { id = abrigo.AbrigoId }, abrigo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAbrigo(int id, Abrigo abrigo)
    {
        if (id != abrigo.AbrigoId)
        {
            return BadRequest();
        }

        _context.Entry(abrigo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AbrigoExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAbrigo(int id)
    {
        var abrigo = await _context.Abrigos.FindAsync(id);
        if (abrigo == null)
        {
            return NotFound();
        }

        _context.Abrigos.Remove(abrigo);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AbrigoExists(int id)
    {
        return _context.Abrigos.Any(e => e.AbrigoId == id);
    }
}
