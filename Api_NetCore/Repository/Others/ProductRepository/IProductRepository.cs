using System.Collections.Generic;
using Api_NetCore.Models;

namespace Api_NetCore.Repository.Others.ProductRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductsByPrice();

    }
}