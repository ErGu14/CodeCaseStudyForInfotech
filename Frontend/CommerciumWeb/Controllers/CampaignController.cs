using CommerciumWeb.Interfaces;
using CommerciumWeb.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommerciumWeb.Controllers
{
    public class CampaignController : Controller
    {
        private readonly ICampaignService _campaignService;
        private readonly IToastNotification _toastNotification;

        public CampaignController(ICampaignService campaignService, IToastNotification toastNotification)
        {
            _campaignService = campaignService;
            _toastNotification = toastNotification;
        }

        [HttpGet("campaign/{campaignId}")]
        public async Task<IActionResult> GetCampaignById(int campaignId)
        {
            try
            {
                var response = await _campaignService.GetCampaignByIdAsync(campaignId);
                if (response.Errors == null && response.Data != null)
                {
                    return View(response.Data);
                }
                _toastNotification.AddErrorToastMessage("Kampanya bulunamadı.");
                return RedirectToAction("GetAllCampaigns");
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return RedirectToAction("GetAllCampaigns");
            }
        }

        [HttpGet("campaign/all")]
        public async Task<IActionResult> GetAllCampaigns()
        {
            try
            {
                var response = await _campaignService.GetAllCampaignsAsync();
                if (response.Errors == null)
                {
                    return View(response.Data);
                }
                _toastNotification.AddErrorToastMessage("Kampanyalar getirilemedi.");
                return View(new List<CampaignModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<CampaignModel>());
            }
        }

        [HttpPost("campaign/create")]
        public async Task<IActionResult> CreateCampaign([FromBody] CampaignModel createCampaignModel)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz kampanya bilgisi.");
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _campaignService.CreateCampaignAsync(createCampaignModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Kampanya başarıyla oluşturuldu.");
                    return RedirectToAction("GetAllCampaigns");
                }
                _toastNotification.AddErrorToastMessage("Kampanya oluşturulamadı.");
                return View();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpPut("campaign/update")]
        public async Task<IActionResult> UpdateCampaign([FromBody] CampaignModel updateCampaignModel)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz kampanya bilgisi.");
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _campaignService.UpdateCampaignAsync(updateCampaignModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Kampanya başarıyla güncellendi.");
                    return RedirectToAction("GetCampaignById", new { updateCampaignModel.CampaignId });
                }
                _toastNotification.AddErrorToastMessage("Kampanya güncellenemedi.");
                return View();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpDelete("campaign/delete/{campaignId}")]
        public async Task<IActionResult> DeleteCampaign(int campaignId)
        {
            try
            {
                var existingCampaign = await _campaignService.GetCampaignByIdAsync(campaignId);
                if (existingCampaign.Errors != null || existingCampaign.Data == null)
                {
                    _toastNotification.AddErrorToastMessage("Silinecek kampanya bulunamadı.");
                    return RedirectToAction("GetAllCampaigns");
                }

                var response = await _campaignService.DeleteCampaignAsync(campaignId);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Kampanya başarıyla silindi.");
                    return RedirectToAction("GetAllCampaigns");
                }
                _toastNotification.AddErrorToastMessage("Kampanya silinemedi.");
                return View();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpGet("campaign/{campaignId}/products")]
        public async Task<IActionResult> GetProductsByCampaignId(int campaignId)
        {
            try
            {
                var response = await _campaignService.GetProductsByCampaignIdAsync(campaignId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }
                _toastNotification.AddErrorToastMessage("Kampanyaya ait ürünler bulunamadı.");
                return View(new List<ProductModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<ProductModel>());
            }
        }

        [HttpGet("campaign/business/{businessProfileId}")]
        public async Task<IActionResult> GetCampaignsByBusinessProfileId(int businessProfileId)
        {
            try
            {
                var response = await _campaignService.GetCampaignsByBusinessProfileIdAsync(businessProfileId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }
                _toastNotification.AddErrorToastMessage("İşletmeye ait kampanyalar bulunamadı.");
                return View(new List<CampaignModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<CampaignModel>());
            }
        }

        [HttpGet("campaign/date-range")]
        public async Task<IActionResult> GetCampaignsByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var response = await _campaignService.GetCampaignsByDateRangeAsync(startDate, endDate);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }
                _toastNotification.AddErrorToastMessage("Belirtilen tarihlerde kampanya bulunamadı.");
                return View(new List<CampaignModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<CampaignModel>());
            }
        }

        [HttpPut("campaign/{campaignId}/update-products")]
        public async Task<IActionResult> UpdateCampaignProducts(int campaignId, [FromBody] IEnumerable<int> productIds)
        {
            if (productIds == null || !productIds.Any())
            {
                _toastNotification.AddErrorToastMessage("Kampanyaya en az bir ürün eklenmelidir.");
                return BadRequest("Ürün listesi boş olamaz.");
            }

            try
            {
                var response = await _campaignService.UpdateCampaignProductsAsync(campaignId, productIds);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Kampanya ürünleri başarıyla güncellendi.");
                    return RedirectToAction("GetCampaignById", new { campaignId });
                }
                _toastNotification.AddErrorToastMessage("Kampanya ürünleri güncellenemedi.");
                return View();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View();
            }
        }
    }
}
