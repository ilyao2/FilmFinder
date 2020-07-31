using FilmFinder.Data.Interfaces;
using FilmFinder.Data.Models;
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
        public IEnumerable<Actor> AllActors => dbContent.Actor;

        public IEnumerable<Actor> ActorsWithName(string name)
        {
            return dbContent.Actor.Where(a => a.fullName.ToLower().Contains(name.ToLower()));
        }
    }
}
