using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DataAccess.Data.Repository.IRepository;

namespace WebApplication1.DataAccess.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        // Access database with use of the DBContexts class, always.
        protected readonly DbContext Context;
        internal DbSet<T> dbSet;

        // Initialize Contexts with us of dependency injection 
        public Repository (DbContext context)
        {
            Context = context;
            this.dbSet = context.Set<T>();
        }


        public void Add(T entity)
        {
            // With entity add to existing dbSet
            dbSet.Add(entity);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if(filter != null)
            {
                // Append the filter on the query, and implement all filter 
                query = query.Where(filter);
            }

            //Include properties will be comma seperated, check for include properties
            if(includeProperties != null)
            {
                foreach(var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    // Each include and property will then add to query
                    query = query.Include(includeProperty);
                }

            }
  
            if(orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                // Append the filter on the query, and implement all filter 
                query = query.Where(filter);
            }

            //Include properties will be comma seperated, check for include properties
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    // Each include and property will then add to query
                    query = query.Include(includeProperty);
                }

            }
            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
            T entityToRemove = dbSet.Find(id);
            Remove(entityToRemove);

        }

        public void Remove(T entity)
        {
          
            dbSet.Remove(entity);
        }
    }
}
