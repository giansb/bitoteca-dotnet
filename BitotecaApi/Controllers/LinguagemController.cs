using BitotecaApi.Data;
using BitotecaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BitotecaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdiomaController : ControllerBase
    {
        private IdiomaContext _context;

        public IdiomaController(IdiomaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Idioma> GetGeneros()
        {
            return _context.Idioma;
        }
    }
}
