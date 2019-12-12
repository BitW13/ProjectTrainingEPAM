﻿using FileSharing.DAL.Interfaces;
using FileSharing.Entities.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FileSharing.DAL.Models
{
    public class FileRepository : IRepository<File>
    {
        private readonly IContext _context;

        public FileRepository(IContext context)
        {
            _context = context;
        }

        public void Create(File item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Name", item.Name, DbType.String),
                _context.CreateParameter("@Size", item.Size, DbType.Double),
                _context.CreateParameter("@Description", item.Description, DbType.String),
                _context.CreateParameter("@CategoryId", item.CategoryId, DbType.Int32),
                _context.CreateParameter("@Date", item.DownloadDate, DbType.String),
                _context.CreateParameter("@UserId", item.UserId, DbType.Int32),
                _context.CreateParameter("@FileAccessId", item.FileAccessId, DbType.Int32),
                _context.CreateParameter("@FileUrlId", item.FileUrlId, DbType.Int32)
            };

            _context.Insert("CreateFile", CommandType.StoredProcedure, parameters.ToArray());
        }

        public void Delete(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            _context.Delete("DeleteFile", CommandType.StoredProcedure, parameters.ToArray());
        }

        public IEnumerable<File> GetAll()
        {
            var fileDataTable = _context.GetDataTable("GetFiles", CommandType.StoredProcedure);
            var files = new List<File>();
            foreach (DataRow row in fileDataTable.Rows)
            {
                var file = new File
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Size = Convert.ToDouble(row["Size"]),
                    Description = row["Description"].ToString(),
                    CategoryId = Convert.ToInt32(row["CategoryId"]),
                    FileUrlId = Convert.ToInt32(row["FileUrlId"]),
                    DownloadDate = Convert.ToDateTime(row["Date"]),
                    FileAccessId = Convert.ToInt32(row["FileAccessId"]),
                    UserId = Convert.ToInt32(row["UserId"])
                };
                files.Add(file);
            }
            return files;
        }

        public File GetElement(File item)
        {
            throw new NotImplementedException();
        }

        public File GetElementById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public File GetElementById(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            var filesDataTable = _context.GetDataTable("GetFileById", CommandType.StoredProcedure, parameters.ToArray());

            var files = new List<File>();
            foreach (DataRow row in filesDataTable.Rows)
            {
                var file = new File
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Size = Convert.ToDouble(row["Size"]),
                    Description = row["Description"].ToString(),
                    CategoryId = Convert.ToInt32(row["CategoryId"]),
                    FileUrlId = Convert.ToInt32(row["FileUrlId"]),
                    DownloadDate = Convert.ToDateTime(row["Date"]),
                    FileAccessId = Convert.ToInt32(row["FileAccessId"]),
                    UserId = Convert.ToInt32(row["UserId"])
                };
                files.Add(file);
            }
            return files[0];
        }

        public void Update(File item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", item.Id, DbType.Int32),
                _context.CreateParameter("@Name", item.Name, DbType.String),
                _context.CreateParameter("@Size", item.Size, DbType.Double),
                _context.CreateParameter("@Description", item.Description, DbType.String),
                _context.CreateParameter("@CategoryId", item.CategoryId, DbType.Int32),
                _context.CreateParameter("@Date", item.DownloadDate, DbType.String),
                _context.CreateParameter("@UserId", item.UserId, DbType.Int32),
                _context.CreateParameter("@FileAccessId", item.FileAccessId, DbType.Int32),
                _context.CreateParameter("@FileUrlId", item.FileUrlId, DbType.Int32)
            };

            _context.Update("UpdateFile", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
