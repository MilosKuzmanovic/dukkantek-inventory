using Dukkantek.Inventory.Model.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Dukkantek.Inventory.Model.Models.Product
{
    public class ChangeProductStatusRequest
    {
        [Range(1, long.MaxValue, ErrorMessage = "Product id is required.")]
        public long ProductId { get; set; }

        [Required]
        [EnumDataType(typeof(ProductStatus))]
        public string ProductStatus { get; set; }
    }
}
