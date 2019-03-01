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

        public ProductToSectionRequestService(IProductToSectionRequestContext requestContext, IProductStoreHiveContext hiveSectionContext)
        {
            _requestContext = requestContext ?? throw new ArgumentNullException(nameof(requestContext));
            _hiveSectionContext = hiveSectionContext ?? throw new ArgumentNullException(nameof(hiveSectionContext));
        }

        public async Task<List<ProductToSectionRequest>> GetSectionRequests(int sectionId)
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
    }
}
