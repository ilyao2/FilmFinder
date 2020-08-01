using FilmFinder.Data.Interfaces;
using FilmFinder.Data.Models;
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
            var films = filmsExtractor.AllFilms;
            return View(films);
        }
    }
}
