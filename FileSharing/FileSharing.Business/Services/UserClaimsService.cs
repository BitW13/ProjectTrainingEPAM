using FileSharing.Business.Interfaces;
using FileSharing.DAL.Interfaces;
using FileSharing.Entities.Core;
using System;
using System.Collections.Generic;

namespace FileSharing.Business.Services
{
    public class UserClaimsService : IService<UserClaims>
    {
        private readonly IDataAccess _db;

        public UserClaimsService(IDataAccess db)
        {
            _db = db;
        }

        public void Create(UserClaims item)
        {
            _db.UserClaims.Create(item);
        }

        public void Delete(UserClaims item)
        {
            _db.UserClaims.Delete(item.Id);
        }

        public IEnumerable<UserClaims> GetAll()
        {
            return _db.UserClaims.GetAll();
        }

        public UserClaims GetElement(UserClaims item)
        {
            throw new NotImplementedException();
        }

        public UserClaims GetItemById(int? id)
        {
            return _db.UserClaims.GetElementById(id);
        }

        public void Update(UserClaims item)
        {
            _db.UserClaims.Update(item);
        }
    }
}
