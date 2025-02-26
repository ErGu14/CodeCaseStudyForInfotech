using Commercium.Service.Interfaces;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.FavoriteRMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commercium.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
 
    public class FavoriteController : CustomizingController
    {
        private readonly IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        // Favori Ürün Ekleme - User ve SalesRepresentative erişebilir
        [Authorize(Roles = "User, SalesRepresentative")]
        [HttpPost("add-product")]
        public async Task<IActionResult> AddFavoriteProduct([FromBody] CreateFavoriteRM createFavoriteRM)
        {
            var response = await _favoriteService.AddFavoriteProductAsync(createFavoriteRM);
            return CreateReturn(response);
        }

        // Favori Ürün Kaldırma - User ve SalesRepresentative erişebilir
        [Authorize(Roles = "User, SalesRepresentative")]
        [HttpPost("remove-product")]
        public async Task<IActionResult> RemoveFavoriteProduct([FromBody] UpdateFavoriteRM updateFavoriteRM)
        {
            var response = await _favoriteService.RemoveFavoriteProductAsync(updateFavoriteRM);
            return CreateReturn(response);
        }

        // Favori Hizmet Ekleme - User ve SalesRepresentative erişebilir
        [Authorize(Roles = "User, SalesRepresentative")]
        [HttpPost("add-service")]
        public async Task<IActionResult> AddFavoriteService([FromBody] CreateFavoriteRM createFavoriteRM)
        {
            var response = await _favoriteService.AddFavoriteServiceAsync(createFavoriteRM);
            return CreateReturn(response);
        }

        // Favori Hizmet Kaldırma - User ve SalesRepresentative erişebilir
        [Authorize(Roles = "User, SalesRepresentative")]
        [HttpPost("remove-service")]
        public async Task<IActionResult> RemoveFavoriteService([FromBody] UpdateFavoriteRM updateFavoriteRM)
        {
            var response = await _favoriteService.RemoveFavoriteServiceAsync(updateFavoriteRM);
            return CreateReturn(response);
        }

        // Kullanıcının Favori Ürünlerini Getirme - User ve Admin erişebilir
        [Authorize(Roles = "User, Admin")]
        [HttpGet("user/{userId}/products")]
        public async Task<IActionResult> GetUserFavoriteProducts(string userId)
        {
            var response = await _favoriteService.GetUserFavoriteProductsAsync(userId);
            return CreateReturn(response);
        }

        // Kullanıcının Favori Hizmetlerini Getirme - User ve Admin erişebilir
        [Authorize(Roles = "User, Admin")]
        [HttpGet("user/{userId}/services")]
        public async Task<IActionResult> GetUserFavoriteServices(string userId)
        {
            var response = await _favoriteService.GetUserFavoriteServicesAsync(userId);
            return CreateReturn(response);
        }

        // Kullanıcının Tüm Favorilerini Getirme - User ve Admin erişebilir
        [Authorize(Roles = "User, Admin")]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserFavorites(string userId)
        {
            var response = await _favoriteService.GetUserFavoritesAsync(userId);
            return CreateReturn(response);
        }

        // Ürünün Favori Sayısını Getirme - Admin ve User erişebilir
        [Authorize(Roles = "User, Admin")]
        [HttpGet("product/{productId}/count")]
        public async Task<IActionResult> GetFavoriteCountForProduct(int productId)
        {
            var response = await _favoriteService.GetFavoriteCountForProductAsync(productId);
            return CreateReturn(response);
        }

        // Hizmetin Favori Sayısını Getirme - Admin ve User erişebilir
        [Authorize(Roles = "User, Admin")]
        [HttpGet("service/{serviceId}/count")]
        public async Task<IActionResult> GetFavoriteCountForService(int serviceId)
        {
            var response = await _favoriteService.GetFavoriteCountForServiceAsync(serviceId);
            return CreateReturn(response);
        }
    }

}
