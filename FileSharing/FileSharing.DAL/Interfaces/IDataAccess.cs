using FileSharing.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.DAL.Interfaces
{
    public interface IDataAccess
    {
        IRepository<Category> Categories { get; set; }

        IRepository<File> Files { get; set; }

        IRepository<UserRole> UserRoles { get; set; }

        IRepository<User> Users { get; set; }
    }
}
