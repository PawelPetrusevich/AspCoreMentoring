using System.Collections.Generic;
using System.Threading.Tasks;
using AspCoreMentoring.Service.Common.DTO;
using AspCoreMentoring.Service.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreMentoring.Server.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<ProductDto[]> GetProducts(int pageNumber = 1,int? pageSize = null)
        {
            var product = await productService.GetProducts(pageNumber, pageSize);

            return product;
        }
    }
}