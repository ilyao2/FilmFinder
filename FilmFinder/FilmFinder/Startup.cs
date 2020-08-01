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

            /*DbContent db;
            using (var scope = app.ApplicationServices.CreateScope())
            {
                db = scope.ServiceProvider.GetRequiredService<DbContent>();
                Genre g1 = new Genre { name = "Fantasy" };
                Film f1 = new Film { name = "Pirates of the Caribbean", ganre =  g1 };
                Actor a1 = new Actor { fullName = "John Christopher «Johnny» Depp" };

                db.Add(g1);
                db.SaveChanges();
                db.Add(f1);
                db.SaveChanges();
                db.Add(a1);
                db.SaveChanges();
                f1.FilmActor.Add(new FilmActor { FilmId = f1.id, ActorId = a1.id }); ;
                db.SaveChanges();
            }*/
            
            
        }
    }
}
