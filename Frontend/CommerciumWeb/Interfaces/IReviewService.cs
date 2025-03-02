using CommerciumWeb.Models;

namespace CommerciumWeb.Interfaces
{
    public interface IReviewService
    {
        Task<ReturnModel<string>> CreateReviewAsync(ReviewModel createReviewModel);
        Task<ReturnModel<string>> UpdateReviewAsync(ReviewModel updateReviewModel);
        Task<ReturnModel<string>> DeleteReviewAsync(int reviewId);
        Task<ReturnModel<IEnumerable<ReviewModel>>> GetReviewsByProductAsync(int productId);
        Task<ReturnModel<IEnumerable<ReviewModel>>> GetReviewsByServiceAsync(int serviceId);
        Task<ReturnModel<IEnumerable<ReviewModel>>> GetUserReviewsAsync(string userId);
        Task<ReturnModel<ReviewModel>> GetReviewByIdAsync(int reviewId);
        Task<ReturnModel<double>> GetAverageRatingForProductAsync(int productId);
        Task<ReturnModel<double>> GetAverageRatingForServiceAsync(int serviceId);
    }
}
