using BookAPICore31.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPICore31.Services
{
    public interface IReviewRepository
    {
        Task<ICollection<Review>> GetReviews();

        Task<Review> GetReview(int reviewId);

        Task<ICollection<Review>> GetReviewsOfABook(int bookId);

        Task<Book> GetBookOfAReview(int reviewId);

        Task<bool> ReviewExists(int reviewyId);
    }
}
