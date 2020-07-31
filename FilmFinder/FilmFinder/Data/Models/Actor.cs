using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFinder.Data.Models
{
    public class Actor
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public IEnumerable<Film> films { get; set; }

        public Actor()
        {
            films = new List<Film>();
        }
    }
}
