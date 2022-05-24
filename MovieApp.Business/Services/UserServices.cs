using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositaries;
using MovieApp.Entity;
namespace MovieApp.Business.Services
{
    public class UserServices
    {
        IUser _iuser;
        public UserServices(IUser user)
        {
            _iuser = user;
        }

        public string Register(UserModel userModel)
        {
            return _iuser.Register(userModel);
        }

        public object SelectUser()
        {
            return _iuser.SelectUser();
        }
    }
}
