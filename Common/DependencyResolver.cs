using BusinessLogic;
using BussinessLogic.Interface;
using DAL;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DependencyResolver
    {
        private static string conStr = ConfigurationManager.ConnectionStrings["sqlDao"].ConnectionString;

        private static IUser userLogic;
        private static ISkill skillLogic;
        private static IUserDao userDao;
        private static ISkillDao skillDao;

        public static IUser UserLogic => userLogic ?? new UserLogic(UserDao);

        public static ISkill SkillLogic => skillLogic ?? new SkillLogic(SkillDao);

        public static IUserDao UserDao => userDao ?? new UserDao(conStr);

        public static ISkillDao SkillDao => skillDao ?? new SkillDao(conStr);
    }
}
