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
         

    }
}
