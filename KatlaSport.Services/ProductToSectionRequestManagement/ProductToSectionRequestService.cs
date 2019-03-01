using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ProductStore;
using KatlaSport.DataAccess.ProductStoreHive;

namespace KatlaSport.Services.ProductManagement
{
    public class ProductToSectionRequestService : IProductToSectionRequestService
    {
        private readonly IProductToSectionRequestContext _requestContext;
        private readonly IProductStoreHiveContext _hiveSectionContext;
        private readonly IProductStoreContext _productContext;

        public ProductToSectionRequestService(IProductToSectionRequestContext requestContext, IProductStoreHiveContext hiveSectionContext, IProductStoreContext productContext)
        {
            _requestContext = requestContext ?? throw new ArgumentNullException(nameof(requestContext));
            _hiveSectionContext = hiveSectionContext ?? throw new ArgumentNullException(nameof(hiveSectionContext));
            _productContext = productContext ?? throw new ArgumentNullException(nameof(productContext));
        }

        public async Task<List<ProductToSectionRequest>> GetSectionRequestsAsync(int sectionId)
        {
            var dbSections = await _hiveSectionContext.Sections.Where(s => s.Id == sectionId).ToArrayAsync();

            if (dbSections.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbRequests = await _requestContext.Requests.Where(r => r.HiveSectionId == sectionId).ToArrayAsync();
            var requests = dbRequests.Select(r => Mapper.Map<ProductToSectionRequest>(r)).ToList();

            return requests;
        }

        public async Task<List<ProductToSectionRequest>> GetRequestsAsync()
        {
            var dbRequests = await _requestContext.Requests.Where(r => !r.Status).OrderBy(r => r.Id).ToArrayAsync();
            var requests = dbRequests.Select(r => Mapper.Map<ProductToSectionRequest>(r)).ToList();

            return requests;
        }

        public async Task<ProductToSectionRequest> CreateRequestAsync(UpdateProductToSectionRequestRequest createRequest)
        {
            var dbRequests = await _requestContext.Requests.Where(r => r.Id == createRequest.Id).ToArrayAsync();
            if (dbRequests.Length > 0)
            {
                throw new RequestedResourceHasConflictException("Id");
            }

            var dbRequest = Mapper.Map<UpdateProductToSectionRequestRequest, ProductToSectionRequestItem>(createRequest);
            _requestContext.Requests.Add(dbRequest);

            await _requestContext.SaveChangesAsync();

            return Mapper.Map<ProductToSectionRequest>(dbRequest);
        }

        public async Task ConfirmRequestAsync(int requestId)
        {
            var dbRequests = await _requestContext.Requests.Where(r => r.Id == requestId).ToArrayAsync();
            var dbRequest = dbRequests.FirstOrDefault();
            if (dbRequest == null)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbProducts = await _productContext.Items.Where(p => p.ProductId == dbRequest.ProductId && p.HiveSectionId == dbRequest.HiveSectionId).ToArrayAsync();
            if (dbProducts.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            dbProducts[0].Quantity += dbRequests[0].Quantity;
            dbRequests[0].Status = true;

            await _requestContext.SaveChangesAsync();
            await _productContext.SaveChangesAsync();
        }

        public async Task RejectRequestAsync(int requestId)
        {
            var dbRequests = await _requestContext.Requests.Where(r => r.Id == requestId).ToArrayAsync();
            if (dbRequests.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            dbRequests[0].Status = true;
            await _requestContext.SaveChangesAsync();
        }
    }
}
