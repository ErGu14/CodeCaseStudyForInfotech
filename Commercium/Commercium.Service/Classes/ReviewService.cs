using AutoMapper;
using Commercium.Data.Interfaces;
using Commercium.Entity.User;
using Commercium.Entity;
using Commercium.Service.Interfaces;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.ReviewRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Commercium.Service.Classes
{
    public class ReviewService : IReviewService
    {
        private readonly IGenericManager<Review> _reviewManager;
        private readonly IGenericManager<Product> _productManager;
        private readonly IGenericManager<Entity.Businness.Service> _serviceManager;
        private readonly ITransactionManager _transactionManager;
        private readonly IMapper _mapper;

        public ReviewService(
            IGenericManager<Review> reviewManager,
            IGenericManager<Product> productManager,
            IGenericManager<Entity.Businness.Service> serviceManager,
            ITransactionManager transactionManager,
            IMapper mapper)
        {
            _reviewManager = reviewManager;
            _productManager = productManager;
            _serviceManager = serviceManager;
            _transactionManager = transactionManager;
            _mapper = mapper;
        }

        //  Yorum oluşturma
        public async Task<ReturnRM<string>> CreateReviewAsync(CreateReviewRM createReviewRM)
        {
            var review = _mapper.Map<Review>(createReviewRM);

            // Yorum ekleme
            await _reviewManager.AddAsync(review);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Yorum oluşturulamadı.", 500);
            }

            return ReturnRM<string>.Success("Yorum başarıyla oluşturuldu.", 201);
        }

        //  Yorum güncelleme
        public async Task<ReturnRM<string>> UpdateReviewAsync(UpdateReviewRM updateReviewRM)
        {
            var review = await _reviewManager.GetByIdAsync(updateReviewRM.ReviewId);

            if (review == null)
            {
                return ReturnRM<string>.Fail("Yorum bulunamadı.", 404);
            }

            _mapper.Map(updateReviewRM, review);
            _reviewManager.Update(review);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Yorum güncellenemedi.", 500);
            }

            return ReturnRM<string>.Success("Yorum başarıyla güncellendi.", 200);
        }

        //  Yorum silme
        public async Task<ReturnRM<string>> DeleteReviewAsync(int reviewId)
        {
            var review = await _reviewManager.GetByIdAsync(reviewId);

            if (review == null)
            {
                return ReturnRM<string>.Fail("Yorum bulunamadı.", 404);
            }

            _reviewManager.Delete(review);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Yorum silinemedi.", 500);
            }

            return ReturnRM<string>.Success("Yorum başarıyla silindi.", 200);
        }

        //  Ürüne ait yorumları getirme
        public async Task<ReturnRM<IEnumerable<ReviewRM>>> GetReviewsByProductAsync(int productId)
        {
            var reviews = await _reviewManager.GetAllAsync(
                x => x.ProductId == productId,
                includes: x => x.Include(r => r.User));

            if (reviews == null || !reviews.Any())
            {
                return ReturnRM<IEnumerable<ReviewRM>>.Fail("Ürüne ait yorum bulunamadı.", 404);
            }

            var reviewRMs = _mapper.Map<IEnumerable<ReviewRM>>(reviews);
            return ReturnRM<IEnumerable<ReviewRM>>.Success(reviewRMs, 200);
        }

        //  Hizmete ait yorumları getirme
        public async Task<ReturnRM<IEnumerable<ReviewRM>>> GetReviewsByServiceAsync(int serviceId)
        {
            var reviews = await _reviewManager.GetAllAsync(
                x => x.ServiceId == serviceId,
                includes: x => x.Include(r => r.User));

            if (reviews == null || !reviews.Any())
            {
                return ReturnRM<IEnumerable<ReviewRM>>.Fail("Hizmete ait yorum bulunamadı.", 404);
            }

            var reviewRMs = _mapper.Map<IEnumerable<ReviewRM>>(reviews);
            return ReturnRM<IEnumerable<ReviewRM>>.Success(reviewRMs, 200);
        }

        //  Kullanıcının yaptığı yorumları getirme
        public async Task<ReturnRM<IEnumerable<ReviewRM>>> GetUserReviewsAsync(string userId)
        {
            var reviews = await _reviewManager.GetAllAsync(
                x => x.UserId == userId,
                includes: x => x.Include(r => r.Product).Include(r => r.Service));

            if (reviews == null || !reviews.Any())
            {
                return ReturnRM<IEnumerable<ReviewRM>>.Fail("Kullanıcıya ait yorum bulunamadı.", 404);
            }

            var reviewRMs = _mapper.Map<IEnumerable<ReviewRM>>(reviews);
            return ReturnRM<IEnumerable<ReviewRM>>.Success(reviewRMs, 200);
        }

        //  Yorum ID'sine göre yorum getirme
        public async Task<ReturnRM<ReviewRM>> GetReviewByIdAsync(int reviewId)
        {
            var review = await _reviewManager.GetByIdAsync(reviewId);

            if (review == null)
            {
                return ReturnRM<ReviewRM>.Fail("Yorum bulunamadı.", 404);
            }

            var reviewRM = _mapper.Map<ReviewRM>(review);
            return ReturnRM<ReviewRM>.Success(reviewRM, 200);
        }

        //  Ürün için ortalama puan hesaplama
        public async Task<ReturnRM<decimal>> GetAverageRatingForProductAsync(int productId)
        {
            var reviews = await _reviewManager.GetAllAsync(
                x => x.ProductId == productId);

            if (reviews == null || !reviews.Any())
            {
                return ReturnRM<decimal>.Fail("Ürün için yorum bulunamadı.", 404);
            }

            var averageRating = reviews.Average(r => r.Rating);
            return ReturnRM<decimal>.Success(averageRating, 200);
        }

        //  Hizmet için ortalama puan hesaplama
        public async Task<ReturnRM<decimal>> GetAverageRatingForServiceAsync(int serviceId)
        {
            var reviews = await _reviewManager.GetAllAsync(
                x => x.ServiceId == serviceId);

            if (reviews == null || !reviews.Any())
            {
                return ReturnRM<decimal>.Fail("Hizmet için yorum bulunamadı.", 404);
            }

            var averageRating = reviews.Average(r => r.Rating);
            return ReturnRM<decimal>.Success(averageRating, 200);
        }
    }

}
