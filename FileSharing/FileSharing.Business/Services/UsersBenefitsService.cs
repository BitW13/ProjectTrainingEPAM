using FileSharing.Business.Interfaces;
using FileSharing.DAL.Interfaces;
using FileSharing.Entities.Core;
using System;
using System.Collections.Generic;

namespace FileSharing.Business.Services
{
    public class UsersBenefitsService : IService<UsersBenefits>
    {
        private readonly IDataAccess _db;

        public UsersBenefitsService(IDataAccess db)
        {
            _db = db;
        }

        public void Create(UsersBenefits item)
        {
            _db.UserBenefits.Create(item);
        }

        public void Delete(UsersBenefits item)
        {
            _db.UserBenefits.Delete(item.Id);
        }

        public IEnumerable<UsersBenefits> GetAll()
        {
            return _db.UserBenefits.GetAll();
        }

        public UsersBenefits GetElement(UsersBenefits item)
        {
            throw new NotImplementedException();
        }

        public UsersBenefits GetItemById(int? id)
        {
            return _db.UserBenefits.GetElementById(id);
        }

        public void Update(UsersBenefits item)
        {
            _db.UserBenefits.Update(item);
        }
    }
}
