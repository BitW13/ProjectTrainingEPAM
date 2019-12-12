using FileSharing.Business.Interfaces;
using FileSharing.DAL.Interfaces;
using FileSharing.Entities.Core;
using System;
using System.Collections.Generic;

namespace FileSharing.Business.Services
{
    public class UserFriendsService : IService<UserFriends>
    {
        private readonly IDataAccess _db;

        public UserFriendsService(IDataAccess db)
        {
            _db = db;
        }

        public void Create(UserFriends item)
        {
            _db.UserFriends.Create(item);
        }

        public void Delete(UserFriends item)
        {
            _db.UserFriends.Delete(item.Id);
        }

        public IEnumerable<UserFriends> GetAll()
        {
            return _db.UserFriends.GetAll();
        }

        public UserFriends GetElement(UserFriends item)
        {
            throw new NotImplementedException();
        }

        public UserFriends GetItemById(int? id)
        {
            return _db.UserFriends.GetElementById(id);
        }

        public void Update(UserFriends item)
        {
            _db.UserFriends.Update(item);
        }
    }
}
