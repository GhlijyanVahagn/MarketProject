using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager
{
    public interface ICrudOperation<T> where T: class
    {
        void Create(T entity);
        T Read(int Id);

        void Update(T entity);

        void Delete(int Id);

        void Save();
        Task<IEnumerable<T>> GetAllAsync();
        

    }
}
