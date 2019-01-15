using FileSharing.DAL.Context;
using FileSharing.DAL.Interfaces;
using FileSharing.DAL.Models;
using FileSharing.Entities.Core;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.DAL
{
    public class DALRegistry:Registry
    {
        public DALRegistry()
        {
            For<IDataAccess>().Use<DataAccess>();
            For<Interfaces.IContext>().Use<FileSharingContext>();
            For<IRepository<Category>>().Use<CategoryRepository>();
            For<IRepository<File>>().Use<FileRepository>();
            For<IRepository<UserRole>>().Use<UserRoleRepository>();
            For<IRepository<User>>().Use<UserRepository>();

            Forward<IDataAccess, DataAccess>();
            Forward<Interfaces.IContext, FileSharingContext>();
            Forward<IRepository<Category>, CategoryRepository>();
            Forward<IRepository<File>, FileRepository>();
            Forward<IRepository<UserRole>, UserRoleRepository>();
            Forward<IRepository<User>, UserRepository>();
        }
    }
}
