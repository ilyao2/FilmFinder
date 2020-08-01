using FilmFinder.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFinder.Data.Interfaces
{
    public interface IActorsExtractor
    {
        IEnumerable<Actor> AllActors { get; }
        IEnumerable<Actor> ActorsWithName(string name);
    }
}
