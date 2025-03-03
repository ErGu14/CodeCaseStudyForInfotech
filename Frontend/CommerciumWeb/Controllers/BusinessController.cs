using CommerciumWeb.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace CommerciumWeb.Controllers
{
    public class BusinessController : Controller
    {
        private readonly IBusinessService _businessService;
        private readonly IToastNotification _toastNotification;

        public BusinessController(IBusinessService businessService, IToastNotification toastNotification)
        {
            _businessService = businessService;
            _toastNotification = toastNotification;
        }

        [HttpGet("business/{businessProfileId}")]
        public async Task<IActionResult> GetBusinessById(int businessProfileId)
        {
            try
            {
                var response = await _businessService.GetBusinessByIdAsync(businessProfileId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }
                _toastNotification.AddErrorToastMessage("İşletme bilgileri alınamadı.");
                return View();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata oluştu: {ex.Message}");
                return View();
            }
        }

        [HttpGet("business/all")]
        public async Task<IActionResult> GetAllBusinesses()
        {
            try
            {
                var response = await _businessService.GetAllBusinessesAsync();
                if (response.Errors == null)
                {
                    return View(response.Data);
                }
                _toastNotification.AddErrorToastMessage("İşletmeler getirilemedi.");
                return View();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata oluştu: {ex.Message}");
                return View();
            }
        }

        [HttpPost("business/create")]
        public async Task<IActionResult> CreateBusiness([FromBody] BusinessProfileModel createBusinessProfileModel)
        {
            try
            {
                var response = await _businessService.CreateBusinessAsync(createBusinessProfileModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("İşletme başarıyla oluşturuldu.");
                    return RedirectToAction("GetAllBusinesses");
                }
                _toastNotification.AddErrorToastMessage("İşletme oluşturulamadı.");
                return View();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata oluştu: {ex.Message}");
                return View();
            }
        }

        [HttpPut("business/update")]
        public async Task<IActionResult> UpdateBusiness([FromBody] BusinessProfileModel updateBusinessProfileModel)
        {
            try
            {
                var response = await _businessService.UpdateBusinessAsync(updateBusinessProfileModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("İşletme başarıyla güncellendi.");
                    return RedirectToAction("GetBusinessById", new { updateBusinessProfileModel.BusinessProfileId });
                }
                _toastNotification.AddErrorToastMessage("İşletme güncellenemedi.");
                return View();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata oluştu: {ex.Message}");
                return View();
            }
        }

        [HttpDelete("business/delete/{businessProfileId}")]
        public async Task<IActionResult> DeleteBusiness(int businessProfileId)
        {
            try
            {
                var response = await _businessService.DeleteBusinessAsync(businessProfileId);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("İşletme başarıyla silindi.");
                    return RedirectToAction("GetAllBusinesses");
                }
                _toastNotification.AddErrorToastMessage("İşletme silinemedi.");
                return View();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata oluştu: {ex.Message}");
                return View();
            }
        }

        [HttpPost("business/increase-like/{businessProfileId}")]
        public async Task<IActionResult> IncreaseBusinessLikeCount(int businessProfileId)
        {
            try
            {
                await _businessService.IncreaseBusinessLikeCountAsync(businessProfileId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata oluştu: {ex.Message}");
            }
        }

        [HttpPost("business/increase-click/{businessProfileId}")]
        public async Task<IActionResult> IncreaseBusinessClickCount(int businessProfileId)
        {
            try
            {
                await _businessService.IncreaseBusinessClickCountAsync(businessProfileId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata oluştu: {ex.Message}");
            }
        }

        [HttpPost("business/increase-view/{businessProfileId}")]
        public async Task<IActionResult> IncreaseBusinessViewCount(int businessProfileId)
        {
            try
            {
                await _businessService.IncreaseBusinessViewCountAsync(businessProfileId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata oluştu: {ex.Message}");
            }
        }

        [HttpPut("business/customize-profile")]
        public async Task<IActionResult> CustomizeBusinessProfile([FromBody] BusinessProfileCustomizationModel model)
        {
            try
            {
                var response = await _businessService.CustomizeBusinessProfileAsync(model);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("İşletme profili özelleştirildi.");
                    return RedirectToAction("GetBusinessById", new { model.BusinessProfileId });
                }
                _toastNotification.AddErrorToastMessage("Profil özelleştirilemedi.");
                return View();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata oluştu: {ex.Message}");
                return View();
            }
        }

        [HttpPost("business/add-tag")]
        public async Task<IActionResult> AddBusinessTag([FromBody] BusinessProfileCustomizationModel model)
        {
            try
            {
                var response = await _businessService.AddBusinessTagAsync(model);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Etiket başarıyla eklendi.");
                    return RedirectToAction("GetBusinessById", new { model.BusinessProfileId });
                }
                _toastNotification.AddErrorToastMessage("Etiket eklenemedi.");
                return View();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata oluştu: {ex.Message}");
                return View();
            }
        }

        [HttpDelete("business/remove-tag")]
        public async Task<IActionResult> RemoveBusinessTag([FromBody] BusinessProfileCustomizationModel model)
        {
            try
            {
                var response = await _businessService.RemoveBusinessTagAsync(model);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Etiket başarıyla kaldırıldı.");
                    return RedirectToAction("GetBusinessById", new { model.BusinessProfileId });
                }
                _toastNotification.AddErrorToastMessage("Etiket kaldırma işlemi başarısız.");
                return View();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
