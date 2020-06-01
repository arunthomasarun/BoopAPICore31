using BookAPICore31.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPICore31.Services
{
    public interface IBookRepository
    {
        Task<ICollection<Book>> GetBooks();
        Task<Book> GetBook(int bookId);
        Task<Book> GetBook(string ISBN);
        Task<bool> IsDuplicateISBN(int bookId, string ISBN);
        Task<decimal> GetBookRatings(int bookId);
        Task<bool> BookExists(int bookId);
        Task<bool> BookExists(string ISBN);
    }
}
