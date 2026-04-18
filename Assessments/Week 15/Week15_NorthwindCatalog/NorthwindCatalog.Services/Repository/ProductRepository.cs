using Microsoft.EntityFrameworkCore;
using NorthwindCatalog.Services.Data;
using NorthwindCatalog.Services.DTO;
using NorthwindCatalog.Services.Models;
using NorthwindCatalog.Services.Repository;

public class ProductRepository : IProductRepository
{
    private readonly MyAppDbContext _context;

    public ProductRepository(MyAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId)
    {
        return await _context.Products
            .Where(p => p.CategoryId == categoryId)
            .ToListAsync();
    }

    public async Task<IEnumerable<CategorySummaryDto>> GetCategorySummariesAsync()
    {
        return await _context.Categories
            .Select(c => new CategorySummaryDto
            {
                CategoryName = c.CategoryName,
                ProductCount = c.Products.Count(),

                AvgPrice = c.Products.Any()
                    ? c.Products.Average(p => p.UnitPrice ?? 0)
                    : 0,

                MostExpensiveProduct = c.Products
                    .OrderByDescending(p => p.UnitPrice)
                    .Select(p => p.ProductName)
                    .FirstOrDefault()
            })
            .ToListAsync();
    }
}