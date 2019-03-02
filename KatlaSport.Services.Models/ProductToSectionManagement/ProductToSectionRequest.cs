namespace KatlaSport.Services.ProductManagement
{
    public class ProductToSectionRequest
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int HiveId { get; set; }

        public int HiveSectionId { get; set; }

        public int Quantity { get; set; }

        public bool Status { get; set; }
    }
}
