using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DataAccess.Data.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        //Select list for dropdown when displaying complete list of categories
        IEnumerable<SelectListItem> GetCategoryListForDropDown();

        // Second method, passing category directly 
        void Update(Category category);
    }
}
