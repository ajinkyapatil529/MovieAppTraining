using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;
namespace MovieApp.Data.Repositaries
{
    public interface IMovie
    {
        public string AddMovie(MovieModel movieModel);
        public object SelectMovie();
    }
}
