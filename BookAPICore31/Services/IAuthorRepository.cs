using BookAPICore31.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPICore31.Services
{
    public interface IAuthorRepository
    {
        Task<ICollection<Author>> GetAuthors();

        Task<Author> GetAuthor(int authorId);

        Task<ICollection<Author>> GetAuthorsOfABook(int bookId);

        Task<ICollection<Book>> GetBooksByAuthor(int authorId);

        Task<bool> AuthorExists(int authorId);
    }
}
