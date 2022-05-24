using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;
namespace MovieApp.Data.Repositaries
{
    public interface IUser
    {
        public string Register(UserModel  userModel);
        //public string Delete();
        public object SelectUser();
    }
}
