using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Common.Interfaces;
using Portfolio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly PortfolioDbContext _context;


        public Repository(PortfolioDbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public ImmutableList<T> GetAll()
        {
            var results = _context.Set<T>().ToList();
            return results.ToImmutableList();
        }

        public ImmutableList<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var results = query.ToList();
            return results.ToImmutableList();

        }

        public T GetById(int id)
        {
            T? result = _context.Set<T>().Find(id);
            if (result == null) 
            { 
               throw new KeyNotFoundException("Project not found");
            }
            return result;
        }

        public bool Update(int id, T entity)
        {
            var result = _context.Set<T>().Find(id);
            if (result is null) return false;

            _context.Entry(result)
                    .CurrentValues
                    .SetValues(entity);

            // Prevent navigation-property changes:
            foreach (var nav in _context.Entry(result).Navigations)
                nav.IsModified = false;

            _context.SaveChanges();
            return true;
        }


        public void Delete(int id)
        {
            T? result = _context.Set<T>().Find(id);

            if (result == null)
            {
                throw new Exception("Resource not found");
            }
            _context.Remove(result);
            _context.SaveChanges();
        }
    }
}
