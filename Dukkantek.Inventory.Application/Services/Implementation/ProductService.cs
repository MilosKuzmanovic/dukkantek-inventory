using AutoMapper;
using Dukkantek.Inventory.Infrastructure.Repositories.Interface;
using Dukkantek.Inventory.Model.Models.Product;
using Dukkantek.Inventory.Application.Services.Interface;
using Dukkantek.Inventory.Model.Error;
using Dukkantek.Inventory.Model.Models.Enum;

namespace Dukkantek.Inventory.Application.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<CountProductsDto>> CountProducts()
        {
            return await _productRepository.CountProductsByStatus();
        }

        public async Task ChangeStatus(ChangeProductStatusRequest changeProductStatusRequest)
        {
            var productEntity = await _productRepository.GetByIdAsync(changeProductStatusRequest.ProductId);

            if (productEntity == null)
            {
                throw new CustomException($"Product with id {changeProductStatusRequest.ProductId} does not exist.");
            }

            productEntity.UpdateStatus(changeProductStatusRequest.ProductStatus);

            await _productRepository.SaveChangesAsync();
        }

        public async Task SellProduct(SellProductRequest sellProductRequest)
        {
            var productEntity = await _productRepository.GetByIdAsync(sellProductRequest.ProductId);

            if (productEntity == null)
            {
                throw new CustomException($"Product with id {sellProductRequest.ProductId} does not exist.");
            }

            productEntity.UpdateStatus(ProductStatus.Sold.ToString());

            await _productRepository.SaveChangesAsync();
        }
    }
}
