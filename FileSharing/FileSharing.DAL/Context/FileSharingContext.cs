using FileSharing.DAL.Core;
using FileSharing.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.DAL.Context
{
    public class FileSharingContext : IContext
    {
        public FileSharingContext()
        {
        }

        public IEnumerable<Category> GetCategories()
        {
            return new List<Category>() { new Category() };
        }
    }
}
