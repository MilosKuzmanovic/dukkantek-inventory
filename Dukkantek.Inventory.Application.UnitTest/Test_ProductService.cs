using Dukkantek.Inventory.Application.Services.Implementation;
using Dukkantek.Inventory.Application.Services.Interface;
using Dukkantek.Inventory.Infrastructure.Repositories.Interface;
using Dukkantek.Inventory.Model.Entities;
using Dukkantek.Inventory.Model.Error;
using Moq;
using Shouldly;

namespace Dukkantek.Inventory.Application.UnitTest
{
    public class Tests
    {
        IProductRepository _productRepository;
        IProductService _productService;

        [SetUp]
        public void Setup()
        {
            var mock = new Mock<IProductRepository>();

            Product? emptyProduct = null;

            mock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(emptyProduct);

            _productRepository = mock.Object;

            _productService = new ProductService(_productRepository, null);

        }

        [Test]
        public void ChangeStatus_ThrowExceptionForNotExistingProduct()
        {
            Should.ThrowAsync<CustomException>(_productService.ChangeStatus(null));
        }
    }
}