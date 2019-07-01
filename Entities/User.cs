using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public User()
        {
        }

        public int ID { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBrith { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public DateTime DateRegistration { get; set; }

        public User(string fullName, DateTime dateOfBrith, string sex, string login, string password)
        {
            DateTime dateRegistration = DateTime.Today;
            var age = dateRegistration.Year - dateOfBrith.Year;
            if (dateOfBrith.Date > dateRegistration.AddYears(-age)) age--;
  
            FullName = fullName;
            DateOfBrith = dateOfBrith;
            Age = age;
            Sex = sex;
            Login = login;
            Password = password;
            DateRegistration = dateRegistration;
        }

        public override string ToString()
        {
            return $"ФИО: {FullName}\nДата Рождения: {DateOfBrith.ToShortDateString()}\nВозраст: {Age}\nПол {Sex}\n";
        }
    }
}
