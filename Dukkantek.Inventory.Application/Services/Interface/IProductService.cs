using Dukkantek.Inventory.Model.Models.Product;

namespace Dukkantek.Inventory.Application.Services.Interface
{
    public interface IProductService
    {
        Task<List<CountProductsDto>> CountProducts();

        Task ChangeStatus(ChangeProductStatusRequest changeProductStatusRequest);

        Task SellProduct(SellProductRequest sellProductRequest);
    }
}
