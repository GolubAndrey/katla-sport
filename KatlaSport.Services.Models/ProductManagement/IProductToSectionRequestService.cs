using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.ProductManagement
{
    public interface IProductToSectionRequestService
    {
        Task<List<ProductToSectionRequest>> GetSectionRequests(int sectionId);

        Task<ProductToSectionRequest> CreateRequestAsync(UpdateProductToSectionRequestRequest createRequest);
    }
}
