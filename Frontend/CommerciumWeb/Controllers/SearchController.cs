using CommerciumWeb.Interfaces;
using CommerciumWeb.Models;
using CommerciumWeb.Models.SearchModels;
using CommerciumWeb.Models.SearchModels.Commercium.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommerciumWeb.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;
        private readonly IToastNotification _toastNotification;

        public SearchController(ISearchService searchService, IToastNotification toastNotification)
        {
            _searchService = searchService;
            _toastNotification = toastNotification;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                _toastNotification.AddErrorToastMessage("Arama sorgusu boş olamaz.");
                return View(new List<SearchResultModel>());
            }

            try
            {
                var response = await _searchService.SearchAsync(query);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Arama sonuçları getirilemedi.");
                return View(new List<SearchResultModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<SearchResultModel>());
            }
        }

        [HttpPost("search/save-history")]
        public async Task<IActionResult> SaveSearchHistory(string userId, string query)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(query))
            {
                _toastNotification.AddErrorToastMessage("Geçersiz arama bilgileri.");
                return BadRequest("Eksik veya hatalı giriş.");
            }

            try
            {
                var response = await _searchService.SaveSearchHistoryAsync(userId, query);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Arama geçmişi başarıyla kaydedildi.");
                    return Ok(response);
                }

                _toastNotification.AddErrorToastMessage("Arama geçmişi kaydedilemedi.");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpGet("search/user/{userId}/history")]
        public async Task<IActionResult> GetUserSearchHistory(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                _toastNotification.AddErrorToastMessage("Geçersiz kullanıcı kimliği.");
                return BadRequest("Kullanıcı kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _searchService.GetUserSearchHistoryAsync(userId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Kullanıcının arama geçmişi getirilemedi.");
                return View(new List<SearchHistoryModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<SearchHistoryModel>());
            }
        }

        [HttpGet("search/search-by-tag/{tagId}")]
        public async Task<IActionResult> SearchByTag(int tagId)
        {
            if (tagId == 0)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz etiket kimliği.");
                return BadRequest("Etiket kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _searchService.SearchByTagAsync(tagId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Etikete göre arama sonuçları getirilemedi.");
                return View(new List<SearchResultModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<SearchResultModel>());
            }
        }
    }
}
