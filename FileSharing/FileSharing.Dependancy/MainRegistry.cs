using System;
using FileSharing.DAL;
using StructureMap;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSharing.Entities.Core;
using FileSharing.Services;

namespace FileSharing.Dependancy
{
    public class MainRegistry:Registry
    {
        public MainRegistry()
        {
            Scan(
                scan => {
                    scan.WithDefaultConventions();
                    scan.AssemblyContainingType<BusinessLogic>();
                    scan.AssemblyContainingType<DataAccess>();
                    scan.LookForRegistries();
                });

        }
    }
}
