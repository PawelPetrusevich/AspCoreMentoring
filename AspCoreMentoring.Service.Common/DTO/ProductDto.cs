namespace AspCoreMentoring.Service.Common.DTO
{
    public class ProductDto
    {
        public string ProductName { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal UnitPrice { get; set; }

        public CategoryLinkDto Category { get; set; }

        public SupplierLinkDto Supplier { get; set; }
    }
}