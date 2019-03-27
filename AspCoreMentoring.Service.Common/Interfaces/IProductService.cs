using System.Collections.Generic;
using System.Threading.Tasks;
using AspCoreMentoring.Service.Common.DTO;

namespace AspCoreMentoring.Service.Common.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto[]> GetProducts(int pageNumber, int pageSize);

        Task<ProductDto> CreateProduct(ProductDto product);
    }
}