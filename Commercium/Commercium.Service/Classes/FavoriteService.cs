using AutoMapper;
using Commercium.Data.Interfaces;
using Commercium.Entity.User;
using Commercium.Entity;
using Commercium.Service.Interfaces;
using Commercium.Shared.Businness.ServiceRMs;
using Commercium.Shared.ProductRMs;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.FavoriteRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Commercium.Service.Classes
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IGenericManager<Favorite> _favoriteManager;
        private readonly IGenericManager<Product> _productManager;
        private readonly IGenericManager<Entity.Businness.Service> _serviceManager;
        private readonly ITransactionManager _transactionManager;
        private readonly IMapper _mapper;

        public FavoriteService(
            IGenericManager<Favorite> favoriteManager,
            IGenericManager<Product> productManager,
            IGenericManager<Entity.Businness.Service> serviceManager,
            ITransactionManager transactionManager,
            IMapper mapper)
        {
            _favoriteManager = favoriteManager;
            _productManager = productManager;
            _serviceManager = serviceManager;
            _transactionManager = transactionManager;
            _mapper = mapper;
        }

        //  Favori ürün ekleme
        public async Task<ReturnRM<string>> AddFavoriteProductAsync(CreateFavoriteRM createFavoriteRM)
        {
            var favorite = _mapper.Map<Favorite>(createFavoriteRM);

            await _favoriteManager.AddAsync(favorite);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Favori ürün eklenemedi.", 500);
            }

            return ReturnRM<string>.Success("Favori ürün başarıyla eklendi.", 201);
        }

        //  Favori ürün kaldırma
        public async Task<ReturnRM<string>> RemoveFavoriteProductAsync(UpdateFavoriteRM updateFavoriteRM)
        {
            var favorite = await _favoriteManager.GetAsync(
                x => x.ProductId == updateFavoriteRM.ProductId && x.UserId == updateFavoriteRM.UserId);

            if (favorite == null)
            {
                return ReturnRM<string>.Fail("Favori ürün bulunamadı.", 404);
            }

            _favoriteManager.Delete(favorite);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Favori ürün kaldırılamadı.", 500);
            }

            return ReturnRM<string>.Success("Favori ürün başarıyla kaldırıldı.", 200);
        }

        //  Favori hizmet ekleme
        public async Task<ReturnRM<string>> AddFavoriteServiceAsync(CreateFavoriteRM createFavoriteRM)
        {
            var favorite = _mapper.Map<Favorite>(createFavoriteRM);

            await _favoriteManager.AddAsync(favorite);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Favori hizmet eklenemedi.", 500);
            }

            return ReturnRM<string>.Success("Favori hizmet başarıyla eklendi.", 201);
        }

        //  Favori hizmet kaldırma
        public async Task<ReturnRM<string>> RemoveFavoriteServiceAsync(UpdateFavoriteRM updateFavoriteRM)
        {
            var favorite = await _favoriteManager.GetAsync(
                x => x.ServiceId == updateFavoriteRM.ServiceId && x.UserId == updateFavoriteRM.UserId);

            if (favorite == null)
            {
                return ReturnRM<string>.Fail("Favori hizmet bulunamadı.", 404);
            }

            _favoriteManager.Delete(favorite);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Favori hizmet kaldırılamadı.", 500);
            }

            return ReturnRM<string>.Success("Favori hizmet başarıyla kaldırıldı.", 200);
        }

        //  Kullanıcının favori ürünlerini getirme
        public async Task<ReturnRM<IEnumerable<ProductRM>>> GetUserFavoriteProductsAsync(string userId)
        {
            var favorites = await _favoriteManager.GetAllAsync(
                x => x.UserId == userId && x.ProductId != null,
                includes: x => x.Include(f => f.Product));

            if (favorites == null || !favorites.Any())
            {
                return ReturnRM<IEnumerable<ProductRM>>.Fail("Kullanıcının favori ürünleri bulunamadı.", 404);
            }

            var productRMs = _mapper.Map<IEnumerable<ProductRM>>(favorites.Select(f => f.Product));
            return ReturnRM<IEnumerable<ProductRM>>.Success(productRMs, 200);
        }

        //  Kullanıcının favori hizmetlerini getirme
        public async Task<ReturnRM<IEnumerable<ServiceRM>>> GetUserFavoriteServicesAsync(string userId)
        {
            var favorites = await _favoriteManager.GetAllAsync(
                x => x.UserId == userId && x.ServiceId != null,
                includes: x => x.Include(f => f.Service));

            if (favorites == null || !favorites.Any())
            {
                return ReturnRM<IEnumerable<ServiceRM>>.Fail("Kullanıcının favori hizmetleri bulunamadı.", 404);
            }

            var serviceRMs = _mapper.Map<IEnumerable<ServiceRM>>(favorites.Select(f => f.Service));
            return ReturnRM<IEnumerable<ServiceRM>>.Success(serviceRMs, 200);
        }

        //  Kullanıcının tüm favorilerini getirme
        public async Task<ReturnRM<IEnumerable<FavoriteRM>>> GetUserFavoritesAsync(string userId)
        {
            var favorites = await _favoriteManager.GetAllAsync(
                x => x.UserId == userId,
                includes: x => x.Include(f => f.Product).Include(f => f.Service));

            if (favorites == null || !favorites.Any())
            {
                return ReturnRM<IEnumerable<FavoriteRM>>.Fail("Kullanıcının favorileri bulunamadı.", 404);
            }

            var favoriteRMs = _mapper.Map<IEnumerable<FavoriteRM>>(favorites);
            return ReturnRM<IEnumerable<FavoriteRM>>.Success(favoriteRMs, 200);
        }

        //  Ürünün favori sayısını getirme
        public async Task<ReturnRM<int>> GetFavoriteCountForProductAsync(int productId)
        {
            var favoriteCount = await _favoriteManager.CountAsync(x => x.ProductId == productId);
            return ReturnRM<int>.Success(favoriteCount, 200);
        }

        //  Hizmetin favori sayısını getirme
        public async Task<ReturnRM<int>> GetFavoriteCountForServiceAsync(int serviceId)
        {
            var favoriteCount = await _favoriteManager.CountAsync(x => x.ServiceId == serviceId);
            return ReturnRM<int>.Success(favoriteCount, 200);
        }
    }

}
