using System.Collections.Generic;
using Api_NetCore.Data;
using Api_NetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_NetCore.Repository.Others.CategoryRepository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Category> GetCategoryByProducts()
        {
            return Get().Include(x => x.Products);
        }
    }
}