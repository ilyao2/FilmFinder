using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmFinder.Data;
using FilmFinder.Data.Interfaces;
using FilmFinder.Data.Models;
using FilmFinder.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FilmFinder
{
    public class Startup
    {
        private IConfigurationRoot _confString;

        public Startup(IWebHostEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("db_settings.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IFilmsExtractor, FilmRepository>();
            services.AddTransient<IActorsExtractor, ActorRepository>();
            services.AddTransient<IGenresExtractor, GenreRepository>();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            DbContent db;
            using (var scope = app.ApplicationServices.CreateScope())
            {
                db = scope.ServiceProvider.GetRequiredService<DbContent>();
                initObjects(db);
            }
            
            
        }

        void initObjects(DbContent db)
        {
            List<Genre> genres = db.Genre.ToList();
            List<Actor> actors = db.Actor.ToList();
            List<Film> films = db.Film.ToList();
            if (!db.Genre.Any())
            {
                genres = new List<Genre>
                {
                    new Genre { name = "Fantasy"},
                    new Genre { name = "Drama"},
                    new Genre { name = "Triller"},
                    new Genre { name = "Western"},
                };
                db.AddRange(genres);
                db.SaveChanges();
            }
            if (!db.Actor.Any())
            {
                actors = new List<Actor>
                {
                    new Actor { fullName = "John Cristopher \"Johnny\" Depp" },
                    new Actor { fullName = "Armand Douglas \"Armie\" Hammer" },
                    new Actor { fullName = "Keanu Charles Reeves" },
                    new Actor { fullName = "Michael Nyqvist" },
                    new Actor { fullName = "Laurence J. Fishburne" },
                    new Actor { fullName = "Tom Hanks" },
                    new Actor { fullName = "Robin Virginia Gayle Wright" },
                    new Actor { fullName = "Edward Harrison Norton" },
                    new Actor { fullName = "William Bradley \"Brad\" Pitt" },
                    new Actor { fullName = "David Morse" },
                    new Actor { fullName = "Tim Robbins" },
                    new Actor { fullName = "Morgan Freeman" },

                };
                db.AddRange(actors);
                db.SaveChanges();
            }
            if (!db.Film.Any())
            {

                films.Add(new Film { name = "Pirates of the Caribbean on stranger tides", genre = genres.First(g => g.name.Contains("Fantasy")), imgPath = "PotC.jpg" });
                films.Add(new Film { name = "The Shawshank Redemption", genre = genres.First(g => g.name.Contains("Drama")), imgPath = "TSR.jpg" });
                films.Add(new Film { name = "The Green Mile", genre = genres.First(g => g.name.Contains("Drama")), imgPath = "TGM.jpg" });
                films.Add(new Film { name = "Fight Club", genre = genres.First(g => g.name.Contains("Triller")), imgPath = "FC.jpg" });
                films.Add(new Film { name = "Forrest Gump", genre = genres.First(g => g.name.Contains("Drama")), imgPath = "FG.jpg" });
                films.Add(new Film { name = "The Matrix", genre = genres.First(g => g.name.Contains("Fantasy")), imgPath = "TM.jpg" });
                films.Add(new Film { name = "John Wick", genre = genres.First(g => g.name.Contains("Triller")), imgPath = "JW.jpg" });
                films.Add(new Film { name = "The Lone Ranger", genre = genres.First(g => g.name.Contains("Western")), imgPath = "TLR.jpg" });
        
                db.AddRange(films);
                db.SaveChanges();
                Film film = null;
                film = films.First(f => f.name.Contains("Pirates"));
                film.FilmActor.Add(new FilmActor { FilmId = film.id, ActorId = actors.First(a => a.fullName.Contains("Depp")).id});


                film = films.First(f => f.name.Contains("Shawshank"));
                film.FilmActor.Add(new FilmActor { FilmId = film.id, ActorId = actors.First(a => a.fullName.Contains("Tim")).id });
                film.FilmActor.Add(new FilmActor { FilmId = film.id, ActorId = actors.First(a => a.fullName.Contains("Morgan")).id });


                film = films.First(f => f.name.Contains("Green"));
                film.FilmActor.Add(new FilmActor { FilmId = film.id, ActorId = actors.First(a => a.fullName.Contains("Tom")).id });
                film.FilmActor.Add(new FilmActor { FilmId = film.id, ActorId = actors.First(a => a.fullName.Contains("David")).id });


                film = films.First(f => f.name.Contains("Fight"));
                film.FilmActor.Add(new FilmActor { FilmId = film.id, ActorId = actors.First(a => a.fullName.Contains("Edward")).id });
                film.FilmActor.Add(new FilmActor { FilmId = film.id, ActorId = actors.First(a => a.fullName.Contains("Brad")).id });

                film = films.First(f => f.name.Contains("Forrest"));
                film.FilmActor.Add(new FilmActor { FilmId = film.id, ActorId = actors.First(a => a.fullName.Contains("Tom")).id });
                film.FilmActor.Add(new FilmActor { FilmId = film.id, ActorId = actors.First(a => a.fullName.Contains("Robin")).id });

                film = films.First(f => f.name.Contains("Matrix"));
                film.FilmActor.Add(new FilmActor { FilmId = film.id, ActorId = actors.First(a => a.fullName.Contains("Keanu")).id });
                film.FilmActor.Add(new FilmActor { FilmId = film.id, ActorId = actors.First(a => a.fullName.Contains("Laurence")).id });

                film = films.First(f => f.name.Contains("Wick"));
                film.FilmActor.Add(new FilmActor { FilmId = film.id, ActorId = actors.First(a => a.fullName.Contains("Keanu")).id });
                film.FilmActor.Add(new FilmActor { FilmId = film.id, ActorId = actors.First(a => a.fullName.Contains("Michael")).id });

                film = films.First(f => f.name.Contains("Lone"));
                film.FilmActor.Add(new FilmActor { FilmId = film.id, ActorId = actors.First(a => a.fullName.Contains("Depp")).id });
                film.FilmActor.Add(new FilmActor { FilmId = film.id, ActorId = actors.First(a => a.fullName.Contains("Armand")).id });

                db.SaveChanges();
            }

        }
    }
}
