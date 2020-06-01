using BookAPICore31.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPICore31.Services
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategory(int categoryId);
        Task<List<Category>> GetAllCategoriesForABook(int bookId);
        Task<List<Book>> GetAllBooksForACategory(int categoryId);
        Task<Boolean> CategoryExists(int categoryId);
    }
}
