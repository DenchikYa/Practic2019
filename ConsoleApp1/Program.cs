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
        }
        public static void Authorization()
        {
            Console.Clear();
            Console.WriteLine("Выберите действие: \n 1.Войти \n 2.Зарегестрироваться");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Введите логин:");
                    string Login = Console.ReadLine();
                    Console.WriteLine("Введите пароль:");
                    string Password = Console.ReadLine();
                    userLogic.Authorization(Login, Password);
                    ID = userLogic.FindForLogin(Login);
                    authorization = true;
                    Menu();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Введите ФИО:");
                    string FullName = Console.ReadLine();
                    Console.WriteLine("Введите дату рождения (DD,MM,YYYY):");
                    string[] date = Console.ReadLine().Split(',');

                    DateTime DateOfBrith = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                    Console.WriteLine("Укажите пол:");
                    string Sex = Console.ReadLine();
                    Console.WriteLine("Введите логин:");
                    string login = Console.ReadLine();
                    CheckLogin(ref login);
                    Console.WriteLine("Введите пароль:");
                    string password = Console.ReadLine();

                    userLogic.Add(new User(FullName, DateOfBrith, Sex, login, password));
                    ID = userLogic.FindForLogin(login);
                    authorization = true;
                    break;
            }
        }
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Выберите действие: \n 1.Посмотреть профиль \n 2.Посмотреть навыки \n 3.Выйти");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine(userLogic.GetByID(ID));
                    Back();
                    break;
                case "2":
                    Skills();
                    break;
                case "3":
                    Authorization();
                    authorization = false;
                    break;
            }
        }
        public static void CheckLogin(ref string login)
        {
            if (!(userLogic.FindForLogin(login) < 1))
            {
                Console.WriteLine("Логин занят!");
                Console.WriteLine("Введите логин:");
                login = Console.ReadLine();
                CheckLogin(ref login);
            }
        }
        public static void Back()
        {
            Console.WriteLine("0.Назад");
            switch (Console.ReadLine())
            {
                case "0":
                    Menu();
                    break;
            }
        }
        public static void Skills()
        {
            Console.Clear();
            Console.WriteLine("Навыки \nВыберите навык:");
            IEnumerable<Skill> list = skillLogic.GetUserSkill(ID);
            for(int i = 0; i < list.Count(); i++)
            {
                Console.WriteLine($"{i+1}. Название: {list.ElementAt(i).Name}");
            }
            Console.WriteLine("0.Назад");
            Console.WriteLine("-1.Поиск");
            int j = int.Parse(Console.ReadLine());
            if (j == 0) Menu();
            if (j == -1) FindSkill();
            SkillProfile(list.ElementAt(j-1));
        }
        public static void SkillProfile(Skill skill)
        {
            Console.Clear();
            Console.WriteLine(skill);
            Console.WriteLine("1.Изменить название \n2.Изменить описание \n3.Удалить \n0.Назад");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Введите новое название: ");
                    string name = Console.ReadLine();
                    skillLogic.editName(skill.ID, name);
                    skill.Name = name;
                    SkillProfile(skill);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Введите новое описание: ");
                    string desc = Console.ReadLine();
                    skillLogic.editDescription(skill.ID, desc);
                    skill.Description = desc;
                    SkillProfile(skill);
                    break;
                case "3":
                    Console.WriteLine("Вы действительно хотите удалить навык? Да/Нет");
                    switch (Console.ReadLine())
                    {
                        case "Да":
                            skillLogic.Remove(skill.ID);
                            Skills();
                            break;
                        case "Нет":
                            SkillProfile(skill);
                            break;
                    }
                    break;
                case "0":
                    Skills();
                    break;
            }
        }
        public static void FindSkill()
        {
            Console.Clear();
            Console.WriteLine("Введите название: ");
            string name = Console.ReadLine();
            Console.WriteLine("Навыки \nВыберите навык:");
            IEnumerable<Skill> list = skillLogic.findSkill(ID,name);
            for (int i = 0; i < list.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. Название: {list.ElementAt(i).Name}");
            }
            int j = int.Parse(Console.ReadLine());
            SkillProfile(list.ElementAt(j - 1));
        }
    }
}
