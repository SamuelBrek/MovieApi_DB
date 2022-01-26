using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pelicula.Domain.entities;
using Pelicula.Infraestructure.Repositories;

#nullable disable

namespace Pelicula.Infraestructure.Data
{
    public partial class MoviesBrekContext : DbContext
    {
        public MoviesBrekContext()
        {
        }

        public MoviesBrekContext(DbContextOptions<MoviesBrekContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MoviesBrek.mssql.somee.com;Initial Catalog=MoviesBrek;Persist Security Info=False;User ID=SamuelBrek_TWICE_SQLLogin_1;Password=1lhiq6pfzt");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.IdMovie);
                

                entity.ToTable("Movie");

                entity.Property(e => e.IdMovie).HasColumnName("idMovie");

                entity.Property(e => e.DirectorMovie)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("directorMovie");

                entity.Property(e => e.GenreMovie)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("genreMovie");

                entity.Property(e => e.PuntMovie).HasColumnName("puntMovie");

                entity.Property(e => e.RatingMovie).HasColumnName("ratingMovie");

                entity.Property(e => e.TitleMovie)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("titleMovie");

                entity.Property(e => e.YpubliMovie)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ypubliMovie");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
