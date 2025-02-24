using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.ReviewRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Interfaces
{
    public interface IReviewService
    {
        // Yorum Yönetimi
        Task<ReturnRM<string>> CreateReviewAsync(CreateReviewRM createReviewRM);
        Task<ReturnRM<string>> UpdateReviewAsync(UpdateReviewRM updateReviewRM);
        Task<ReturnRM<string>> DeleteReviewAsync(int reviewId);

        // Yorumları Getirme
        Task<ReturnRM<IEnumerable<ReviewRM>>> GetReviewsByProductAsync(int productId);
        Task<ReturnRM<IEnumerable<ReviewRM>>> GetReviewsByServiceAsync(int serviceId);
        Task<ReturnRM<IEnumerable<ReviewRM>>> GetUserReviewsAsync(string userId);
        Task<ReturnRM<ReviewRM>> GetReviewByIdAsync(int reviewId);

        // Ortalama Puan Yönetimi
        Task<ReturnRM<decimal>> GetAverageRatingForProductAsync(int productId);
        Task<ReturnRM<decimal>> GetAverageRatingForServiceAsync(int serviceId);
    }

}
