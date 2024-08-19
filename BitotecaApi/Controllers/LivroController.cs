using BitotecaApi.Data;
using BitotecaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BitotecaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LivroController : ControllerBase
{
    private LivroContext _context;

    public LivroController(LivroContext context)
    {
        _context = context; 
    }

    [HttpGet]
    public IEnumerable<Livro> GetLivros()
    {
        return _context.Livro;
    }


    [HttpGet("{id}")]

    public IActionResult GetLivroById(int id)
    {
        var livroSelect = _context.Livro.FirstOrDefault(x => x.Id == id);

        if (livroSelect == null)
        {
            return NotFound();
        }
        return Ok(livroSelect);
    }

    [HttpPost]
    public IActionResult AddLivro([FromBody] Livro livro)
    {
        _context.Livro.Add(livro);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetLivroById), new { id = livro.Id }, livro);
    }


}
