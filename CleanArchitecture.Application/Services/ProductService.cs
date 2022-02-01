using AutoMapper;
using CleanArchitecture.Application.CustomExceptions;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Products.Commands;
using CleanArchitecture.Application.Products.Queries;
using MediatR;

namespace CleanArchitecture.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Create(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Delete(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.GetValueOrDefault());
            ApplicationHandleException.When(productRemoveCommand is null);

            await _mediator.Send(productRemoveCommand);
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var getProductsQuery = new GetProductsQuery();
            ApplicationHandleException.When(getProductsQuery is null);

            var result = await _mediator.Send(getProductsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var getProductByIdQuery = new GetProductByIdQuery(id.GetValueOrDefault());
            ApplicationHandleException.When(getProductByIdQuery is null);

            var result = await _mediator.Send(getProductByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }
    }
}
