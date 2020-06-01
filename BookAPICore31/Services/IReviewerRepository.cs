using BookAPICore31.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPICore31.Services
{
    public interface IReviewerRepository
    {
        Task<ICollection<Reviewer>> GetReviewers();

        Task<Reviewer> GetReviewer(int reviewerId);

        Task<ICollection<Review>> GetReviewsOfAReviewer(int reviewerId);

        Task<Reviewer> GetReviewerOfAReview(int reviewId);

        Task<bool> ReviewerExists(int reviewerId);
    }
}
