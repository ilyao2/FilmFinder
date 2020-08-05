using FilmFinder.Controllers;
using FilmFinder.Data.Interfaces;
using FilmFinder.Data.Models;
using FilmFinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FilmFinder.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void StartPageReturnsAllFilmsWithListOfFilms()
        {
            // Arrange
            var mockF = new Mock<IFilmsExtractor>();
            mockF.Setup(repo => repo.AllFilms).Returns(GetTestFilms());
            var mockA = new Mock<IActorsExtractor>();
            var mockG = new Mock<IGenresExtractor>();

            var controller = new HomeController(mockF.Object, mockA.Object, mockG.Object);

            // Act
            var result = controller.StartPage();

            // Assert
            Assert.NotNull(result);
            var ViewResult = Assert.IsType<ViewResult>(result);
            var ViewModel = Assert.IsAssignableFrom<FilmsViewModel>(ViewResult.Model);
            Assert.Equal(GetTestFilms().Count(), ViewModel.Films.Count);
        }

        [Fact]
        public void StartPageReturnsAllFilmsWithEmptyListOfFilms()
        {
            // Arrange
            var mockF = new Mock<IFilmsExtractor>();
            mockF.Setup(repo => repo.AllFilms).Returns(new List<Film>());
            var mockA = new Mock<IActorsExtractor>();
            var mockG = new Mock<IGenresExtractor>();

            var controller = new HomeController(mockF.Object, mockA.Object, mockG.Object);

            // Act
            var result = controller.StartPage();

            // Assert
            Assert.NotNull(result);
            var ViewResult = Assert.IsType<ViewResult>(result);
            var ViewModel = Assert.IsAssignableFrom<FilmsViewModel>(ViewResult.Model);
            Assert.Empty(ViewModel.Films);
        }

        [Fact]
        public void PostStartPageWithNullParametrsReturnsSearchedFilms()
        {
            // Arrange
            Genre genre = new Genre { id = 1, name = "generName2" };
            Actor actor = new Actor { id = 0, fullName = "actor" };
            FilmActor filmActor = new FilmActor { Actor = new Actor { id = 0, fullName = "actor" }, ActorId = 0 };
            string filmName = "film9";
            var mockF = new Mock<IFilmsExtractor>();
            mockF.Setup(repo => repo.AllFilms).Returns(GetTestFilms());
            mockF.Setup(repo => repo.FilmsWithName(filmName)).Returns(GetTestFilms().Where(f => f.name == filmName));
            mockF.Setup(repo => repo.FilmsWithGenre(genre)).Returns(GetTestFilms().Where(f => f.genre.id == genre.id));
            mockF.Setup(repo => repo.FilmsWithActor(actor)).Returns(GetTestFilms().Where(f => f.id > 7));

            string actorName = "actor";
            var mockA = new Mock<IActorsExtractor>();
            mockA.Setup(repo => repo.ActorsWithName(actorName)).Returns(new List<Actor> { actor });
            mockA.Setup(repo => repo.AllActors).Returns(new List<Actor> { actor });

            string genreName = "genreName2";
            var mockG = new Mock<IGenresExtractor>();
            mockG.Setup(repo => repo.GenresWithName(genreName)).Returns(new List<Genre> { genre });
            mockG.Setup(repo => repo.AllGenres).Returns(new List<Genre> { genre });

            var controller = new HomeController(mockF.Object, mockA.Object, mockG.Object);

            // Act
            var result = controller.StartPage(null,null,null);

            // Assert
            Assert.NotNull(result);
            var ViewResult = Assert.IsType<ViewResult>(result);
            var ViewModel = Assert.IsAssignableFrom<FilmsViewModel>(ViewResult.Model);
            Assert.Equal(GetTestFilms().Count(), ViewModel.Films.Count);
        }

        [Fact]
        public void PostStartPageWith_Name_GenreName_ActorName_ReturnsSearchedFilms()
        {
            // Arrange
            IEnumerable<Film> films = GetTestFilms();
            Genre genre = new Genre { id = 1, name = "generName2" };
            Actor actor = new Actor { id = 0, fullName = "actor" };
            FilmActor filmActor = new FilmActor { Actor = new Actor { id = 0, fullName = "actor" }, ActorId = 0 };
            string filmName = "film9";
            var mockF = new Mock<IFilmsExtractor>();
            mockF.Setup(repo => repo.AllFilms).Returns(films);
            mockF.Setup(repo => repo.FilmsWithName(filmName)).Returns(films.Where(f => f.id == 7 || f.id == 9));
            mockF.Setup(repo => repo.FilmsWithGenre(genre)).Returns(films.Where(f => f.id == 5 || f.id == 7 || f.id == 8 || f.id == 9));
            mockF.Setup(repo => repo.FilmsWithActor(actor)).Returns(films.Where(f => f.id == 8 || f.id == 9));

            string actorName = "actor";
            var mockA = new Mock<IActorsExtractor>();
            mockA.Setup(repo => repo.ActorsWithName(actorName)).Returns(new List<Actor> { actor });
            mockA.Setup(repo => repo.AllActors).Returns(new List<Actor> { actor });

            string genreName = "genreName2";
            var mockG = new Mock<IGenresExtractor>();
            mockG.Setup(repo => repo.GenresWithName(genreName)).Returns(new List<Genre> { genre });
            mockG.Setup(repo => repo.AllGenres).Returns(new List<Genre> { genre });

            var controller = new HomeController(mockF.Object, mockA.Object, mockG.Object);

            // Act
            var result = controller.StartPage(filmName, genreName, actorName);

            // Assert
            Assert.NotNull(result);
            var ViewResult = Assert.IsType<ViewResult>(result);
            var ViewModel = Assert.IsAssignableFrom<FilmsViewModel>(ViewResult.Model);
            Assert.Single(ViewModel.Films);
            var gettedFilm = Assert.IsType<Film>(ViewModel.Films.First());
            Assert.Equal(filmName, gettedFilm.name);
            Assert.Equal(genreName, gettedFilm.genre.name);
            Assert.Equal(genreName, ViewModel.AllGenres[0]);
            Assert.Equal(actorName, ViewModel.AllActors[0]);
        }

        private IEnumerable<Film> GetTestFilms()
        {
            var films = new List<Film>
            {
                new Film(),
                new Film { id=1, name="film"},
                new Film { id=2, name="film"},
                new Film { id=2, name="film1"},
                new Film { id=1, name="film"},
                new Film { id=3, name="film3", FilmActor = new List<FilmActor>(), genre = new Genre() },
                new Film { id=4, name="film4", FilmActor = new List<FilmActor>(), genre = new Genre { id=0, name="genreName1"} },
                new Film { id=5, name="film5", FilmActor = new List<FilmActor>{ new FilmActor()}, genre = new Genre { id=1, name="genreName2"} },
                new Film { id=6, name="film6", FilmActor = new List<FilmActor>{ new FilmActor { Actor = new Actor()} }, genre = new Genre { id=0, name="genreName1"} },
                new Film { id=7, name="film9", FilmActor = new List<FilmActor>{ new FilmActor { Film = new Film() } }, genre = new Genre { id=1, name="genreName2"} },

                new Film { id=8, name="film8", FilmActor = new List<FilmActor>{ new FilmActor { Actor = new Actor { id=0, fullName="actor"}, ActorId = 0 } }, genre = new Genre { id=1, name="genreName2"} },
                new Film { id=9, name="film9", FilmActor = new List<FilmActor>{ new FilmActor { Actor = new Actor { id=0, fullName="actor"}, ActorId = 0 } }, genre = new Genre { id=1, name="genreName2"} },
            };
            return films;
        }
    }
}
