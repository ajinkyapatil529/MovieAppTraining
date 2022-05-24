using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System.Linq;
namespace MovieApp.Data.Repositaries
{
    public class Movie : IMovie
    {
        MovieDbContext _movieDbContext;

        public Movie(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public string AddMovie(MovieModel movieModel)
        {
            string message = "";
            _movieDbContext.movieModels.Add(movieModel);
            _movieDbContext.SaveChanges();
            message = "Movie Inserted";
            return message;
        }

        public object SelectMovie()
        {
            List<MovieModel> movieList = _movieDbContext.movieModels.ToList();
            return movieList;
        }
    }
}
