using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly DbCinevLContext _context;
    public UsuariosController(DbCinevLContext context)
    {
        _context = context;
    }

    // GET: api/Usuario
    [HttpGet]
    public async Task<ActionResult<Usuario>> GetUsuario()
    {
        return Ok(await _context.Usuarios.ToListAsync());
    }
}
