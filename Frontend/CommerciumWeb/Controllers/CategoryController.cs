using CommerciumWeb.Interfaces;
using CommerciumWeb.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommerciumWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IToastNotification _toastNotification;

        public CategoryController(ICategoryService categoryService, IToastNotification toastNotification)
        {
            _categoryService = categoryService;
            _toastNotification = toastNotification;
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            try
            {
                var response = await _categoryService.GetCategoryByIdAsync(categoryId);
                if (response.Errors == null && response.Data != null)
                {
                    return View(response.Data);
                }
                _toastNotification.AddErrorToastMessage("Kategori bulunamadı.");
                return RedirectToAction("GetAllCategories");
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return RedirectToAction("GetAllCategories");
            }
        }

        [HttpGet("category/all")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var response = await _categoryService.GetAllCategoriesAsync();
                if (response.Errors == null)
                {
                    return View(response.Data);
                }
                _toastNotification.AddErrorToastMessage("Kategoriler getirilemedi.");
                return View(new List<CategoryModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<CategoryModel>());
            }
        }

        [HttpPost("category/create")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryModel createCategoryModel)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Kategori bilgileri eksik veya hatalı.");
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _categoryService.CreateCategoryAsync(createCategoryModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Kategori başarıyla oluşturuldu.");
                    return RedirectToAction("GetAllCategories");
                }
                _toastNotification.AddErrorToastMessage("Kategori oluşturulamadı.");
                return View();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Kategori oluşturulurken hata oluştu: {ex.Message}");
                return View();
            }
        }

        [HttpPut("category/update")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryModel updateCategoryModel)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Kategori bilgileri eksik veya hatalı.");
                return BadRequest(ModelState);
            }

            try
            {
                var existingCategory = await _categoryService.GetCategoryByIdAsync(updateCategoryModel.CategoryId);
                if (existingCategory.Errors != null || existingCategory.Data == null)
                {
                    _toastNotification.AddErrorToastMessage("Güncellenecek kategori bulunamadı.");
                    return RedirectToAction("GetAllCategories");
                }

                var response = await _categoryService.UpdateCategoryAsync(updateCategoryModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Kategori başarıyla güncellendi.");
                    return RedirectToAction("GetCategoryById", new { updateCategoryModel.CategoryId });
                }
                _toastNotification.AddErrorToastMessage("Kategori güncellenemedi.");
                return View();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Kategori güncellenirken hata oluştu: {ex.Message}");
                return View();
            }
        }

        [HttpDelete("category/delete/{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            try
            {
                var existingCategory = await _categoryService.GetCategoryByIdAsync(categoryId);
                if (existingCategory.Errors != null || existingCategory.Data == null)
                {
                    _toastNotification.AddErrorToastMessage("Silinecek kategori bulunamadı.");
                    return RedirectToAction("GetAllCategories");
                }

                var productsInCategory = await _categoryService.GetProductsByCategoryAsync(categoryId);
                if (productsInCategory.Data != null && productsInCategory.Data.Any())
                {
                    _toastNotification.AddErrorToastMessage("Bu kategoride ürünler var. Önce ürünleri kaldırın.");
                    return RedirectToAction("GetCategoryById", new { categoryId });
                }

                var response = await _categoryService.DeleteCategoryAsync(categoryId);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Kategori başarıyla silindi.");
                    return RedirectToAction("GetAllCategories");
                }
                _toastNotification.AddErrorToastMessage("Kategori silinemedi.");
                return View();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Kategori silinirken hata oluştu: {ex.Message}");
                return View();
            }
        }

        [HttpGet("category/{categoryId}/products")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            try
            {
                var response = await _categoryService.GetProductsByCategoryAsync(categoryId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }
                _toastNotification.AddErrorToastMessage("Kategoride ürün bulunamadı.");
                return View(new List<ProductModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<ProductModel>());
            }
        }

        [HttpGet("category/{categoryId}/product-count")]
        public async Task<IActionResult> GetProductCountByCategory(int categoryId)
        {
            try
            {
                var response = await _categoryService.GetProductCountByCategoryAsync(categoryId);
                if (response.Errors == null)
                {
                    return Ok(response.Data);
                }
                _toastNotification.AddErrorToastMessage("Kategoriye ait ürün sayısı getirilemedi.");
                return NotFound();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası, lütfen tekrar deneyin.");
            }
        }

        [HttpGet("category/top")]
        public async Task<IActionResult> GetTopCategories([FromQuery] int count)
        {
            if (count <= 0)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz kategori sayısı.");
                return BadRequest("En az 1 kategori getirilmelidir.");
            }

            try
            {
                var response = await _categoryService.GetTopCategoriesAsync(count);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }
                _toastNotification.AddErrorToastMessage("En popüler kategoriler getirilemedi.");
                return View(new List<CategoryModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<CategoryModel>());
            }
        }
    }
}
