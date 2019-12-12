using FileSharing.DAL.Interfaces;
using FileSharing.Entities.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FileSharing.DAL.Models
{
    public class UserRepository : IRepository<User>
    {
        private readonly IContext _context;

        public UserRepository(IContext context)
        {
            _context = context;
        }

        public void Create(User item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Login", item.Login, DbType.String),
                _context.CreateParameter("@Password", item.Password, DbType.String),
                _context.CreateParameter("@Email", item.Email, DbType.String),
                _context.CreateParameter("@UserRoleId", item.UserRoleId, DbType.Int32)
            };

            _context.Insert("CreateUser", CommandType.StoredProcedure, parameters.ToArray());
        }

        public void Delete(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            _context.Delete("DeleteUser", CommandType.StoredProcedure, parameters.ToArray());
        }

        public IEnumerable<User> GetAll()
        {
            var userDataTable = _context.GetDataTable("GetUsers", CommandType.StoredProcedure);
            var users = new List<User>();
            foreach (DataRow row in userDataTable.Rows)
            {
                var user = new User
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Login = row["Login"].ToString(),
                    Password = row["Password"].ToString(),
                    Email = row["Email"].ToString(),
                    UserRoleId = Convert.ToInt32(row["UserRoleId"])
                };
                users.Add(user);
            }
            return users;
        }

        public User GetElement(User item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Login", item.Login, DbType.String)
            };

            var usersDataTable = _context.GetDataTable("GetUserByLogin", CommandType.StoredProcedure, parameters.ToArray());

            var users = new List<User>();
            foreach (DataRow row in usersDataTable.Rows)
            {
                var user = new User
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Login = row["Login"].ToString(),
                    Password = row["Password"].ToString(),
                    Email = row["Email"].ToString(),
                    UserRoleId = Convert.ToInt32(row["UserRoleId"])
                };
                users.Add(user);
            }
            if (users.Count != 0)
            {
                return users[0];
            }
            else
            {
                return null;
            }
        }

        public User GetElementById(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            var usersDataTable = _context.GetDataTable("GetUserById", CommandType.StoredProcedure, parameters.ToArray());

            var users = new List<User>();
            foreach (DataRow row in usersDataTable.Rows)
            {
                var user = new User
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Login = row["Login"].ToString(),
                    Password = row["Password"].ToString(),
                    Email = row["Email"].ToString(),
                    UserRoleId = Convert.ToInt32(row["UserRoleId"])
                };
                users.Add(user);
            }
            return users[0];
        }

        public void Update(User item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", item.Id, DbType.Int32),
                _context.CreateParameter("@Login", item.Login, DbType.String),
                _context.CreateParameter("@Password", item.Password, DbType.String),
                _context.CreateParameter("@Email", item.Email, DbType.String),
                _context.CreateParameter("@UserRoleId", item.UserRoleId, DbType.Int32)
            };

            _context.Update("UpdateUser", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
