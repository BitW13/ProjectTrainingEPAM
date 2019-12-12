using FileSharing.DAL.Interfaces;
using FileSharing.Entities.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FileSharing.DAL.Models
{
    public class FileAccessRepository : IRepository<FileAccess>
    {
        private readonly IContext _context;

        public FileAccessRepository(IContext context)
        {
            _context = context;
        }

        public void Create(FileAccess item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Name", item.Name, DbType.String)
            };

            _context.Insert("CreateFileAccess", CommandType.StoredProcedure, parameters.ToArray());
        }

        public void Delete(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            _context.Delete("DeleteFileAccess", CommandType.StoredProcedure, parameters.ToArray());
        }

        public IEnumerable<FileAccess> GetAll()
        {
            var fileAccessDataTable = _context.GetDataTable("GetFileAccesses", CommandType.StoredProcedure);
            var fileAccesses = new List<FileAccess>();
            foreach (DataRow row in fileAccessDataTable.Rows)
            {
                var fileAccess = new FileAccess
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString()
                };
                fileAccesses.Add(fileAccess);
            }
            return fileAccesses;
        }

        public FileAccess GetElement(FileAccess item)
        {
            throw new NotImplementedException();
        }

        public FileAccess GetElementById(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            var fileAccessDataTable = _context.GetDataTable("GetFileAccessById", CommandType.StoredProcedure, parameters.ToArray());

            var fileAccesses = new List<FileAccess>();
            foreach (DataRow row in fileAccessDataTable.Rows)
            {
                var fileAccess = new FileAccess
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString()
                };
                fileAccesses.Add(fileAccess);
            }
            return fileAccesses[0];
        }

        public void Update(FileAccess item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", item.Id, DbType.Int32),
                _context.CreateParameter("@Name", item.Name, DbType.String)
            };

            _context.Update("UpdateFileAccess", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
