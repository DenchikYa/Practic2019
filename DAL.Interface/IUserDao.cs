using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.Interface
{
    public interface IUserDao
    {
        void Add(User value);

        User GetByID(int ID);

        int FindForLogin(string Login);

        int Authorization(string Login, string Password);

        void EditFullName(int ID, string FullName);

        void EditPassword(int ID, string Password);
    }
}
