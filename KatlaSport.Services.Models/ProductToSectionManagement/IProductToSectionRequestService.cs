using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.ProductManagement
{
    public interface IProductToSectionRequestService
    {
        Task<List<ProductToSectionRequest>> GetSectionRequestsAsync(int sectionId);

        Task<List<ProductToSectionRequest>> GetRequestsAsync();

        Task<ProductToSectionRequest> CreateRequestAsync(UpdateProductToSectionRequestRequest createRequest);

        Task ConfirmRequestAsync(int requestId);

        Task RejectRequestAsync(int requestId);
    }
}
