using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;
namespace MovieApp.Data.Repositaries
{
    public  interface ITheatre
    {
        public object SelectTheatre();
        public string AddTheatre(TheatreModel theatreModel);
        public string DeleteTheatre(int ID);
        public TheatreModel GetTheatreById(int id);
        public string Update(TheatreModel theatreModel);
    }
}
