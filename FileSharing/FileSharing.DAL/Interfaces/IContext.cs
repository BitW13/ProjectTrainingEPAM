using FileSharing.DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.DAL.Interfaces
{
    public interface IContext
    {
        IEnumerable<Category> GetCategories();
    }
}
