using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;
using System.Linq;
using MovieApp.Data.Repositaries;
namespace MovieApp.Data.DataConnection
{
    public class User :IUser
    {
        MovieDbContext _movieDbContext;
        public User(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public string Register(UserModel userModel)
        {
            string msg = " ";
            _movieDbContext.userModels.Add(userModel);
            _movieDbContext.SaveChanges();
            msg = "Inserted Sucessfully";
            return msg;

        }

        public object SelectUser()
        {
            List<UserModel> userList = _movieDbContext.userModels.ToList();
            return userList;
        }

    }
}
