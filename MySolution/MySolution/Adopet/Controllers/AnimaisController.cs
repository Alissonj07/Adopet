using Microsoft.AspNetCore.Mvc;
using Adopet.Data;
using Adopet.Models;

using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AnimaisController : ControllerBase
{
    private readonly AppDbContext _context;

    public AnimaisController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Animal>>> GetAnimais()
    {
        return await _context.Animais.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
        var animal = await _context.Animais.FindAsync(id);
        if (animal == null)
        {
            return NotFound();
        }
        return animal;
    }

    [HttpPost]
    public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
    {
        _context.Animais.Add(animal);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAnimal(int id, Animal animal)
    {
        if (id != animal.AnimalId)
        {
            return BadRequest();
        }

        _context.Entry(animal).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AnimalExists(id))
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
    public async Task<IActionResult> DeleteAnimal(int id)
    {
        var animal = await _context.Animais.FindAsync(id);
        if (animal == null)
        {
            return NotFound();
        }

        _context.Animais.Remove(animal);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AnimalExists(int id)
    {
        return _context.Animais.Any(e => e.AnimalId == id);
    }
}
