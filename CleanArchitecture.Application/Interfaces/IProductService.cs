using CleanArchitecture.Application.DTOs;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAll();
        Task<ProductDTO> GetById(int? id);
        Task Create(ProductDTO productDTO);
        Task Update(ProductDTO productDTO);
        Task Delete(int? id);
    }
}
