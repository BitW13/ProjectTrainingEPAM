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
    public class UserRoleService : IService<UserRole>
    {
        private readonly IDataAccess _db;

        public UserRoleService(IDataAccess db)
        {
            _db = db;
        }

        public void Create(UserRole item)
        {
            _db.UserRoles.Create(item);
        }

        public void Delete(UserRole item)
        {
            _db.UserRoles.Delete(item.Id);
        }

        public IEnumerable<UserRole> GetAll()
        {
            return _db.UserRoles.GetAll();
        }

        public UserRole GetElement(UserRole item)
        {
            return _db.UserRoles.GetElement(item);
        }

        public UserRole GetItemById(int? id)
        {
            return _db.UserRoles.GetElementById(id);
        }

        public void Update(UserRole item)
        {
            _db.UserRoles.Update(item);
        }
    }
}
