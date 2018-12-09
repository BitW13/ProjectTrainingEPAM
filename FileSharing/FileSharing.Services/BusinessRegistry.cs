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
            //Scan(
            //    scan =>
            //    {
            //        scan.TheCallingAssembly();
            //    });

            //For<IDataAcces>().Use<DataAcces>();
            //Forward<IDataAcces, DataAcces>();
            //For<IAccessing>().Use<Accessing>();
        }
    }
}
