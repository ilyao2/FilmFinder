﻿using FilmFinder.Data.Models;
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
            if (film == null)
                return;
            if (!Films.Contains(film))
            {
                Films.Add(film);
                if (film.genre != null)
                    AllGenres.Add(film.genre.name);
                if (film.FilmActor != null)
                    foreach (var fa in film.FilmActor)
                        if (fa.Actor != null)
                            AllActors.Add(fa.Actor.fullName);
            }
        }
        public void AddRange(IEnumerable<Film> films)
        {
            if (films == null)
                return;
            var needFilms = films.Except(Films);
            foreach (var f in needFilms)
            {
                if (f.genre != null)
                    AllGenres.Add(f.genre.name);
                if (f.FilmActor != null)
                    foreach (var fa in f.FilmActor)
                        if (fa.Actor != null)
                            AllActors.Add(fa.Actor.fullName);
            }

            Films.AddRange(needFilms);
        }
    }
}
