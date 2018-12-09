using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.DAL.Interfaces
{
    public interface IRepository<T>: IDisposable
    {
        IEnumerable<T> GetAll();

        T GetElementById(Guid? id);

        T GetElement(T item);

        void Create(T item);

        void Delete(Guid? id);

        void Update(T item);

        void Save();
    }
}
