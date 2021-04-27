using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DataAccess.Data.Repository.IRepository
{
    // Use for category or any class, "T" implemente, or accept any object. 
    public interface IRepository<T> where T: class
    {
        // basic get method, a class that return a generic T or class 
        T Get(int id);

        // Retrieve a list of category by GetAll, with a return Type of IEnumerable
        // GetAll a certain Parameter, filter data, orderBy, and properties
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );
        // Return of one object from filiter 
        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );
        // Add or Remove any entity from database
        void Add(T entity);

        void Remove(int id);
        void Remove(T entity);
    }
}
