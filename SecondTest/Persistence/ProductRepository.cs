using Microsoft.EntityFrameworkCore;
using SecondTest.Entities;
using SecondTest.Infrastructure.Interfaces;
using SecondTest.Persistence.Interfaces;

namespace SecondTest.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public ProductRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeletProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductById(Guid id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);

            return product;
        }

        public Task<Product> UpdateProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
