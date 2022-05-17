using Dukkantek.Inventory.Application.Services.Interface;
using Dukkantek.Inventory.Model.Models.Product;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Dukkantek.Inventory.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(
            IProductService productService)
        {
            _productService = productService;

        }

        [HttpGet]
        [Route("count")]
        public async Task<IActionResult> CountProducts()
        {
            var productsCount = await _productService.CountProducts();

            return Ok(productsCount);
        }

        [HttpPatch]
        [Route("change-status")]
        public async Task<IActionResult> ChangeStatus(ChangeProductStatusRequest changeProductStatusRequest)
        {
            await _productService.ChangeStatus(changeProductStatusRequest);

            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [HttpPatch]
        [Route("sell")]
        public async Task<IActionResult> Sell(SellProductRequest sellProductRequest)
        {
            await _productService.SellProduct(sellProductRequest);

            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
