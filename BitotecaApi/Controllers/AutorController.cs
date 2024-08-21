using BitotecaApi.Data;
using BitotecaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BitotecaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AutorController : ControllerBase
{
    private AutorContext _context;

    public AutorController(AutorContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddAutor([FromBody] Autor autor)
    {
        _context.Autor.Add(autor);
        _context.SaveChanges();
        return CreatedAtAction(nameof(getAutorById),new {id = autor.Id }, autor);
    }

    [HttpGet]
    public IEnumerable<Autor> GetAutors()
    {
        return _context.Autor ;
    }

    [HttpGet("{id}")]
    public IActionResult getAutorById(int id)
    {
        var autorSelect = _context.Autor.FirstOrDefault(autor => autor.Id == id);

        if (autorSelect == null)
        {
            return NotFound();
        }
        return Ok(autorSelect);
    }


    [HttpPut("{id}")]
    public IActionResult UpdateAutor(int id, [FromBody] Autor autor)
    {
 
        var existingAutor = _context.Autor.FirstOrDefault(a => a.Id == id);
        if (existingAutor == null)
        {
            return NotFound();
        }


        existingAutor.Nome = autor.Nome;
        existingAutor.biografia = autor.biografia;
        existingAutor.imagem_url = autor.imagem_url;

        _context.Autor.Update(existingAutor);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAutor(int id)
    {
        var autor = _context.Autor.FirstOrDefault(a => a.Id == id);
        if (autor == null)
        {
            return NotFound();
        }

        _context.Autor.Remove(autor);
        _context.SaveChanges();

        return NoContent();
    }
    

}
