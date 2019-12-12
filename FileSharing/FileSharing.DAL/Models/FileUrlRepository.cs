using FileSharing.DAL.Interfaces;
using FileSharing.Entities.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FileSharing.DAL.Models
{
    public class FileUrlRepository : IRepository<FileUrl>
    {
        private readonly IContext _context;

        public FileUrlRepository(IContext context)
        {
            _context = context;
        }

        public void Create(FileUrl item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Url", item.Url, DbType.String),
            };

            _context.Insert("CreateFileUrl", CommandType.StoredProcedure, parameters.ToArray());
        }

        public void Delete(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            _context.Delete("DeleteFileUrl", CommandType.StoredProcedure, parameters.ToArray());
        }

        public IEnumerable<FileUrl> GetAll()
        {
            var fileUrlDataTable = _context.GetDataTable("GetFileUrls", CommandType.StoredProcedure);
            var fileUrls = new List<FileUrl>();
            foreach (DataRow row in fileUrlDataTable.Rows)
            {
                var fileUrl = new FileUrl
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Url = row["Url"].ToString()
                };
                fileUrls.Add(fileUrl);
            }
            return fileUrls;
        }

        public FileUrl GetElement(FileUrl item)
        {
            throw new NotImplementedException();
        }

        public FileUrl GetElementById(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            var fileUrlDataTable = _context.GetDataTable("GetFileUrlById", CommandType.StoredProcedure, parameters.ToArray());

            var fileUrls = new List<FileUrl>();
            foreach (DataRow row in fileUrlDataTable.Rows)
            {
                var fileUrl = new FileUrl
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Url = row["Url"].ToString()
                };
                fileUrls.Add(fileUrl);
            }
            return fileUrls[0];
        }

        public void Update(FileUrl item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Url", item.Url, DbType.String)
            };

            _context.Update("UpdateFileUrl", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
