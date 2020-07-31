using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFinder.Data.Models
{
    public class Film
    {
        public int id { get; set; }
        public string name { get; set; }
        public Genre ganre { get; set; }
        public IEnumerable<Actor> actors { get; set; }
        
        public Film()
        {
            actors = new List<Actor>();
        }
    }
}
