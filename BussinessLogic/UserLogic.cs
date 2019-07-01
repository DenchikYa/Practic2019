using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using BussinessLogic.Interface;
using DAL.Interface;

namespace BusinessLogic
{
    public class UserLogic : IUser
    {
        private IUserDao userDao;
        
        public UserLogic(IUserDao UserDao)
        {
            this.userDao = UserDao;
        }

        public void Add(User value)
        {
            userDao.Add(value);
        }

        public User GetByID(int ID)
        {
            return userDao.GetByID(ID);
        }

        public int FindForLogin(string Login)
        {
            return userDao.FindForLogin(Login);
        }

        public int Authorization(string Login, string Password)
        {
            return userDao.Authorization(Login, Password);
        }

        public void EditFullName(int ID, string FullName)
        {
            userDao.EditFullName(ID, FullName);
        }

        public void EditPassword(int ID, string Password)
        {
            userDao.EditPassword(ID, Password);
        }
    }
}
