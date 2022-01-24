using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task Create(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            await _productRepository.CreateAsync(product);
        }

        public async Task Delete(int? id)
        {
            var product = _productRepository.GetByIdAsync(id).Result;

            if (product is not null)
                await _productRepository.RemoveAsync(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var product = _productRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            await _productRepository.UpdateAsync(product);
        }
    }
}
