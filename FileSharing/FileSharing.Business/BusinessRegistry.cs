using FileSharing.Entities.Core;
using FileSharing.Business.Interfaces;
using FileSharing.Business.Services;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.Services
{
    public class BusinessRegistry:Registry
    {
        public BusinessRegistry()
        {
            For<IBusinessLogic>().Use<BusinessLogic>();
            For<IService<Category>>().Use<CategoryService>();
            For<IService<File>>().Use<FileService>();
            For<IService<UserRole>>().Use<UserRoleService>();
            For<IService<User>>().Use<UserService>();

            Forward<IBusinessLogic, BusinessLogic>();
            Forward<IService<Category>, CategoryService>();
            Forward<IService<File>, FileService>();
            Forward<IService<UserRole>, UserRoleService>();
            Forward<IService<User>, UserService>();
        }
    }
}
