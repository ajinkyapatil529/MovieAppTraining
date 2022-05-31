using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
namespace MovieApp.Data.Repositaries
{
    public class Theatre : ITheatre
    {
        MovieDbContext _movieDbContext;
        public Theatre(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public object SelectTheatre()
        {
           List<TheatreModel> theatrelist =  _movieDbContext.theatreModels.ToList();
            return theatrelist;
        }
        public string AddTheatre(TheatreModel theatreModel)
        {
            _movieDbContext.theatreModels.Add(theatreModel);
            _movieDbContext.SaveChanges();
            string msg = "Theatre Inserted";
            return msg;
        }
        public string DeleteTheatre(int ID)
        {
            var theatre = _movieDbContext.theatreModels.Find(ID);
            if(theatre == null)
            {
                return "theatre not found";
            }
            _movieDbContext.theatreModels.Remove(theatre);
            _movieDbContext.SaveChanges();
            return "Deleted the theatre";

        }
        public TheatreModel GetTheatreById(int id)
        {
            var result = _movieDbContext.theatreModels.Find(id);
            if (result == null)
            {
                Console.WriteLine("Id not present");
            }
            return result;
        }
        public string Update(TheatreModel theatreModel)
        {
            string mesg = "";
            _movieDbContext.Update(theatreModel);
            _movieDbContext.SaveChanges();
            mesg = "Updated Details Successfully";
            return mesg;
        }
    }
}
