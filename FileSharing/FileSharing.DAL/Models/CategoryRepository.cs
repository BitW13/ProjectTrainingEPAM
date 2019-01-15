using FileSharing.DAL.Context;
using FileSharing.DAL.Interfaces;
using FileSharing.Entities.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.DAL.Models
{
    public class CategoryRepository : IRepository<Category>
    {
        private IContext _context;

        public CategoryRepository(IContext context)
        {
            _context = context;
        }

        public void Create(Category item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Name", item.Name, DbType.String)
            };

            _context.Insert("CreateCategory", CommandType.StoredProcedure, parameters.ToArray());
        }

        public void Delete(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            _context.Delete("DeleteCategory", CommandType.StoredProcedure, parameters.ToArray());
        }

        public IEnumerable<Category> GetAll()
        {
            var categoryDataTable = _context.GetDataTable("GetCategories", CommandType.StoredProcedure);
            var categories = new List<Category>();
            foreach(DataRow row in categoryDataTable.Rows)
            {
                var category = new Category
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString()
                };
                categories.Add(category);
            }
            return categories;
        }

        public Category GetElement(Category item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Name", item.Name, DbType.String)
            };

            var categoriesDataTable = _context.GetDataTable("GetCategoryByName", CommandType.StoredProcedure, parameters.ToArray());

            var categories = new List<Category>();
            foreach (DataRow row in categoriesDataTable.Rows)
            {
                var category = new Category
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString()
                };
                categories.Add(category);
            }
            if (categories.Count != 0)
            {
                return categories[0];
            }
            else
            {
                return null;
            }
        }

        public Category GetElementById(int? id)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", id, DbType.Int32)
            };

            var categoriesDataTable = _context.GetDataTable("GetCategoryById", CommandType.StoredProcedure, parameters.ToArray());

            var categories = new List<Category>();
            foreach(DataRow row in categoriesDataTable.Rows)
            {
                var category = new Category
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString()
                };
                categories.Add(category);
            }
            return categories[0];
        }

        public void Update(Category item)
        {
            var parameters = new List<SqlParameter>
            {
                _context.CreateParameter("@Id", item.Id, DbType.Int32),
                _context.CreateParameter("@Name", item.Name, DbType.String)
            };

            _context.Update("UpdateCategory", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
