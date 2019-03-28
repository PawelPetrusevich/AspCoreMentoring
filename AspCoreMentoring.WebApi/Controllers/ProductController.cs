using System.Threading.Tasks;
using AspCoreMentoring.Service.Common.DTO;
using AspCoreMentoring.Service.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AspCoreMentoring.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IConfiguration configuration;

        public ProductController(IProductService productService, IConfiguration configuration)
        {
            this.productService = productService;
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<ProductViewDto[]> GetProducts(int pageNumber = 1,int pageSize = 0)
        {
            var product = await productService.GetProducts(pageNumber, pageSize);

            return product;
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<ProductViewDto> CreateProduct([FromBody]ProductViewDto productDto)
        {
            var result = await productService.CreateProduct(productDto);

            return result;
        }
    }
}