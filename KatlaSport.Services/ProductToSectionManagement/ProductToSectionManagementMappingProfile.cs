using AutoMapper;
using KatlaSport.Services.ProductManagement;

namespace KatlaSport.Services.ProductToSectionManagement
{
    public sealed class ProductToSectionManagementMappingProfile : Profile
    {
        public ProductToSectionManagementMappingProfile()
        {
            CreateMap<DataAccess.ProductStore.StoreItem, HiveSectionProductListItem>()
                .ForMember(li => li.Id, opt => opt.MapFrom(p => p.ProductId));
        }
    }
}
