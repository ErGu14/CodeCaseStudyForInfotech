using CommerciumWeb.Interfaces;
using CommerciumWeb.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommerciumWeb.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IToastNotification _toastNotification;

        public TagController(ITagService tagService, IToastNotification toastNotification)
        {
            _tagService = tagService;
            _toastNotification = toastNotification;
        }

        [HttpGet("tag/{tagId}")]
        public async Task<IActionResult> GetTagById(int tagId)
        {
            if (tagId == 0)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz etiket kimliği.");
                return BadRequest("Etiket kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _tagService.GetTagByIdAsync(tagId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Etiket bilgisi getirilemedi.");
                return View(new TagModel());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new TagModel());
            }
        }

        [HttpGet("tag/all")]
        public async Task<IActionResult> GetAllTags()
        {
            try
            {
                var response = await _tagService.GetAllTagsAsync();
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Etiketler getirilemedi.");
                return View(new List<TagModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<TagModel>());
            }
        }

        [HttpPost("tag/create")]
        public async Task<IActionResult> CreateTag(TagModel createTagModel)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz etiket bilgileri.");
                return View(createTagModel);
            }

            try
            {
                var response = await _tagService.CreateTagAsync(createTagModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Etiket başarıyla oluşturuldu.");
                    return RedirectToAction("GetAllTags");
                }

                _toastNotification.AddErrorToastMessage("Etiket oluşturulamadı.");
                return View(createTagModel);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(createTagModel);
            }
        }

        [HttpPut("tag/update")]
        public async Task<IActionResult> UpdateTag(TagModel updateTagModel)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz etiket bilgileri.");
                return View(updateTagModel);
            }

            try
            {
                var response = await _tagService.UpdateTagAsync(updateTagModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Etiket başarıyla güncellendi.");
                    return RedirectToAction("GetAllTags");
                }

                _toastNotification.AddErrorToastMessage("Etiket güncellenemedi.");
                return View(updateTagModel);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(updateTagModel);
            }
        }

        [HttpDelete("tag/delete/{tagId}")]
        public async Task<IActionResult> DeleteTag(int tagId)
        {
            if (tagId == 0)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz etiket kimliği.");
                return BadRequest("Etiket kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _tagService.DeleteTagAsync(tagId);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Etiket başarıyla silindi.");
                    return RedirectToAction("GetAllTags");
                }

                _toastNotification.AddErrorToastMessage("Etiket silinemedi.");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpGet("tag/{tagId}/products")]
        public async Task<IActionResult> GetProductsByTag(int tagId)
        {
            if (tagId == 0)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz etiket kimliği.");
                return BadRequest("Etiket kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _tagService.GetProductsByTagAsync(tagId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Bu etikete ait ürünler getirilemedi.");
                return View(new List<ProductModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<ProductModel>());
            }
        }

        [HttpGet("tag/{tagId}/services")]
        public async Task<IActionResult> GetServicesByTag(int tagId)
        {
            if (tagId == 0)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz etiket kimliği.");
                return BadRequest("Etiket kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _tagService.GetServicesByTagAsync(tagId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Bu etikete ait hizmetler getirilemedi.");
                return View(new List<BusinessServiceModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<BusinessServiceModel>());
            }
        }

        [HttpGet("tag/{tagId}/businesses")]
        public async Task<IActionResult> GetBusinessesByTag(int tagId)
        {
            if (tagId == 0)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz etiket kimliği.");
                return BadRequest("Etiket kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _tagService.GetBusinessesByTagAsync(tagId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Bu etikete ait işletmeler getirilemedi.");
                return View(new List<BusinessProfileModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<BusinessProfileModel>());
            }
        }

        [HttpGet("tag/top")]
        public async Task<IActionResult> GetTopTags(int count = 10)
        {
            try
            {
                var response = await _tagService.GetTopTagsAsync(count);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Popüler etiketler getirilemedi.");
                return View(new List<TagModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<TagModel>());
            }
        }
    }
}
