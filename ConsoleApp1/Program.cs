using BussinessLogic.Interface;
using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static IUser userLogic;
        public static ISkill skillLogic;

        public static bool authorization;
        public static int ID;

        static void Main(string[] args)
        {
            userLogic = DependencyResolver.UserLogic;
            skillLogic = DependencyResolver.SkillLogic;
            authorization = false;

            Authorization();
            Console.WriteLine(ID);


            if (authorization)
            {
                Console.WriteLine("Выберите действие: \n 1.Посмотреть профиль \n 2.Посмотреть навыки \n 3.Выйти");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine(userLogic.GetByID(ID));
                        break;
                    case "2":
                        Console.WriteLine("Навыки:");
                        skillLogic.GetUserSkill(ID);
                        break;
                }
                }
        }
        public static void Authorization()
        {
            Console.WriteLine("Выберите действие: \n 1.Войти \n 2.Зарегестрироваться");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Введите логин:");
                    string Login = Console.ReadLine();
                    Console.WriteLine("Введите пароль:");
                    string Password = Console.ReadLine();
                    userLogic.Authorization(Login, Password);
                    ID = userLogic.FindForLogin(Login);
                    authorization = true;
                    break;
                case "2":
                    Console.WriteLine("Введите ФИО:");
                    string FullName = Console.ReadLine();
                    Console.WriteLine("Введите дату рождения:");
                    DateTime DateOfBrith = new DateTime(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                    Console.WriteLine("Укажите пол:");
                    string Sex = Console.ReadLine();
                    Console.WriteLine("Введите логин:");
                    string login = Console.ReadLine();
                    checkLogin(ref login);
                    Console.WriteLine("Введите пароль:");
                    string password = Console.ReadLine();

                    userLogic.Add(new User(FullName, DateOfBrith, Sex, login, password));

                    authorization = true;
                    break;
            }
        }
        public static void checkLogin(ref string login)
        {
            if (!(userLogic.FindForLogin(login) < 1))
            {
                Console.WriteLine("Логин занят!");
                Console.WriteLine("Введите логин:");
                login = Console.ReadLine();
                checkLogin(ref login);
            }
        }
    }
}
