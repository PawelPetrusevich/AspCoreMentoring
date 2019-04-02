using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspCoreMentoring.DAL.Common.Interfaces;
using AspCoreMentoring.DAL.Common.Models;
using AspCoreMentoring.Service.Common.DTO;
using AspCoreMentoring.Service.Common.Interfaces;
using AutoMapper;

namespace AspCoreMentoring.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }


        public async Task<ProductViewDto[]> GetProducts(int pageNumber = 1, int pageSize = 0)
        {
            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException();
            }


            if (pageSize == 0)
            {
                var allItem = await productRepository.GetAll().ConfigureAwait(false);

                return mapper.Map<ProductViewDto[]>(allItem);
            }

            var skip = (pageNumber - 1) * pageSize;

            var itemsPerPage = await productRepository.GetForOnePage(skip, pageSize);

            return mapper.Map<ProductViewDto[]>(itemsPerPage);
        }

        public async Task<ProductViewDto> CreateProduct(ProductViewDto productDto)
        {
            if (productDto == null)
            {
                throw new ArgumentNullException();
            }

            if (!await IsProductContainsInDb(productDto))
            {
                throw new Exception("This product is created");
            }

            var product = mapper.Map<Product>(productDto);

            var result = await productRepository.Add(product);

            return mapper.Map<ProductViewDto>(result);
        }

        private async Task<bool> IsProductContainsInDb(ProductViewDto productDto)
        {
            var productFromDb = await productRepository.Find(x => (x.ProductName == productDto.ProductName && x.Supplier.SupplierId == productDto.Supplier.Id));

            return productFromDb != null;
        }
    }
}