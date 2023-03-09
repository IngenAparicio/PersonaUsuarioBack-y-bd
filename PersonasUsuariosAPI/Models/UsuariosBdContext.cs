using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PersonasUsuariosAPI.Models
{
    public partial class UsuariosBdContext : DbContext
    {
        public UsuariosBdContext()
        {
        }

        public UsuariosBdContext(DbContextOptions<UsuariosBdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<ListaPersona> ListaPersona { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-GRO2AFAF\\GABRIELPC; Database=UsuariosBd; User Id=sa; Password=12345; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CalcId)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CalcNombre)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroIdentificacion)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIdentificacion)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                entity.Property(e => e.Pass)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("Usuario");
            });

            // sp importado
            modelBuilder.Entity<ListaPersona>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CalcId)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CalcNombre)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroIdentificacion)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIdentificacion)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
