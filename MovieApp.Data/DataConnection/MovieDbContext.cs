using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieApp.Entity;
namespace MovieApp.Data.DataConnection
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions <MovieDbContext> options) : base(options)
        {

        }
        public DbSet<UserModel> userModels { get; set; }
        public DbSet<MovieModel> movieModels { get; set; }
        public DbSet<TheatreModel> theatreModels { get; set; }
        public DbSet<MovieShowModel> movieShowModels { get; set; }
    }
}
