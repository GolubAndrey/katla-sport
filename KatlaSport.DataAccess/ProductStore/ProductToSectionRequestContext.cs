namespace KatlaSport.DataAccess.ProductStore
{
    internal class ProductToSectionRequestContext : DomainContextBase<ApplicationDbContext>, IProductToSectionRequestContext
    {
        public ProductToSectionRequestContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<ProductToSectionRequestItem> Requests => GetDbSet<ProductToSectionRequestItem>();
    }
}
