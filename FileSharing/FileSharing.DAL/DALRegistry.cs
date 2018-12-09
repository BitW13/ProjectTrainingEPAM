using FileSharing.DAL.Context;
using FileSharing.DAL.Core;
using FileSharing.DAL.Interfaces;
using FileSharing.DAL.Models;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IContext = FileSharing.DAL.Interfaces.IContext;

namespace FileSharing.DAL
{
    public class DALRegistry:Registry
    {
        public DALRegistry()
        {
            //Scan(
            //    scan =>
            //    {
            //        scan.TheCallingAssembly();
            //    });

            For<IRepository<User>>().Use<UserRepository>();
            For<IRepository<Role>>().Use<RoleRepository>();
            For<IRepository<File>>().Use<FileRepository>();
            For<IRepository<Category>>().Use<CategoryRepository>();
            For<IContext>().Use<FileSharingContext>();

        }
    }
}
