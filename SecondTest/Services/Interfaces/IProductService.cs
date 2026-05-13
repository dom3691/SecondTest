using SecondTest.Entities;

namespace SecondTest.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductByid(Guid id);
    }
}
