using FileSharing.DAL.Interfaces;
using FileSharing.Entities.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FileSharing.DAL.Models
{
    public class BenefitsRepository : IRepository<Benefits>
    {
        private readonly IContext _context;

        public BenefitsRepository(IContext context)
        {
            _context = context;
        }

        public void Create(Benefits item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Name", item.Name, DbType.String),
                _context.CreateParameter("@Size", item.Size, DbType.Double)
            };

            _context.Insert("CreateBenefits", CommandType.StoredProcedure, parameters.ToArray());
        }

        public void Delete(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            _context.Delete("DeleteBenefits", CommandType.StoredProcedure, parameters.ToArray());
        }

        public IEnumerable<Benefits> GetAll()
        {
            var benefitsDataTable = _context.GetDataTable("GetBenefits", CommandType.StoredProcedure);
            var benefits = new List<Benefits>();
            foreach (DataRow row in benefitsDataTable.Rows)
            {
                var benefit = new Benefits
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Size = Convert.ToDouble(row["Size"])
                };
                benefits.Add(benefit);
            }
            return benefits;
        }

        public Benefits GetElement(Benefits item)
        {
            throw new NotImplementedException();
        }

        public Benefits GetElementById(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            var benefitsDataTable = _context.GetDataTable("GetBenefitsById", CommandType.StoredProcedure, parameters.ToArray());

            var benefits = new List<Benefits>();
            foreach (DataRow row in benefitsDataTable.Rows)
            {
                var benefit = new Benefits
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Size = Convert.ToDouble(row["Size"])
                };
                benefits.Add(benefit);
            }
            return benefits[0];
        }

        public void Update(Benefits item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", item.Id, DbType.Int32),
                _context.CreateParameter("@Name", item.Name, DbType.String),
                _context.CreateParameter("@Size", item.Size, DbType.Double)
            };

            _context.Update("UpdateBenefits", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
