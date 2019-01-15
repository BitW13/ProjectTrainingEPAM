using FileSharing.Entities.Core;
using FileSharing.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.Services
{
    public class BusinessLogic : IBusinessLogic
    {
        public BusinessLogic(IService<Category> categories, IService<File> files, IService<UserRole> userRoles, IService<User> users)
        {
            Categories = categories;
            Files = files;
            UserRoles = userRoles;
            Users = users;
        }

        public IService<Category> Categories { get; set; }
        public IService<File> Files { get; set; }
        public IService<UserRole> UserRoles { get; set; }
        public IService<User> Users { get; set; }
    }
}
