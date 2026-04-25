using Microsoft.EntityFrameworkCore;
using NorthwindCatalog.Services.Data;
using NorthwindCatalog.Services.DTO;
using NorthwindCatalog.Services.Models;

namespace NorthwindCatalog.Services.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyAppDbContext _context;

        public CategoryRepository(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
