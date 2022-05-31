using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositaries;
using MovieApp.Entity;
namespace MovieApp.Business.Services
{
    public class TheatreServices
    {
        ITheatre _theatre;
        public TheatreServices(ITheatre theatre)
        {
            _theatre = theatre;
        }
        public object SelectTheatre()
        {
            return _theatre.SelectTheatre();
        }

        public string AddTheatre(TheatreModel theatreModel)
        {
           return _theatre.AddTheatre(theatreModel);
        }

        public string DeleteTheatre(int ID)
        {
            return _theatre.DeleteTheatre(ID);
        }
        public string UpdateTheatre(TheatreModel theatreModel)
        {
            return _theatre.Update(theatreModel);
        }

        public TheatreModel GetTheatreById(int id)
        {
            return _theatre.GetTheatreById(id);
        }


    }
}
