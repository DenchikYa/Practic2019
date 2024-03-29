﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.Interface
{
    public interface ISkillDao
    {
        void Add(Skill value);

        void Remove(int ID);

        Skill GetByID(int ID);

        IEnumerable<Skill> GetUserSkill(int ID_user);

        void editDescription(int ID, string Description);

        void editName(int ID, string Name);

        IEnumerable<Skill> findSkill(int ID, string Name);
    }
}
