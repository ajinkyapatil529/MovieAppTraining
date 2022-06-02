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

        public string DeleteMovieShowtime(int id)
        {
            string mesg = "";
            var toDelete = _movieDbContext.movieShowModels.Find(id);
            if (toDelete == null)
            {
                return mesg = "Id not found";
            }
            _movieDbContext.movieShowModels.Remove(toDelete);
            _movieDbContext.SaveChanges();
            mesg = "Deleted Successfully";
            return mesg;
        }
       public string UpdateMovieShowtime(MovieShowModel movieShowTimeModel)
        {
            string mesg = "";
            _movieDbContext.Entry(movieShowTimeModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _movieDbContext.SaveChanges();
            mesg = "Updated successfully";
            return mesg;
        }
        public MovieShowModel GetMovieShowimeById(int id)
        {
            return _movieDbContext.movieShowModels.Find(id);
        }
        public List<MovieShowModel> GetShowtimeForSpecificMovieAndTheatre(int movieId)
        {
            var specificShowtime = _movieDbContext.movieShowModels.Where(m => m.MovieId == movieId).ToList();
            return specificShowtime;
        }

    }
}
