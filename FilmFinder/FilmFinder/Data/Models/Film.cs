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
        public ICollection<FilmActor> FilmActor { get; set; }
        
        public Film()
        {
            FilmActor = new List<FilmActor>();
        }
    }
}
