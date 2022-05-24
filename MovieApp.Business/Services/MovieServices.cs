using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;
using MovieApp.Data.DataConnection;
using MovieApp.Data.Repositaries;
namespace MovieApp.Business.Services
{
    public class MovieServices
    {
        IMovie _movie;

        public MovieServices(IMovie movie)
        {
            _movie = movie;
        }

        public string AddMovie(MovieModel movieModel)
        {
            return _movie.AddMovie(movieModel);
        }

        public object SelectMovie()
        {
            return _movie.SelectMovie();
        }
    }
}
