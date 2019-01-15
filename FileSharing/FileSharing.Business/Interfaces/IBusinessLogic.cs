using FileSharing.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.Business.Interfaces
{
    public interface IBusinessLogic
    {
        IService<Category> Categories { get; set; }

        IService<File> Files { get; set; }

        IService<UserRole> UserRoles { get; set; }

        IService<User> Users { get; set; }
    }
}
