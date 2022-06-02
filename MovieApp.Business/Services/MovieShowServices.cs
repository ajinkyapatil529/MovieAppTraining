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

        public string DeleteMovieShowtime(int id)
        {
            return _movieShow.DeleteMovieShowtime(id);
        }

        public MovieShowModel GetMovieShowimeById(int id)
        {
            return _movieShow.GetMovieShowimeById(id);
        }

        public List<MovieShowModel> GetShowtimeForSpecificMovieAndTheatre(int movieId)
        {
            return _movieShow.GetShowtimeForSpecificMovieAndTheatre(movieId);
        }

        public string UpdateMovieShowtime(MovieShowModel movieShowTimeModel)
        {
            return _movieShow.UpdateMovieShowtime(movieShowTimeModel);
        }
    }
}
