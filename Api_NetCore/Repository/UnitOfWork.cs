using Api_NetCore.Data;
using Api_NetCore.Repository.Others.CategoryRepository;
using Api_NetCore.Repository.Others.ProductRepository;

namespace Api_NetCore.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private CategoryRepository _categoryRepository;
        private ProductRepository _productRepository;
        public AppDbContext UnitDbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            UnitDbContext = dbContext;
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository = _categoryRepository ?? new CategoryRepository(UnitDbContext);
            }
            set => throw new System.NotImplementedException();
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository = _productRepository ?? new ProductRepository(UnitDbContext);
            }
            set => throw new System.NotImplementedException();
        }

        public void Commit()
        {
            UnitDbContext.SaveChanges();
        }

        public void Dispose()
        {
            UnitDbContext.Dispose();
        }
    }
}