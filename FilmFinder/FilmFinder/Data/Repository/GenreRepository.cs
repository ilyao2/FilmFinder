using FilmFinder.Data.Interfaces;
using FilmFinder.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFinder.Data.Repository
{
    public class GenreRepository : IGenresExtractor
    {
        private readonly DbContent dbContent;

        public GenreRepository(DbContent content)
        {
            dbContent = content;
        }
        public IEnumerable<Genre> AllGenres => dbContent.Genre;

        public IEnumerable<Genre> GenresWithName(string name)
        {
            return dbContent.Genre.Where(g => g.name.ToLower().Contains(name.ToLower()));
        }
    }
}
