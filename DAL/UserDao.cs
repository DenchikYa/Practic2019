using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DAL.Interface;
using Entities;

namespace DAL
{
    public class UserDao : IUserDao
    {
        private string _connectionString;

        public UserDao(String cntStr)
        {
            this._connectionString = cntStr;
        }

        public void Add(User value)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "addUser";
                cmd.Parameters.AddWithValue(@"FullName", value.FullName);
                cmd.Parameters.AddWithValue(@"DateOfBrith", value.DateOfBrith);
                cmd.Parameters.AddWithValue(@"age", value.Age);
                cmd.Parameters.AddWithValue(@"sex", value.Sex);
                cmd.Parameters.AddWithValue(@"login", value.Login);
                cmd.Parameters.AddWithValue(@"password", value.Password);
                cmd.Parameters.AddWithValue(@"date_registration", value.DateRegistration);
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

        public User GetByID(int ID)
        {
            User user = new User();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getUserById";
                cmd.Parameters.AddWithValue(@"ID", ID);
                connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InitializeUser(ref user, reader);
                }
            }
            return user;
        }

        public int Authorization(string Login, string Password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "authorizationUser";
                cmd.Parameters.AddWithValue(@"Login", Login);
                cmd.Parameters.AddWithValue(@"Password", Password);
                connection.Open();

                return (int)cmd.ExecuteScalar();
            }
        }

        public void EditFullName(int ID, string FullName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "editFullNameUser";
                cmd.Parameters.AddWithValue(@"ID", ID);
                cmd.Parameters.AddWithValue(@"FullName", FullName);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditPassword(int ID, string Password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "editPasswordUser";
                cmd.Parameters.AddWithValue(@"ID", ID);
                cmd.Parameters.AddWithValue(@"Password", Password);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public int FindForLogin(string Login)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "findForLogin";
                cmd.Parameters.AddWithValue(@"Login", Login);
                connection.Open();
                if (cmd.ExecuteScalar() != null) return (int)cmd.ExecuteScalar(); else return 0;
            }
        }

        private User InitializeUser(ref User user, SqlDataReader reader)
        {
            user = new User
            {
                ID = (int)reader["ID"],
                FullName = (string)reader["FullName"],
                DateOfBrith = (DateTime)reader["date_brith"],
                Age = (int)reader["age"],
                Sex = (string)reader["sex"],
                Login = (string)reader["login"],
                Password = (string)reader["password"],
                DateRegistration = (DateTime)reader["date_registration"],
            };

            return user;
        }
    }
}
