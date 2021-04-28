using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DataAccess.Data.Repository.IRepository
{
    // Is whatever is done in a single batch of work, access to all repository, save method, and will push changes to database
    public interface IUnitOfWork : IDisposable  
    {
        ICategoryRepository Category { get; }
        void Save();
    }
}
