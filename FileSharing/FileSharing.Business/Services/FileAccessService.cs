using FileSharing.Business.Interfaces;
using FileSharing.DAL.Interfaces;
using FileSharing.Entities.Core;
using System;
using System.Collections.Generic;

namespace FileSharing.Business.Services
{
    public class FileAccessService : IService<FileAccess>
    {
        private readonly IDataAccess _db;

        public FileAccessService(IDataAccess db)
        {
            _db = db;
        }

        public void Create(FileAccess item)
        {
            _db.FileAccesses.Create(item);
        }

        public void Delete(FileAccess item)
        {
            _db.FileAccesses.Delete(item.Id);
        }

        public IEnumerable<FileAccess> GetAll()
        {
            return _db.FileAccesses.GetAll();
        }

        public FileAccess GetElement(FileAccess item)
        {
            throw new NotImplementedException();
        }

        public FileAccess GetItemById(int? id)
        {
            return _db.FileAccesses.GetElementById(id);
        }

        public void Update(FileAccess item)
        {
            _db.FileAccesses.Update(item);
        }
    }
}
