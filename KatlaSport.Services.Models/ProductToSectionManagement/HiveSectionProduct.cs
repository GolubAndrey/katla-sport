namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represent a product in section
    /// </summary>
    public class HiveSectionProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int HiveSectionId { get; set; }

        public string Code { get; set; }

        public int Quantity { get; set; }
    }
}
