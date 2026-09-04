using System;
using System.Collections.Generic;

namespace CineAPI.Models;

public partial class Pelicula
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public int Anio { get; set; }

    public string? Director { get; set; }

    public int UsuarioId { get; set; }

    public string? ImagenUrl { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
