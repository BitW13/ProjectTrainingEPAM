using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.Business.Interfaces
{
    public interface IService<T>
    {
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        T GetItemById(int? id);
        T GetElement(T item);
        IEnumerable<T> GetAll();
    }
}
