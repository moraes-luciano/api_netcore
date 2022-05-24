using System.Collections.Generic;
using Api_NetCore.Models;

namespace Api_NetCore.Repository.Others.CategoryRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetCategoryByProducts();
    }
}