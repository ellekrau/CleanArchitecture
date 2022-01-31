using CleanArchitecture.Application.Products.Commands;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private const string ProductNotFoundMessage = "Product could not be found.";

        private readonly IProductRepository _productRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetByIdAsync(request.Id).Result;

            if (product is null)
                throw new ApplicationException(ProductNotFoundMessage);

            product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);

            return await _productRepository.UpdateAsync(product);
        }
    }
}
