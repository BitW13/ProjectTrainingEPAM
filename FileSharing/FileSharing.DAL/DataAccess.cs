using FileSharing.DAL.Interfaces;
using FileSharing.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.DAL
{
    public class DataAccess : IDataAccess
    {
        public DataAccess(IRepository<Category> categories, IRepository<File> files, IRepository<UserRole> userRoles, IRepository<User> users)
        {
            Categories = categories;
            Files = files;
            UserRoles = userRoles;
            Users = users;
        }

        public IRepository<Category> Categories { get; set; }
        public IRepository<File> Files { get; set; }
        public IRepository<UserRole> UserRoles { get; set; }
        public IRepository<User> Users { get; set; }
    }
}
