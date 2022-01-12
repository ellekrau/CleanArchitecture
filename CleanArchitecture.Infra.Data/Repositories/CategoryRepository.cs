using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> RemoveAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
