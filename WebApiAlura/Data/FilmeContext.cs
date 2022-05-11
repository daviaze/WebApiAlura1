using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlura.Model;

namespace WebApiAlura.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema)
                .WithOne(cinema => cinema.Endereco)
                .HasForeignKey<Cinema>(cinema => cinema.EnderecoId);

            builder.Entity<Cinema>()
                .HasOne(cinema => cinema.Gerente)
                .WithMany(cinema => cinema.Cinemas)
                .HasForeignKey(cinema => cinema.GerenteId);
            //.isRequired(false) possibilita ter um cinema sem gerente
            //.OnDelete(DeleteBehavior.Restrict); alterar o método de deleção para não ser cascade

            builder.Entity<Sessao>()
                .HasOne(sessao => sessao.Filme)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(sessao => sessao.FilmeId);

            builder.Entity<Sessao>()
                .HasOne(sessao => sessao.Cinema)
                .WithMany(cinema => cinema.Sessoes)
                .HasForeignKey(sessao => sessao.CinemaId);

    }

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Gerente> Gerentes { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }


    }
}
