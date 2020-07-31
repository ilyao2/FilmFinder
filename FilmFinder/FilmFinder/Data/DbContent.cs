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

        public DbSet<Film> Film {get; set;}
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Genre> Genre { get; set; }

    }
}
