using Dukkantek.Inventory.Model.Entities;
using Dukkantek.Inventory.Model.Models.Enum;
using Shouldly;

namespace Dukkantek.Inventory.Model.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UpdateStatus_Success()
        {
            var product = new Product
            {
                Status = ProductStatus.InStock.ToString()
            };

            product.UpdateStatus(ProductStatus.Sold.ToString());

            product.Status.ShouldBe(ProductStatus.Sold.ToString());
        }
    }
}