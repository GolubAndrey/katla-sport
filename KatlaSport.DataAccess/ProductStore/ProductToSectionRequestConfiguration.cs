using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.ProductStore
{
    internal sealed class ProductToSectionRequestConfiguration : EntityTypeConfiguration<ProductToSectionRequestItem>
    {
        public ProductToSectionRequestConfiguration()
        {
            ToTable("requests");
            HasKey(i => i.Id);
            HasRequired(i => i.Product).WithMany(i => i.Requests).HasForeignKey(i => i.ProductId);
            HasRequired(i => i.HiveSection).WithMany(i => i.Requests).HasForeignKey(i => i.HiveSectionId);
            Property(i => i.Id).HasColumnName("request_id");
            Property(i => i.Quantity).HasColumnName("request_product_quantity");
            Property(i => i.HiveSectionId).HasColumnName("request_hive_section_id");
            Property(i => i.ProductId).HasColumnName("request_product_id");
        }
    }
}
