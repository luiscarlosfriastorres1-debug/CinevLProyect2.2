using System;
using System.Collections.Generic;

namespace CineAPI.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Pelicula> Peliculas { get; set; } = new List<Pelicula>();
}
