using FileSharing.DAL.Interfaces;
using FileSharing.Entities.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FileSharing.DAL.Models
{
    public class UserClaimsRepository : IRepository<UserClaims>
    {
        private readonly IContext _context;

        public UserClaimsRepository(IContext context)
        {
            _context = context;
        }

        public void Create(UserClaims item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@PhoneNumber", item.PhoneNumber, DbType.String),
                _context.CreateParameter("@DateOfRegistration", item.DateOfRegistration, DbType.DateTime),
                _context.CreateParameter("@DoB", item.DoB, DbType.DateTime)
            };

            _context.Insert("CreateUserClaims", CommandType.StoredProcedure, parameters.ToArray());
        }

        public void Delete(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            _context.Delete("DeleteUserClaims", CommandType.StoredProcedure, parameters.ToArray());
        }

        public IEnumerable<UserClaims> GetAll()
        {
            var userClaimsDataTable = _context.GetDataTable("GetUserClaimses", CommandType.StoredProcedure);
            var userClaimses = new List<UserClaims>();
            foreach (DataRow row in userClaimsDataTable.Rows)
            {
                var userClaims = new UserClaims
                {
                    Id = Convert.ToInt32(row["Id"]),
                    DateOfRegistration = Convert.ToDateTime(row["DateOfRegistration"]),
                    DoB = Convert.ToDateTime(row["DoB"]),
                    PhoneNumber = row["PhoneNumber"].ToString()
                };
                userClaimses.Add(userClaims);
            }
            return userClaimses;
        }

        public UserClaims GetElement(UserClaims item)
        {
            throw new NotImplementedException();
        }

        public UserClaims GetElementById(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            var userClaimsDataTable = _context.GetDataTable("GetUserClaimsById", CommandType.StoredProcedure, parameters.ToArray());

            var userClaimses = new List<UserClaims>();
            foreach (DataRow row in userClaimsDataTable.Rows)
            {
                var userClaims = new UserClaims
                {
                    Id = Convert.ToInt32(row["Id"]),
                    DateOfRegistration = Convert.ToDateTime(row["DateOfRegistration"]),
                    DoB = Convert.ToDateTime(row["DoB"]),
                    PhoneNumber = row["PhoneNumber"].ToString()
                };
                userClaimses.Add(userClaims);
            }
            return userClaimses[0];
        }

        public void Update(UserClaims item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", item.Id, DbType.Int32),
                _context.CreateParameter("@PhoneNumber", item.PhoneNumber, DbType.String),
                _context.CreateParameter("@DateOfRegistration", item.DateOfRegistration, DbType.DateTime),
                _context.CreateParameter("@DoB", item.DoB, DbType.DateTime)
            };

            _context.Update("UpdateUserClaims", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
