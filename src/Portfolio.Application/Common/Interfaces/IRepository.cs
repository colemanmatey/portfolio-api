using System.Collections.Immutable;
using System.Linq.Expressions;

namespace Portfolio.Application.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        ImmutableList<T> GetAll();
        ImmutableList<T> GetAll(params Expression<Func<T, object>>[] includes);
        void Create(T entity);
        bool Update(int id, T entity);
        void Delete(int id);
    }
}
