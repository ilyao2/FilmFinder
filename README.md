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

it returns html with all films

#### StartPage(filmName, genreName, actorName)

POST request Route("")

use for html form

if parametr == null then returns all films

else get all films witch name contains parametr

so it return intersects of 3 pack of films by 3 parametr

## View

1 page with search form and list of films

filmPoster use my JS script for moving onMouseEnter onMouseMove

i like it)))

## My additions

if DB is empty, init will add some film with genres and actors

***

now project haven't web interface for appending models in DB

it need admin panel witch will use web interface

***

front is very ugly, but I'm not an painter, I can make up on a picture

but only with clear css, js

may be bootstrap and JQuery, but i don't like it

***

the movie search algorithm turned out to be not the most optimal

but I have thoughts on how to make it a little better

***

this project have my first unit-tests

# So it my first project with ASP and Entity

