using FilmFinder.Data.Interfaces;
using FilmFinder.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFinder.Data.Repository
{
    public class ActorRepository : IActorsExtractor
    {
        private readonly DbContent dbContent;

        public ActorRepository(DbContent content)
        {
            dbContent = content;
        }
        public IEnumerable<Actor> AllActors => dbContent.Actor.Include(a => a.FilmActor).ThenInclude(fa => fa.Film).ThenInclude(f => f.genre);

        public IEnumerable<Actor> ActorsWithName(string name)
        {
            return dbContent.Actor.Where(a => a.fullName.ToLower().Contains(name.ToLower())).Include(a => a.FilmActor).ThenInclude(fa => fa.Film).ThenInclude(f => f.genre);
        }
    }
}
