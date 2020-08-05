# FilmFinder

## Model

| Actor     | Genre | FilmActor | Film    |
|:----------|:------|:----------|:-----   |
| id        | id    | FilmId    | id      |
| fullName  | name  | ActorId   | name    |
|           |       |           | genre   |
|           |       |           | imgPath |

### Interfaces
```C#
public interface IFilmsExtractor
    {
        IEnumerable<Film> AllFilms { get; }
        IEnumerable<Film> FilmsWithName(string name);
        IEnumerable<Film> FilmsWithGenre(Genre genre);
        IEnumerable<Film> FilmsWithActor(Actor actor);
    }
public interface IGenresExtractor
    {
        IEnumerable<Genre> AllGenres { get; }
        IEnumerable<Genre> GenresWithName(string name);
    }
public interface IActorsExtractor
    {
        IEnumerable<Actor> AllActors { get; }
        IEnumerable<Actor> ActorsWithName(string name);
    }

```

## Controller

### HomeController

#### StartPage()

GET request Route("")

Returns html with all films

#### StartPage(filmName, genreName, actorName)

POST request Route("")

use for html form

if parameter == null then returns all films 

else gets all films that contain parameter in their name

finally returns intersection of 3 pack of films by 3 parameters 

## View

1 page with search form and list of films 

filmPoster uses my JS script for moving onMouseEnter onMouseMove

i like it)))

## My additions

if DB is empty, init adds some films with genres and actors

***

for now project has no web interface for appending models in DB

it needs an admin panel which is going to use web interface

***

the front is very ugly, but I'm not a designer, however I can make it according to layout

but only with clear css, js

may be using bootstrap and JQuery, but i don't like it 

***

the movie search algorithm turned out to be not the optimal one 

but I have thoughts on how to make it a little better

***
this project has my first unit-tests 

# So it’s my first project with ASP and Entity

