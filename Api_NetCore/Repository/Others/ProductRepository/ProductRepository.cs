using System.Collections.Generic;
using Api_NetCore.Models;
using Api_NetCore.Data;


namespace Api_NetCore.Repository.Others.ProductRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Product> GetProductsByPrice()
        {
            throw new System.NotImplementedException();
        }
    }
}