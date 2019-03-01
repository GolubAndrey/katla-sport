namespace KatlaSport.DataAccess.ProductStore
{
    /// <summary>
    /// Represent a context for requests domain
    /// </summary>
    public interface IProductToSectionRequestContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="ProductToSectionRequestItem"/> entities.
        /// </summary>
        IEntitySet<ProductToSectionRequestItem> Requests { get; }
    }
}
