using FileSharing.Business.Interfaces;
using FileSharing.DAL.Interfaces;
using FileSharing.Entities.Core;
using System;
using System.Collections.Generic;

namespace FileSharing.Business.Services
{
    public class BenefitsService : IService<Benefits>
    {
        private readonly IDataAccess _db;

        public BenefitsService(IDataAccess db)
        {
            _db = db;
        }

        public void Create(Benefits item)
        {
            _db.Benefits.Create(item);
        }

        public void Delete(Benefits item)
        {
            _db.Benefits.Delete(item.Id);
        }

        public IEnumerable<Benefits> GetAll()
        {
            return _db.Benefits.GetAll();
        }

        public Benefits GetElement(Benefits item)
        {
            throw new NotImplementedException();
        }

        public Benefits GetItemById(int? id)
        {
            return _db.Benefits.GetElementById(id);
        }

        public void Update(Benefits item)
        {
            _db.Benefits.Update(item);
        }
    }
}
