using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using KatlaSport.Services.ProductManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/sectionProducts")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class SectionProductsController : ApiController
    {
        private readonly IProductSectionService _productSectionService;

        public SectionProductsController(IProductSectionService productSectionService)
        {
            _productSectionService = productSectionService ?? throw new ArgumentNullException(nameof(productSectionService));
        }

        [HttpGet]
        [Route("{sectionId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a product from hive section.", Type = typeof(HiveSectionProduct[]))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetProduct([FromUri] int sectionId)
        {
            var product = await _productSectionService.GetSectionProductsAsync(sectionId);
            return Ok(product);
        }
    }
}