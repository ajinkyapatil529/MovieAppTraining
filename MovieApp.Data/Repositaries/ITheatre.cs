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
    }
}
