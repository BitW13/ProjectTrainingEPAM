using FileSharing.DAL.Interfaces;
using FileSharing.Entities.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FileSharing.DAL.Models
{
    public class UserBenefitsRepository : IRepository<UsersBenefits>
    {
        private readonly IContext _context;

        public UserBenefitsRepository(IContext context)
        {
            _context = context;
        }

        public void Create(UsersBenefits item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@UserId", item.UserId, DbType.Int32),
                _context.CreateParameter("@BenefitsId", item.BenefitsId, DbType.Int32)
            };

            _context.Insert("CreateUsersBenefits", CommandType.StoredProcedure, parameters.ToArray());
        }

        public void Delete(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            _context.Delete("DeleteUsersBenefits", CommandType.StoredProcedure, parameters.ToArray());
        }

        public IEnumerable<UsersBenefits> GetAll()
        {
            var usersBenefitsDataTable = _context.GetDataTable("GetusersBenefitsDataTable", CommandType.StoredProcedure);
            var usersBenefits = new List<UsersBenefits>();
            foreach (DataRow row in usersBenefitsDataTable.Rows)
            {
                var usersBenefit = new UsersBenefits
                {
                    Id = Convert.ToInt32(row["Id"]),
                    UserId = Convert.ToInt32(row["UserId"]),
                    BenefitsId = Convert.ToInt32(row["BenefitsId"])
                };
                usersBenefits.Add(usersBenefit);
            }
            return usersBenefits;
        }

        public UsersBenefits GetElement(UsersBenefits item)
        {
            throw new NotImplementedException();
        }

        public UsersBenefits GetElementById(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            var usersBenefitsDataTable = _context.GetDataTable("GetUsersBenefitsById", CommandType.StoredProcedure, parameters.ToArray());

            var usersBenefits = new List<UsersBenefits>();
            foreach (DataRow row in usersBenefitsDataTable.Rows)
            {
                var usersBenefit = new UsersBenefits
                {
                    Id = Convert.ToInt32(row["Id"]),
                    BenefitsId = Convert.ToInt32(row["BenefitsId"]),
                    UserId = Convert.ToInt32(row["UserId"])
                };
                usersBenefits.Add(usersBenefit);
            }
            return usersBenefits[0];
        }

        public void Update(UsersBenefits item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@UserId", item.UserId, DbType.Int32),
                _context.CreateParameter("@BenefitsId", item.BenefitsId, DbType.Int32)
            };

            _context.Update("UpdateUsersBenefits", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
