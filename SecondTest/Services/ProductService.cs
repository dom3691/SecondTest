using SecondTest.Entities;
using SecondTest.Persistence.Interfaces;
using SecondTest.Services.Interfaces;

namespace SecondTest.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<Product> GetProductByid(Guid id)
        {
            var products = _productRepository.GetProductById(id);

            return products;
        }
    }
}
