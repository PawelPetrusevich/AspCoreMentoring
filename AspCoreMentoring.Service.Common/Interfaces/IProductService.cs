using System.Collections.Generic;
using System.Threading.Tasks;
using AspCoreMentoring.Service.Common.DTO;

namespace AspCoreMentoring.Service.Common.Interfaces
{
    public interface IProductService
    {
        Task<ProductViewDto[]> GetProducts(int pageNumber, int pageSize);

        Task<ProductViewDto> CreateProduct(ProductViewDto product);

        Task<ProductViewDto> GetProductById(int id);
    }
}