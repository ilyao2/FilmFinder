using FilmFinder.Data.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFinder.ViewModels
{
    public class FilmsViewModel
    {
        public List<Film> Films { get; }
        public List<string> AllGenres { get; }
        public List<string> AllActors { get; }
        
        public FilmsViewModel()
        {
            Films = new List<Film>();
            AllGenres = new List<string>();
            AllActors = new List<string>();
        }

        public void Add(Film film)
        {
            if (!Films.Contains(film))
            {
                Films.Add(film);
                AllGenres.Add(film.ganre.name);
                foreach (var fa in film.FilmActor)
                    AllActors.Add(fa.Actor.fullName);
            }
        }
        public void AddRange(IEnumerable<Film> films)
        {
            var needFilms = films.Except(Films);
            foreach (var f in needFilms)
            {
                AllGenres.Add(f.ganre.name);
                foreach (var fa in f.FilmActor)
                    AllActors.Add(fa.Actor.fullName);
            }

            Films.AddRange(needFilms);
        }
    }
}
