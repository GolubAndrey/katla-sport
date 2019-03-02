using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.ProductManagement
{
    public interface IProductSectionService
    {
        Task<List<HiveSectionProduct>> GetSectionProductsAsync(int sectionId);
    }
}
