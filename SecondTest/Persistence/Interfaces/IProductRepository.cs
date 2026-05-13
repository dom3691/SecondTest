using SecondTest.Entities;

namespace SecondTest.Persistence.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(Guid id);
        Task<List<Product>>GetAllProducts();
        void DeletProductById(int id);
        Task<Product> UpdateProductById(int id);



    }
}
