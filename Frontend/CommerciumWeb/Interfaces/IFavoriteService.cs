using CommerciumWeb.Models;

namespace CommerciumWeb.Interfaces
{
    public interface IFavoriteService
    {
        Task<ReturnModel<string>> AddFavoriteProductAsync(FavoriteModel createFavoriteModel);
        Task<ReturnModel<string>> RemoveFavoriteProductAsync(FavoriteModel updateFavoriteModel);
        Task<ReturnModel<string>> AddFavoriteServiceAsync(FavoriteModel createFavoriteModel);
        Task<ReturnModel<string>> RemoveFavoriteServiceAsync(FavoriteModel updateFavoriteModel);
        Task<ReturnModel<IEnumerable<ProductModel>>> GetUserFavoriteProductsAsync(string userId);
        Task<ReturnModel<IEnumerable<BusinessServiceModel>>> GetUserFavoriteServicesAsync(string userId);
        Task<ReturnModel<IEnumerable<FavoriteModel>>> GetUserFavoritesAsync(string userId);
        Task<ReturnModel<int>> GetFavoriteCountForProductAsync(int productId);
        Task<ReturnModel<int>> GetFavoriteCountForServiceAsync(int serviceId);
    }

}
