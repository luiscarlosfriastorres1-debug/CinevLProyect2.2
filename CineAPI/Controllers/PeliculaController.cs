using CineAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CineAPI.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class PeliculaController : Controller
    {
        private readonly DbCinevLContext _context;
        public PeliculaController(DbCinevLContext context) 
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Pelicula>>> GetPelicula()
        {
            var peliculas = await _context.Peliculas.ToListAsync();
            return Ok(peliculas);
        }

    }

}
