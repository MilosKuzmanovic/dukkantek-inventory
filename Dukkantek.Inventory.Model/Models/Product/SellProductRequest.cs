using System.ComponentModel.DataAnnotations;

namespace Dukkantek.Inventory.Model.Models.Product
{
    public class SellProductRequest
    {
        [Range(1, long.MaxValue, ErrorMessage = "Product id is required.")]
        public long ProductId { get; set; }
    }
}
