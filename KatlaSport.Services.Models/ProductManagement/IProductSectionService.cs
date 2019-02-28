using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.ProductManagement
{
    public interface IProductSectionService
    {
        Task<List<HiveSectionProductListItem>> GetSectionProductsAsync(int sectionId);
    }
}
