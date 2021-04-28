using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DataAccess.Data.Repository.IRepository;

namespace WebApplication1.DataAccess.Data.Repository
{
    class UnitOfWork :IUnitOfWork
    {
        // Also require the ApplicationDbContext, when we call by the CategoryRepository 
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
                
        }
        public ICategoryRepository Category { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
