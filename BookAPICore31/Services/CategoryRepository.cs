using BookAPICore31.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPICore31.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookDbContext _dbContext;

        public CategoryRepository(BookDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await _dbContext.Categories.AnyAsync(c => c.Id == categoryId);
        }

        public async Task<List<Book>> GetAllBooksForACategory(int categoryId)
        {
            return await _dbContext.BookCategories.Where(bc => bc.CategoryId == categoryId)
                        .Select(bc => bc.Book).ToListAsync();
        }

        public async Task<List<Category>> GetAllCategoriesForABook(int bookId)
        {
            return await _dbContext.BookCategories.Where(bc => bc.BookId == bookId)
                                .Select(bc => bc.Category).ToListAsync();
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _dbContext.Categories.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Category> GetCategory(int categoryId)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
        }
    }
}
