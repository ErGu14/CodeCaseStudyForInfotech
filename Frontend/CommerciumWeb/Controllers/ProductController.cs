using CommerciumWeb.Interfaces;
using CommerciumWeb.Models;
using CommerciumWeb.Models.ProductModels;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommerciumWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IToastNotification _toastNotification;

        public ProductController(IProductService productService, IToastNotification toastNotification)
        {
            _productService = productService;
            _toastNotification = toastNotification;
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            try
            {
                var response = await _productService.GetProductByIdAsync(productId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Ürün getirilemedi.");
                return View(new ProductModel());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new ProductModel());
            }
        }

        [HttpGet("product/all")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var response = await _productService.GetAllProductsAsync();
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Ürünler getirilemedi.");
                return View(new List<ProductModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<ProductModel>());
            }
        }

        [HttpPost("product/create")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductModel createProductModel)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz ürün bilgileri.");
                return BadRequest("Eksik veya hatalı giriş.");
            }

            try
            {
                var response = await _productService.CreateProductAsync(createProductModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Ürün başarıyla oluşturuldu.");
                    return Ok(response);
                }

                _toastNotification.AddErrorToastMessage("Ürün oluşturulamadı.");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpPut("product/update")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductModel updateProductModel)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz ürün bilgileri.");
                return BadRequest("Eksik veya hatalı giriş.");
            }

            try
            {
                var response = await _productService.UpdateProductAsync(updateProductModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Ürün başarıyla güncellendi.");
                    return Ok(response);
                }

                _toastNotification.AddErrorToastMessage("Ürün güncellenemedi.");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpDelete("product/delete/{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                var response = await _productService.DeleteProductAsync(productId);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Ürün başarıyla silindi.");
                    return Ok(response);
                }

                _toastNotification.AddErrorToastMessage("Ürün silinemedi.");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpGet("product/latest")]
        public async Task<IActionResult> GetLatestProducts(int count)
        {
            try
            {
                var response = await _productService.GetLatestProductsAsync(count);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Son eklenen ürünler getirilemedi.");
                return View(new List<ProductModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<ProductModel>());
            }
        }

        [HttpGet("product/category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            try
            {
                var response = await _productService.GetProductsByCategoryAsync(categoryId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Kategorideki ürünler getirilemedi.");
                return View(new List<ProductModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<ProductModel>());
            }
        }

        [HttpGet("product/tag/{tagId}")]
        public async Task<IActionResult> GetProductsByTag(int tagId)
        {
            try
            {
                var response = await _productService.GetProductsByTagAsync(tagId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Etikete ait ürünler getirilemedi.");
                return View(new List<ProductModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<ProductModel>());
            }
        }

        [HttpPost("product/add-category")]
        public async Task<IActionResult> AddProductCategory([FromBody] ProductCategoryModel productCategoryModel)
        {
            try
            {
                var response = await _productService.AddProductCategoryAsync(productCategoryModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Ürün kategorisi eklendi.");
                    return Ok(response);
                }

                _toastNotification.AddErrorToastMessage("Kategori eklenemedi.");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpPost("product/remove-category")]
        public async Task<IActionResult> RemoveProductCategory([FromBody] ProductCategoryModel productCategoryModel)
        {
            try
            {
                var response = await _productService.RemoveProductCategoryAsync(productCategoryModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Ürün kategorisi kaldırıldı.");
                    return Ok(response);
                }

                _toastNotification.AddErrorToastMessage("Kategori kaldırılamadı.");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }
    }
}
