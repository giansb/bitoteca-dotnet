
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
}
