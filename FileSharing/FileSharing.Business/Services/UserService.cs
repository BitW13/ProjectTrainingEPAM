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
    public class UserService : IService<User>
    {
        private readonly IDataAccess _db;

        public UserService(IDataAccess db)
        {
            _db = db;
        }

        public void Create(User item)
        {
            _db.Users.Create(item);
        }

        public void Delete(User item)
        {
            _db.Users.Delete(item.Id);
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users.GetAll();
        }

        public User GetElement(User item)
        {
            return _db.Users.GetElement(item);
        }

        public User GetItemById(int? id)
        {
            return _db.Users.GetElementById(id);
        }

        public void Update(User item)
        {
            _db.Users.Update(item);
        }
    }
}
