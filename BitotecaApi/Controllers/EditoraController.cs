using BitotecaApi.Data;
using BitotecaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BitotecaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EditoraController : ControllerBase
    {
        private EditoraContext _context;

        public EditoraController(EditoraContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<Editora> GetEditoras()
        {
            return _context.Editora;
        }

        [HttpGet("{id}")]
        public IActionResult GetEditoraById(int id)
        {
            var editora = _context.Editora.FirstOrDefault(x => x.Id == id);

            if (editora == null)
            {
                return NotFound();
            }
            return Ok(editora);
        }

        [HttpPost]
        public IActionResult AddEditora([FromBody] Editora editora)
        {
            _context.Editora.Add(editora);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEditoraById), new { id = editora.Id }, editora);
        }
    }
}
