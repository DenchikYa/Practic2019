using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using DAL.Interface;
using Entities;

namespace DAL
{
    public class SkillDao : ISkillDao
    {
        private string _connectionString;

        public SkillDao(String cntStr)
        {
            this._connectionString = cntStr;
        }

        public void Add(Skill value)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "addSkill";
                cmd.Parameters.AddWithValue(@"ID_user", value.ID_user);
                cmd.Parameters.AddWithValue(@"name", value.Name);
                cmd.Parameters.AddWithValue(@"description", value.Description);
                cmd.Parameters.AddWithValue(@"type", value.Type);
                cmd.Parameters.AddWithValue(@"date_creation", value.DateCreate);

                var id = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@ID",
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(id);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public IEnumerable<Skill> GetUserSkill(int id_user)
        {
            List<Skill> skills = new List<Skill>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getSkillsByIDUser";
                cmd.Parameters.AddWithValue(@"ID", id_user);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    skills.Add(new Skill
                    {
                        ID = (int)reader["ID"],
                        ID_user = (int)reader["ID_user"],
                        Name = (string)reader["name"],
                        Description = (string)reader["description"],
                        Type = (string)reader["type"],
                        DateCreate = (DateTime)reader["date_creation"]
                    });
                }
            }
            return skills;
        }
        public Skill GetByID(int ID)
        {
            Skill skill = new Skill();
            //using (var connection = new SqlConnection(_connectionString))
            //{
            //    var cmd = connection.CreateCommand();
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.CommandText = "GetAwardByID";
            //    cmd.Parameters.AddWithValue(@"ID", ID);
            //    connection.Open();
            //    var reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        skill.ID = (int)reader["ID"];
            //        skill.ID_user = (int)reader["ID_user"];
            //        skill.Name = (string)reader["name"];
            //        skill.Description = (string)reader["description"];
            //        skill.Type = (string)reader["type"];
            //        skill.DateCreate = (DateTime)reader["date_creation"];
            //    }
            //}
            return skill;
        }
        public void Remove(int ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "deleteSkill";
                cmd.Parameters.AddWithValue(@"ID", ID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void editDescription(int ID, string Description)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "editDescriptionSkill";
                cmd.Parameters.AddWithValue(@"ID", ID);
                cmd.Parameters.AddWithValue(@"Description", Description);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void editName(int ID, string Name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "editNameSkill";
                cmd.Parameters.AddWithValue(@"ID", ID);
                cmd.Parameters.AddWithValue(@"Name", Name);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public IEnumerable<Skill> findSkill(int ID_user, string Name)
        {
            List<Skill> skills = new List<Skill>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "findSkill";
                cmd.Parameters.AddWithValue(@"ID", ID_user);
                cmd.Parameters.AddWithValue(@"Name", Name);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    skills.Add(new Skill
                    {
                        ID = (int)reader["ID"],
                        ID_user = (int)reader["ID_user"],
                        Name = (string)reader["name"],
                        Description = (string)reader["description"],
                        Type = (string)reader["type"],
                        DateCreate = (DateTime)reader["date_creation"]
                    });
                }
            }
            return skills;
        }
    }
}
