using Commercium.Shared.Businness.ServiceRMs;
using Commercium.Shared.ProductRMs;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.FavoriteRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Interfaces
{
    public interface IFavoriteService
    {
        // Favori Ekleme & Kaldırma
        Task<ReturnRM<string>> AddFavoriteProductAsync(CreateFavoriteRM createFavoriteRM);
        Task<ReturnRM<string>> RemoveFavoriteProductAsync(UpdateFavoriteRM updateFavoriteRM);
        Task<ReturnRM<string>> AddFavoriteServiceAsync(CreateFavoriteRM createFavoriteRM);
        Task<ReturnRM<string>> RemoveFavoriteServiceAsync(UpdateFavoriteRM updateFavoriteRM);

        // Kullanıcının Favorilerini Getirme
        Task<ReturnRM<IEnumerable<ProductRM>>> GetUserFavoriteProductsAsync(string userId);
        Task<ReturnRM<IEnumerable<ServiceRM>>> GetUserFavoriteServicesAsync(string userId);
        Task<ReturnRM<IEnumerable<FavoriteRM>>> GetUserFavoritesAsync(string userId);

        // Favori Sayısını Getirme
        Task<ReturnRM<int>> GetFavoriteCountForProductAsync(int productId);
        Task<ReturnRM<int>> GetFavoriteCountForServiceAsync(int serviceId);
    }

}
