using EaApplicationTest.Models;

namespace EaApplicationTest.Interfaces
{
    public interface IProductPage
    {
        Task ClickCreateBtn();
        Task CreateProduct(ProductDto product);
        Task CreateProduct(string name, string description, decimal price, string productType);
    }
}