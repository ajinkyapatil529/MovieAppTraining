using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data.DataConnection;
using MovieApp.Business.Services;
using MovieApp.Data.Repositaries;
using Microsoft.OpenApi.Models;

namespace MovieAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string sqlConnection = Configuration.GetConnectionString("SqlConnection");
            services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(sqlConnection));
            services.AddTransient<IUser, User>();
            services.AddTransient<UserServices, UserServices>();
            services.AddTransient<IMovie, Movie>();
            services.AddTransient<MovieServices, MovieServices>();
            services.AddTransient<ITheatre, Theatre>();
            services.AddTransient<TheatreServices, TheatreServices>();
            services.AddTransient<IMovieShow,MovieShow>();
            services.AddTransient<MovieShowServices, MovieShowServices>();
            services.AddControllers();
            //services.AddSwaggerGen();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyMovieApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            { c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyMovieApi"); });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
