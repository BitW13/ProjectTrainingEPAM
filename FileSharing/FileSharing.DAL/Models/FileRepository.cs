using FileSharing.DAL.Core;
using FileSharing.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.DAL.Models
{
    class FileRepository : IRepository<File>
    {
        public void Create(File item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<File> GetAll()
        {
            throw new NotImplementedException();
        }

        public File GetElement(File item)
        {
            throw new NotImplementedException();
        }

        public File GetElementById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(File item)
        {
            throw new NotImplementedException();
        }
    }
}
