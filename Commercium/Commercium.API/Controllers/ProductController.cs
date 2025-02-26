using Commercium.Service.Interfaces;
using Commercium.Shared.ProductCategoryRMs;
using Commercium.Shared.ProductRMs;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Tags.ProductTagRMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commercium.API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : CustomizingController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // Ürün Detaylarını ID ile Getirme - Tüm roller erişebilir
        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var response = await _productService.GetProductByIdAsync(productId);
            return CreateReturn(response);
        }

        // Tüm Ürünleri Getirme - Admin ve BusinessOwner erişebilir
        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productService.GetAllProductsAsync();
            return CreateReturn(response);
        }

        // İşletme Profili ID'sine Göre Ürünleri Getirme - Admin ve BusinessOwner erişebilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpGet("business/{businessProfileId}")]
        public async Task<IActionResult> GetProductsByBusiness(int businessProfileId)
        {
            var response = await _productService.GetProductsByBusinessAsync(businessProfileId);
            return CreateReturn(response);
        }

        // Kategori ID'sine Göre Ürünleri Getirme - Admin ve BusinessOwner erişebilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            var response = await _productService.GetProductsByCategoryAsync(categoryId);
            return CreateReturn(response);
        }

        // Etiket ID'sine Göre Ürünleri Getirme - Admin ve BusinessOwner erişebilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpGet("tag/{tagId}")]
        public async Task<IActionResult> GetProductsByTag(int tagId)
        {
            var response = await _productService.GetProductsByTagAsync(tagId);
            return CreateReturn(response);
        }

        // Son Eklenen Ürünleri Getirme - Tüm roller erişebilir
        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestProducts([FromQuery] int count)
        {
            var response = await _productService.GetLatestProductsAsync(count);
            return CreateReturn(response);
        }

        // Ürün Oluşturma - Admin ve BusinessOwner erişebilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRM createProductRM)
        {
            var response = await _productService.CreateProductAsync(createProductRM);
            return CreateReturn(response);
        }

        // Ürün Güncelleme - Admin ve BusinessOwner erişebilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRM updateProductRM)
        {
            var response = await _productService.UpdateProductAsync(updateProductRM);
            return CreateReturn(response);
        }

        // Ürün Silme - Admin ve BusinessOwner erişebilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpDelete("delete/{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var response = await _productService.DeleteProductAsync(productId);
            return CreateReturn(response);
        }

        // Ürün Beğeni Sayısını Artırma - Tüm roller erişebilir
        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpPost("increase-like/{productId}")]
        public async Task<IActionResult> IncreaseProductLikeCount(int productId)
        {
            var response = await _productService.IncreaseProductLikeCountAsync(productId);
            return CreateReturn(response);
        }

        // Ürün Tıklama Sayısını Artırma - Tüm roller erişebilir
        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpPost("increase-click/{productId}")]
        public async Task<IActionResult> IncreaseProductClickCount(int productId)
        {
            var response = await _productService.IncreaseProductClickCountAsync(productId);
            return CreateReturn(response);
        }

        // Ürün Görüntülenme Sayısını Artırma - Tüm roller erişebilir
        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpPost("increase-view/{productId}")]
        public async Task<IActionResult> IncreaseProductViewCount(int productId)
        {
            var response = await _productService.IncreaseProductViewCountAsync(productId);
            return CreateReturn(response);
        }

        // Ürün Kategorisi Ekleme - Admin ve BusinessOwner erişebilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpPost("add-category")]
        public async Task<IActionResult> AddProductCategory([FromBody] ProductCategoryRM productCategoryRM)
        {
            var response = await _productService.AddProductCategoryAsync(productCategoryRM);
            return CreateReturn(response);
        }

        // Ürün Kategorisi Kaldırma - Admin ve BusinessOwner erişebilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpPost("remove-category")]
        public async Task<IActionResult> RemoveProductCategory([FromBody] ProductCategoryRM productCategoryRM)
        {
            var response = await _productService.RemoveProductCategoryAsync(productCategoryRM);
            return CreateReturn(response);
        }

        // Ürün Etiketi Ekleme - Admin ve BusinessOwner erişebilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpPost("add-tag")]
        public async Task<IActionResult> AddProductTag([FromBody] CreateProductTagRM createProductTagRM)
        {
            var response = await _productService.AddProductTagAsync(createProductTagRM);
            return CreateReturn(response);
        }

        // Ürün Etiketi Kaldırma - Admin ve BusinessOwner erişebilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpPost("remove-tag")]
        public async Task<IActionResult> RemoveProductTag([FromBody] UpdateProductTagRM updateProductTagRM)
        {
            var response = await _productService.RemoveProductTagAsync(updateProductTagRM);
            return CreateReturn(response);
        }
    }

}
