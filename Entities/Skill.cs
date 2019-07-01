using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Skill
    {
        public int ID { get; set; }
        public int ID_user { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime DateCreate { get; set; }

        public Skill()
        { }
        public Skill(int id_user, string name, string description, string type)
        {
            ID_user = id_user;
            Name = name;
            Description = description;
            Type = type;
            DateCreate = DateTime.Today;
        }
        public override string ToString()
        {
            return $"{ID}. Название: {Name}\n Описание: {Description}\n Тип: {Type}\n";
        }
    }
}
