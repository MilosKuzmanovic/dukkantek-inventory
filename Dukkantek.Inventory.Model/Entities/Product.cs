namespace Dukkantek.Inventory.Model.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public string Weight { get; set; }

        public string Status { get; set; }

        public long? CategoryId { get; set; }

        public Category Category { get; set; }

        public void UpdateStatus (string status)
        {
            Status = status;
        }
    }
}
