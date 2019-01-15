using FileSharing.DAL.Context;
using FileSharing.DAL.Interfaces;
using FileSharing.Entities.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.DAL.Models
{
    public class UserRoleRepository : IRepository<UserRole>
    {
        private IContext _context;

        public UserRoleRepository(IContext context)
        {
            _context = context;
        }

        public void Create(UserRole item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Name", item.Name, DbType.String),
            };

            _context.Insert("CreateUserRole", CommandType.StoredProcedure, parameters.ToArray());
        }

        public void Delete(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            _context.Delete("DeleteUserRole", CommandType.StoredProcedure, parameters.ToArray());
        }

        public IEnumerable<UserRole> GetAll()
        {
            var userRoleDataTable = _context.GetDataTable("GetUserRoles", CommandType.StoredProcedure);
            var userRoles = new List<UserRole>();
            foreach (DataRow row in userRoleDataTable.Rows)
            {
                var userRole = new UserRole
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString()
                };
                userRoles.Add(userRole);
            }
            return userRoles;
        }

        public UserRole GetElement(UserRole item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Name", item.Name, DbType.String)
            };

            var userRolesDataTable = _context.GetDataTable("GetUserRoleByName", CommandType.StoredProcedure, parameters.ToArray());

            var userRoles = new List<UserRole>();
            foreach (DataRow row in userRolesDataTable.Rows)
            {
                var userRole = new UserRole
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString()
                };
                userRoles.Add(userRole);
            }
            if (userRoles.Count != 0)
            {
                return userRoles[0];
            }
            else
            {
                return null;
            }
        }

        public UserRole GetElementById(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            var userRolesDataTable = _context.GetDataTable("GetUserRoleById", CommandType.StoredProcedure, parameters.ToArray());

            var userRoles = new List<UserRole>();
            foreach (DataRow row in userRolesDataTable.Rows)
            {
                var userRole = new UserRole
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString()
                };
                userRoles.Add(userRole);
            }
            return userRoles[0];
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(UserRole item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Login", item.Name, DbType.String)
            };

            _context.Update("UpdateUserRole", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
