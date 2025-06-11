using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Create(T entity);
        bool Update(int id, T entity);
        void Delete(int id);
    }
}
