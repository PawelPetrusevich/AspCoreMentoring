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


        public async Task<ProductDto[]> GetProducts(int pageNumber = 1, int pageSize = 0)
        {
            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException();
            }


            if (pageSize == 0)
            {
                var allItem = await productRepository.GetAll().ConfigureAwait(false);

                return mapper.Map<ProductDto[]>(allItem);
            }

            var skip = (pageNumber - 1) * pageSize;

            var itemPerPage = await productRepository.GetForOnePage(skip, pageSize);

            return mapper.Map<ProductDto[]>(itemPerPage);
        }

        public async Task<ProductDto> CreateProduct(ProductDto productDto)
        {
            if (productDto == null)
            {
                throw new ArgumentNullException();
            }

            var product = mapper.Map<Product>(productDto);

            var result = await productRepository.Add(product);

            return mapper.Map<ProductDto>(result);
        }
    }
}