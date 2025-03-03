using CommerciumWeb.Interfaces;
using CommerciumWeb.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommerciumWeb.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoriteService _favoriteService;
        private readonly IToastNotification _toastNotification;

        public FavoriteController(IFavoriteService favoriteService, IToastNotification toastNotification)
        {
            _favoriteService = favoriteService;
            _toastNotification = toastNotification;
        }

        [HttpPost("favorite/add-product")]
        public async Task<IActionResult> AddFavoriteProduct([FromBody] FavoriteModel favoriteModel)
        {
            if (!ModelState.IsValid || favoriteModel.ProductId == null || string.IsNullOrEmpty(favoriteModel.UserId))
            {
                _toastNotification.AddErrorToastMessage("Favori ekleme için geçerli bir ürün ve kullanıcı kimliği gereklidir.");
                return BadRequest("Eksik veya geçersiz favori bilgileri.");
            }

            try
            {
                var response = await _favoriteService.AddFavoriteProductAsync(favoriteModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Ürün favorilere eklendi.");
                    return Ok(response);
                }
                _toastNotification.AddErrorToastMessage(string.Join(" ", response.Errors));
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpPost("favorite/remove-product")]
        public async Task<IActionResult> RemoveFavoriteProduct([FromBody] FavoriteModel favoriteModel)
        {
            if (!ModelState.IsValid || favoriteModel.ProductId == null || string.IsNullOrEmpty(favoriteModel.UserId))
            {
                _toastNotification.AddErrorToastMessage("Favori kaldırma için geçerli bir ürün ve kullanıcı kimliği gereklidir.");
                return BadRequest("Eksik veya geçersiz favori bilgileri.");
            }

            try
            {
                var response = await _favoriteService.RemoveFavoriteProductAsync(favoriteModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Ürün favorilerden kaldırıldı.");
                    return Ok(response);
                }
                _toastNotification.AddErrorToastMessage(string.Join(" ", response.Errors));
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpPost("favorite/add-service")]
        public async Task<IActionResult> AddFavoriteService([FromBody] FavoriteModel favoriteModel)
        {
            if (!ModelState.IsValid || favoriteModel.ServiceId == null || string.IsNullOrEmpty(favoriteModel.UserId))
            {
                _toastNotification.AddErrorToastMessage("Favori ekleme için geçerli bir hizmet ve kullanıcı kimliği gereklidir.");
                return BadRequest("Eksik veya geçersiz favori bilgileri.");
            }

            try
            {
                var response = await _favoriteService.AddFavoriteServiceAsync(favoriteModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Hizmet favorilere eklendi.");
                    return Ok(response);
                }
                _toastNotification.AddErrorToastMessage(string.Join(" ", response.Errors));
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpPost("favorite/remove-service")]
        public async Task<IActionResult> RemoveFavoriteService([FromBody] FavoriteModel favoriteModel)
        {
            if (!ModelState.IsValid || favoriteModel.ServiceId == null || string.IsNullOrEmpty(favoriteModel.UserId))
            {
                _toastNotification.AddErrorToastMessage("Favori kaldırma için geçerli bir hizmet ve kullanıcı kimliği gereklidir.");
                return BadRequest("Eksik veya geçersiz favori bilgileri.");
            }

            try
            {
                var response = await _favoriteService.RemoveFavoriteServiceAsync(favoriteModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Hizmet favorilerden kaldırıldı.");
                    return Ok(response);
                }
                _toastNotification.AddErrorToastMessage(string.Join(" ", response.Errors));
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpGet("favorite/user/{userId}/products")]
        public async Task<IActionResult> GetUserFavoriteProducts(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                _toastNotification.AddErrorToastMessage("Geçersiz kullanıcı kimliği.");
                return BadRequest("Kullanıcı kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _favoriteService.GetUserFavoriteProductsAsync(userId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }
                _toastNotification.AddErrorToastMessage("Favori ürünler getirilemedi.");
                return View(new List<ProductModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<ProductModel>());
            }
        }

        [HttpGet("favorite/user/{userId}/services")]
        public async Task<IActionResult> GetUserFavoriteServices(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                _toastNotification.AddErrorToastMessage("Geçersiz kullanıcı kimliği.");
                return BadRequest("Kullanıcı kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _favoriteService.GetUserFavoriteServicesAsync(userId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }
                _toastNotification.AddErrorToastMessage("Favori hizmetler getirilemedi.");
                return View(new List<BusinessServiceModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<BusinessServiceModel>());
            }
        }
    }
}
