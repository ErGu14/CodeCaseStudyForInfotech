using Commercium.Service.Interfaces;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.ReviewRMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commercium.API.Controllers
{
    [ApiController]
    [Route("api/review")]
    public class ReviewController : CustomizingController
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

   
        [Authorize(Roles = "User, BusinessOwner")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewRM createReviewRM)
        {
            var response = await _reviewService.CreateReviewAsync(createReviewRM);
            return CreateReturn(response);
        }

        
        [Authorize(Roles = "User, BusinessOwner")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateReview([FromBody] UpdateReviewRM updateReviewRM)
        {
            var response = await _reviewService.UpdateReviewAsync(updateReviewRM);
            return CreateReturn(response);
        }

       
        [Authorize(Roles = "User, BusinessOwner")]
        [HttpDelete("delete/{reviewId}")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var response = await _reviewService.DeleteReviewAsync(reviewId);
            return CreateReturn(response);
        }

       
        [Authorize(Roles = "Admin, BusinessOwner, User")]
        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetReviewsByProduct(int productId)
        {
            var response = await _reviewService.GetReviewsByProductAsync(productId);
            return CreateReturn(response);
        }

       
        [Authorize(Roles = "Admin, BusinessOwner, User")]
        [HttpGet("service/{serviceId}")]
        public async Task<IActionResult> GetReviewsByService(int serviceId)
        {
            var response = await _reviewService.GetReviewsByServiceAsync(serviceId);
            return CreateReturn(response);
        }

        
        [Authorize(Roles = "Admin, User")]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserReviews(string userId)
        {
            var response = await _reviewService.GetUserReviewsAsync(userId);
            return CreateReturn(response);
        }


        [Authorize(Roles = "Admin, User")]
        [HttpGet("{reviewId}")]
        public async Task<IActionResult> GetReviewById(int reviewId)
        {
            var response = await _reviewService.GetReviewByIdAsync(reviewId);
            return CreateReturn(response);
        }

        
        [Authorize(Roles = "Admin, BusinessOwner, User")]
        [HttpGet("product/{productId}/average-rating")]
        public async Task<IActionResult> GetAverageRatingForProduct(int productId)
        {
            var response = await _reviewService.GetAverageRatingForProductAsync(productId);
            return CreateReturn(response);
        }

       
        [Authorize(Roles = "Admin, BusinessOwner, User")]
        [HttpGet("service/{serviceId}/average-rating")]
        public async Task<IActionResult> GetAverageRatingForService(int serviceId)
        {
            var response = await _reviewService.GetAverageRatingForServiceAsync(serviceId);
            return CreateReturn(response);
        }
    }

}
