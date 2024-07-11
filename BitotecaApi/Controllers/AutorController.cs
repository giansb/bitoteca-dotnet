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

}
