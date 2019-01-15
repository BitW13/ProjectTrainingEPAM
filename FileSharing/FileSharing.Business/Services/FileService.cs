using FileSharing.DAL.Interfaces;
using FileSharing.DAL.Models;
using FileSharing.Entities.Core;
using FileSharing.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.Business.Services
{
    public class FileService : IService<File>
    {
        private readonly IDataAccess _db;

        public FileService(IDataAccess db)
        {
            _db = db;
        }

        public void Create(File item)
        {
            _db.Files.Create(item);
        }

        public void Delete(File item)
        {
            _db.Files.Delete(item.Id);
        }

        public IEnumerable<File> GetAll()
        {
            return _db.Files.GetAll();
        }

        public File GetElement(File item)
        {
            throw new NotImplementedException();
        }

        public File GetItemById(int? id)
        {
            return _db.Files.GetElementById(id);
        }

        public void Update(File item)
        {
            _db.Files.Update(item);
        }
    }
}
