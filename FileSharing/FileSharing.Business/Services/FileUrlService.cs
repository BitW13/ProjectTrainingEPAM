using FileSharing.Business.Interfaces;
using FileSharing.DAL.Interfaces;
using FileSharing.Entities.Core;
using System;
using System.Collections.Generic;

namespace FileSharing.Business.Services
{
    public class FileUrlService : IService<FileUrl>
    {
        private readonly IDataAccess _db;

        public FileUrlService(IDataAccess db)
        {
            _db = db;
        }

        public void Create(FileUrl item)
        {
            _db.FileUrls.Create(item);
        }

        public void Delete(FileUrl item)
        {
            _db.FileUrls.Delete(item.Id);
        }

        public IEnumerable<FileUrl> GetAll()
        {
            return _db.FileUrls.GetAll();
        }

        public FileUrl GetElement(FileUrl item)
        {
            throw new NotImplementedException();
        }

        public FileUrl GetItemById(int? id)
        {
            return _db.FileUrls.GetElementById(id);
        }

        public void Update(FileUrl item)
        {
            _db.FileUrls.Update(item);
        }
    }
}
