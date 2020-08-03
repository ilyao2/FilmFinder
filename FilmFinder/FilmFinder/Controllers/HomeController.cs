using FilmFinder.Data.Interfaces;
using FilmFinder.Data.Models;
using FilmFinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmFinder.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFilmsExtractor filmsExtractor;
        private readonly IActorsExtractor actorsExtractor;
        private readonly IGenresExtractor genresExtractor;

        public HomeController(IFilmsExtractor filmsExtractor, IActorsExtractor actorsExtractor, IGenresExtractor genresExtractor)
        {
            this.filmsExtractor = filmsExtractor;
            this.actorsExtractor = actorsExtractor;
            this.genresExtractor = genresExtractor;
        }

        [Route("")]
        public ViewResult StartPage()
        {
            ViewBag.Title = "FilmFinder";
            FilmsViewModel fvm = new FilmsViewModel();
            fvm.AddRange(filmsExtractor.AllFilms);
            return View(fvm);

        }
        [HttpPost]
        [Route("")]
        public ViewResult StartPage(string name, string genre, string actor)
        {
            ViewBag.Title = "FilmFinder";
            FilmsViewModel fvm = new FilmsViewModel();
            FilmsViewModel fvm1 = new FilmsViewModel();
            FilmsViewModel fvm2 = new FilmsViewModel();
            FilmsViewModel fvm3 = new FilmsViewModel();
            if (name != null)
                fvm1.AddRange(filmsExtractor.FilmsWithName(name));
            else
                fvm1.AddRange(filmsExtractor.AllFilms);
            if (genre != null)
            {
                var genres = genresExtractor.GenresWithName(genre);
                foreach (var g in genres)
                    fvm2.AddRange(filmsExtractor.FilmsWithGenre(g).Except(fvm2.Films));
            }
            else
                fvm2.AddRange(filmsExtractor.AllFilms);
            if (actor != null)
            {
                var actors = actorsExtractor.ActorsWithName(actor);
                foreach (var a in actors)
                    fvm3.AddRange(filmsExtractor.FilmsWithActor(a).Except(fvm3.Films));
            }
            else
                fvm3.AddRange(filmsExtractor.AllFilms);
            fvm.AddRange(fvm1.Films.Intersect(fvm2.Films.Intersect(fvm3.Films)));
            return View(fvm);
        }
    }
}
