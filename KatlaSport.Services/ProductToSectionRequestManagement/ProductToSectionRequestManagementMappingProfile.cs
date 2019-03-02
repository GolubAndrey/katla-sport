using AutoMapper;
using KatlaSport.Services.ProductManagement;

namespace KatlaSport.Services.ProductToSectionRequestManagement
{
    public sealed class ProductToSectionRequestManagementMappingProfile : Profile
    {
        public ProductToSectionRequestManagementMappingProfile()
        {
            CreateMap<DataAccess.ProductStore.ProductToSectionRequestItem, ProductToSectionRequest>();
            CreateMap<UpdateProductToSectionRequestRequest, DataAccess.ProductStore.ProductToSectionRequestItem>();
        }
    }
}
