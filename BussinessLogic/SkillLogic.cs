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
    public class SkillLogic : ISkill
    {
        private ISkillDao skillDao;

        public SkillLogic(ISkillDao skillDao)
        {
            this.skillDao = skillDao;
        }
    
        public void Add(Skill value)
        {
            skillDao.Add(value);
        }

        public Skill GetByID(int ID)
        {
            return skillDao.GetByID(ID);
        }

        public IEnumerable<Skill> GetUserSkill(int ID_user)
        {
            return (IEnumerable < Skill > )skillDao.GetUserSkill(ID_user);
        }

        public void Remove(int ID)
        {
            skillDao.Remove(ID);
        }

        public void editDescription(int ID, string Description)
        {
            skillDao.editDescription(ID, Description);
        }

        public void editName(int ID, string Name)
        {
            skillDao.editName(ID, Name);
        }

        public void findSkill(int Name)
        {
            skillDao.findSkill(Name);
        }

    }
}
