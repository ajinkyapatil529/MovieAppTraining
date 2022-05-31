using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositaries;
using MovieApp.Entity;
namespace MovieApp.Business.Services
{
    public class MovieShowServices
    {
        IMovieShow _movieShow;
        public MovieShowServices(IMovieShow movieShow)
        {
            _movieShow = movieShow;
        }
        public string InsertShow(MovieShowModel movieShowModel)
        {
            return _movieShow.InsertShow(movieShowModel);
        }

        public List<MovieShowModel> movieShows()
        {
            return _movieShow.movieShows();
        }
    }
}
