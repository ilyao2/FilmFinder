using FilmFinder.Data.Interfaces;
using FilmFinder.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFinder.Data.Repository
{
    public class FilmRepository : IFilmsExtractor
    {
        private readonly DbContent dbContent;

        public FilmRepository(DbContent content)
        {
            dbContent = content;
        }

        public IEnumerable<Film> AllFilms => dbContent.Film;

        public IEnumerable<Film> FilmsWithActor(Actor actor)
        {
            return dbContent.Film.Where(f => f.actors.Contains(actor));
        }

        public IEnumerable<Film> FilmsWithGenre(Genre genre)
        {
            return dbContent.Film.Where(f => f.ganre == genre);
        }

        public IEnumerable<Film> FilmsWithName(string name)
        {
            return dbContent.Film.Where(f => f.name.ToLower().Contains(name.ToLower()));
        }
    }
}
