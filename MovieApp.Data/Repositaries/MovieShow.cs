using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.DataConnection;
using System.Linq;

namespace MovieApp.Data.Repositaries
{
    public class MovieShow : IMovieShow
    {
        MovieDbContext _movieDbContext;
        public MovieShow(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public string InsertShow(MovieShowModel movieShowModel)
        {
            _movieDbContext.movieShowModels.Add(movieShowModel);
            _movieDbContext.SaveChanges();
            return "Inserted the Show";
        }

        public List<MovieShowModel> movieShows()
        {
            List<MovieShowModel> movieShowModels = _movieDbContext.movieShowModels.ToList();
            return movieShowModels;
        }
    }
}
