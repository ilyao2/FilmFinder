using FilmFinder.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFinder.Data.Interfaces
{
    interface IGenreExtractor
    {
        IEnumerable<Genre> AllGeneres { get; }
        IEnumerable<Genre> GenresWithName(string name);
    }
}
