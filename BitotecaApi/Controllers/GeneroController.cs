
using BitotecaApi.Data;
using BitotecaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BitotecaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GeneroController : ControllerBase
{
    private GeneroContext _context;

    public GeneroController(GeneroContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Genero> GetGeneros()
    {
        return _context.Genero;
    }

    [HttpGet("{id}")]
    public IActionResult GetGeneroById(int id)
    {
        var genero = _context.Genero.FirstOrDefault(x => x.Id == id);

        if(genero == null)
        {
           return NotFound();
        }
        return Ok(genero);
    }

    [HttpPost]
    public IActionResult AddLivro([FromBody] Genero genero)
    {
        _context.Genero.Add(genero);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetGeneroById), new { id = genero.Id }, genero);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateGenero(int id, [FromBody] Genero genero)
    {

        var existingGenero = _context.Genero.FirstOrDefault(a => a.Id == id);
        if (existingGenero == null)
        {
            return NotFound();
        }

        existingGenero.Nome = genero.Nome;

        _context.Genero.Update(existingGenero);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGenero(int id)
    {
        var autor = _context.Genero.FirstOrDefault(a => a.Id == id);
        if (autor == null)
        {
            return NotFound();
        }

        _context.Genero.Remove(autor);
        _context.SaveChanges();

        return NoContent();
    }



}
