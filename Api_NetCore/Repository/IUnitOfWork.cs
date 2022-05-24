using Api_NetCore.Repository.Others.CategoryRepository;
using Api_NetCore.Repository.Others.ProductRepository;

namespace Api_NetCore.Repository
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        void Commit();
        void Dispose();
    }
}