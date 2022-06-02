using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;
namespace MovieApp.Data.Repositaries
{
    public interface IMovieShow
    {
        public string InsertShow(MovieShowModel movieShowModel);
        public List<MovieShowModel> movieShows();
        public string DeleteMovieShowtime(int id);
        public string UpdateMovieShowtime(MovieShowModel movieShowModel);
        public MovieShowModel GetMovieShowimeById(int id);
        public List<MovieShowModel> GetShowtimeForSpecificMovieAndTheatre(int movieId);

    }
}
