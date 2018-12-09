using FileSharing.DAL.Core;
using FileSharing.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.DAL.Models
{
    class UserRepository : IRepository<User>
    {
        public void Create(User item)
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

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetElement(User item)
        {
            throw new NotImplementedException();
        }

        public User GetElementById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
