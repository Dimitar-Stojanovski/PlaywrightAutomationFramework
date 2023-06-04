using Microsoft.Playwright;

namespace EaApplicationTest.Interfaces
{
    public interface IProductListPage
    {
        Task ClickCreateProductLink();
        Task ClickEditProductDetails(string _name);
        Task<ILocator> VerifyProductName();
    }
}