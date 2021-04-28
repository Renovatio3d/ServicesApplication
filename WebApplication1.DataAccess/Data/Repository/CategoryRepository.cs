using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DataAccess.Data.Repository.IRepository;
using WebApplication1.Models;

namespace WebApplication1.DataAccess.Data.Repository
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;    
        }
        // implement the two methods from ICategoryRepository
        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
            //Get the drop down list for category, from  ApplicationDbContext.cs
            //Linq for use with Select
            return _db.Category.Select(i=> new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Category category)
        {
            
            var objFromDb = _db.Category.FirstOrDefault(S => S.Id == category.Id);
            // Updating the object inside the database, with the properties retrieved inside the category

            objFromDb.Name = category.Name;
            objFromDb.DisplayOrder = category.DisplayOrder;

            _db.SaveChanges();
        }
    }
}
