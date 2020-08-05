using FilmFinder.Data.Interfaces;
using FilmFinder.Data.Models;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Film> AllFilms => dbContent.Film.Include(f => f.genre).Include(f => f.FilmActor).ThenInclude(fa => fa.Actor);

        public IEnumerable<Film> FilmsWithActor(Actor actor)
        {
            var filmActor = dbContent.FilmActor.Where(fa => fa.ActorId == actor.id).Include(fa => fa.Film).Include(fa => fa.Actor);

            IEnumerable<Film> result = new List<Film>();
            foreach(var fa in filmActor)
            {
                IEnumerable<Film> temp = dbContent.Film.Where(f => f.id == fa.FilmId).Include(f => f.genre).Include(f => f.FilmActor).ThenInclude(fai => fai.Actor);
                result = result.Union(temp);
            }
            return result;
        }

        public IEnumerable<Film> FilmsWithGenre(Genre genre)
        {
            return dbContent.Film.Where(f => f.genre == genre).Include(f => f.genre).Include(f => f.FilmActor).ThenInclude(fa => fa.Actor);
        }

        public IEnumerable<Film> FilmsWithName(string name)
        {
            return dbContent.Film.Where(f => f.name.ToLower().Contains(name.ToLower())).Include(f => f.genre).Include(f => f.FilmActor).ThenInclude(fa => fa.Actor);
        }
    }
}
