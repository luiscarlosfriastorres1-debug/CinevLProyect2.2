using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CineAPI.Models;

public partial class DbCinevLContext : DbContext
{
    public DbCinevLContext()
    {
    }

    public DbCinevLContext(DbContextOptions<DbCinevLContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pelicula__3213E83F6020C99F");

            entity.ToTable("peliculas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.Director)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("director");
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.ImagenUrl)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("imagen_url");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("titulo");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Peliculas)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_peliculas_usuarios");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuarios__3213E83F25F26968");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Correo, "UQ__usuarios__2A586E0BBF8C53AC").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
