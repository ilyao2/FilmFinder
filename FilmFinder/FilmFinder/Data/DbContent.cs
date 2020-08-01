using FilmFinder.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFinder.Data
{
    public class DbContent : DbContext
    {
        public DbContent(DbContextOptions<DbContent> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmActor>()
                .HasKey(t => new { t.FilmId, t.ActorId });

            modelBuilder.Entity<FilmActor>()
                .HasOne(sc => sc.Film)
                .WithMany(s => s.FilmActor)
                .HasForeignKey(sc => sc.FilmId);

            modelBuilder.Entity<FilmActor>()
                .HasOne(sc => sc.Actor)
                .WithMany(c => c.FilmActor)
                .HasForeignKey(sc => sc.ActorId);
        }

        public DbSet<Film> Film {get; set;}
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<FilmActor> FilmActor { get; set; }

    }
}
