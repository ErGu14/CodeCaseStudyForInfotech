using CommerciumWeb.Interfaces;
using CommerciumWeb.Models;
using CommerciumWeb.Models.ProductModels;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommerciumWeb.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IToastNotification _toastNotification;

        public ReviewController(IReviewService reviewService, IToastNotification toastNotification)
        {
            _reviewService = reviewService;
            _toastNotification = toastNotification;
        }

        [HttpPost("review/create")]
        public async Task<IActionResult> CreateReview([FromBody] ReviewModel createReviewModel)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz yorum bilgileri.");
                return BadRequest("Eksik veya hatalı giriş.");
            }

            try
            {
                var response = await _reviewService.CreateReviewAsync(createReviewModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Yorum başarıyla oluşturuldu.");
                    return Ok(response);
                }

                _toastNotification.AddErrorToastMessage("Yorum oluşturulamadı.");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpPut("review/update")]
        public async Task<IActionResult> UpdateReview([FromBody] ReviewModel updateReviewModel)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz yorum bilgileri.");
                return BadRequest("Eksik veya hatalı giriş.");
            }

            try
            {
                var response = await _reviewService.UpdateReviewAsync(updateReviewModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Yorum başarıyla güncellendi.");
                    return Ok(response);
                }

                _toastNotification.AddErrorToastMessage("Yorum güncellenemedi.");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpDelete("review/delete/{reviewId}")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            try
            {
                var response = await _reviewService.DeleteReviewAsync(reviewId);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Yorum başarıyla silindi.");
                    return Ok(response);
                }

                _toastNotification.AddErrorToastMessage("Yorum silinemedi.");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpGet("review/product/{productId}")]
        public async Task<IActionResult> GetReviewsByProduct(int productId)
        {
            try
            {
                var response = await _reviewService.GetReviewsByProductAsync(productId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Ürüne ait yorumlar getirilemedi.");
                return View(new List<ReviewModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<ReviewModel>());
            }
        }

        [HttpGet("review/service/{serviceId}")]
        public async Task<IActionResult> GetReviewsByService(int serviceId)
        {
            try
            {
                var response = await _reviewService.GetReviewsByServiceAsync(serviceId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Hizmete ait yorumlar getirilemedi.");
                return View(new List<ReviewModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<ReviewModel>());
            }
        }

        [HttpGet("review/user/{userId}")]
        public async Task<IActionResult> GetUserReviews(string userId)
        {
            try
            {
                var response = await _reviewService.GetUserReviewsAsync(userId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Kullanıcının yorumları getirilemedi.");
                return View(new List<ReviewModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<ReviewModel>());
            }
        }

        [HttpGet("review/{reviewId}")]
        public async Task<IActionResult> GetReviewById(int reviewId)
        {
            try
            {
                var response = await _reviewService.GetReviewByIdAsync(reviewId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Yorum getirilemedi.");
                return View(new ReviewModel());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new ReviewModel());
            }
        }

        [HttpGet("review/product/{productId}/average-rating")]
        public async Task<IActionResult> GetAverageRatingForProduct(int productId)
        {
            try
            {
                var response = await _reviewService.GetAverageRatingForProductAsync(productId);
                if (response.Errors == null)
                {
                    return Ok(response);
                }

                _toastNotification.AddErrorToastMessage("Ürün için ortalama puan getirilemedi.");
                return NotFound();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpGet("review/service/{serviceId}/average-rating")]
        public async Task<IActionResult> GetAverageRatingForService(int serviceId)
        {
            try
            {
                var response = await _reviewService.GetAverageRatingForServiceAsync(serviceId);
                if (response.Errors == null)
                {
                    return Ok(response);
                }

                _toastNotification.AddErrorToastMessage("Hizmet için ortalama puan getirilemedi.");
                return NotFound();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }
    }
}
