using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ProductCatalogue;
using KatlaSport.DataAccess.ProductStoreHive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represent a product section service.
    /// </summary>
    public class ProductSectionService : IProductSectionService
    {
        private readonly IProductCatalogueContext _productContext;
        private readonly IProductStoreHiveContext _sectionContext;
        private readonly IUserContext _userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductSectionService"/> class with specified <see cref="IProductCatalogueContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IProductCatalogueContext"/>.</param>
        /// <param name="userContext">A <see cref="IUserContext"/>.</param>
        public ProductSectionService(IProductCatalogueContext productContext, IProductStoreHiveContext sectionContext, IUserContext userContext)
        {
            _productContext = productContext ?? throw new ArgumentNullException();
            _sectionContext = sectionContext ?? throw new ArgumentNullException();
            _userContext = userContext ?? throw new ArgumentNullException();
        }

        public async Task<List<HiveSectionProductListItem>> GetSectionProductsAsync(int sectionId)
        {
            var dbSections = await _sectionContext.Sections.Where(s => s.Id == sectionId).ToArrayAsync();
            if (dbSections.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbProducts = await _productContext.Products.Select(p => p.Items.Where(pr => pr.HiveSectionId == sectionId).FirstOrDefault()).Where(x => x != null).ToArrayAsync();
            var products = dbProducts.Select(p => Mapper.Map<HiveSectionProductListItem>(p)).ToList();

            var dbProductsForInformation = await _productContext.Products.ToArrayAsync();
            var productsForInformation = dbProductsForInformation.Select(p => Mapper.Map<ProductListItem>(p)).ToList();
            var resultProducts = products.Join(productsForInformation, e => e.Id, o => o.Id, (e, o) => new HiveSectionProductListItem()
            {
                Id = e.Id,
                Name = o.Name,
                Code = o.Code,
                Quantity = e.Quantity
            });

            return resultProducts.ToList();
        }
    }
}
