using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BussinessLogic.Interface
{
    public interface IUser
    {
        void Add(User value);

        User GetByID(int ID);

        int FindForLogin(string Login);

        int Authorization(string Login, string Password);

        void EditFullName(int ID, string FullName);

        void EditPassword(int ID, string Password);
    }
}
