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

    [HttpPut("{id}")]
    public IActionResult UpdateLivro(int id, [FromBody] Livro livro)
    {

        var existingLivro = _context.Livro.FirstOrDefault(a => a.Id == id);
        if (existingLivro == null)
        {
            return NotFound();
        }

        existingLivro.ISBN = livro.ISBN;
        existingLivro.preco = livro.preco;
        existingLivro.Data_cadastro = livro.Data_cadastro;
        existingLivro.Data_publicacao = livro.Data_publicacao;
        existingLivro.Id_editora = livro.Id_editora;
        existingLivro.Descricao = livro.Descricao;

        _context.Livro.Update(existingLivro);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteLivro(int id)
    {
        var autor = _context.Livro.FirstOrDefault(a => a.Id == id);
        if (autor == null)
        {
            return NotFound();
        }

        _context.Livro.Remove(autor);
        _context.SaveChanges();

        return NoContent();
    }




}
