using FilmFinder.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFinder.Data.Interfaces
{
    public interface IGenresExtractor
    {
        IEnumerable<Genre> AllGenres { get; }
        IEnumerable<Genre> GenresWithName(string name);
    }
}
