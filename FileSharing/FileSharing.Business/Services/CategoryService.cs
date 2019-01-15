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
    public class CategoryService : IService<Category>
    {
        private readonly IDataAccess _db;

        public CategoryService(IDataAccess db)
        {
            _db = db;
        }

        public void Create(Category item)
        {
            _db.Categories.Create(item);
        }

        public void Delete(Category item)
        {
            _db.Categories.Delete(item.Id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Categories.GetAll();
        }

        public Category GetElement(Category item)
        {
            return _db.Categories.GetElement(item);
        }

        public Category GetItemById(int? id)
        {
            return _db.Categories.GetElementById(id);
        }

        public void Update(Category item)
        {
            _db.Categories.Update(item);
        }
    }
}
