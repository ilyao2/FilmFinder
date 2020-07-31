using FilmFinder.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFinder.Data.Interfaces
{
    interface IFilmsExtractor
    {
        IEnumerable<Film> AllFilms { get; }
        IEnumerable<Film> FilmsWithName(string name);
        IEnumerable<Film> FilmsWithGenre(Genre genre);
        IEnumerable<Film> FilmsWithActor(Actor actor);

    }
}
