using AutoMapper;
using Commercium.Data.Interfaces;
using Commercium.Entity.Tags;
using Commercium.Entity;
using Commercium.Service.Interfaces;
using Commercium.Shared.ProductCategoryRMs;
using Commercium.Shared.ProductRMs;
using Commercium.Shared.ReturnRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Commercium.Shared.Tags.ProductTagRMs;

namespace Commercium.Service.Classes
{
    public class ProductService : IProductService
    {
        private readonly IGenericManager<Product> _productManager;
        private readonly IGenericManager<ProductCategory> _productCategoryManager;
        private readonly IGenericManager<ProductTag> _productTagManager;
        private readonly ITransactionManager _transactionManager;
        private readonly IMapper _mapper;

        public ProductService(
            IGenericManager<Product> productManager,
            IGenericManager<ProductCategory> productCategoryManager,
            IGenericManager<ProductTag> productTagManager,
            ITransactionManager transactionManager,
            IMapper mapper)
        {
            _productManager = productManager;
            _productCategoryManager = productCategoryManager;
            _productTagManager = productTagManager;
            _transactionManager = transactionManager;
            _mapper = mapper;
        }

        //  Ürün ID'sine göre getirme
        public async Task<ReturnRM<ProductRM>> GetProductByIdAsync(int productId)
        {
            var product = await _productManager.GetAsync(
                x => x.ProductId == productId,
                x => x.Include(p => p.ProductCategories).Include(p => p.ProductTags));

            if (product == null)
            {
                return ReturnRM<ProductRM>.Fail("Ürün bulunamadı.", 404);
            }

            var productRM = _mapper.Map<ProductRM>(product);
            return ReturnRM<ProductRM>.Success(productRM, 200);
        }

        //  Tüm ürünleri getirme
        public async Task<ReturnRM<IEnumerable<ProductRM>>> GetAllProductsAsync()
        {
            var products = await _productManager.GetAllAsync(
                includes: x => x.Include(p => p.ProductCategories).Include(p => p.ProductTags));

            if (products == null || !products.Any())
            {
                return ReturnRM<IEnumerable<ProductRM>>.Fail("Hiç ürün bulunamadı.", 404);
            }

            var productRMs = _mapper.Map<IEnumerable<ProductRM>>(products);
            return ReturnRM<IEnumerable<ProductRM>>.Success(productRMs, 200);
        }

        //  İşletmeye ait ürünleri getirme
        public async Task<ReturnRM<IEnumerable<ProductRM>>> GetProductsByBusinessAsync(int businessProfileId)
        {
            var products = await _productManager.GetAllAsync(
                x => x.BusinessProfileId == businessProfileId,
                includes: x => x.Include(p => p.ProductCategories).Include(p => p.ProductTags));

            if (products == null || !products.Any())
            {
                return ReturnRM<IEnumerable<ProductRM>>.Fail("İşletmeye ait ürün bulunamadı.", 404);
            }

            var productRMs = _mapper.Map<IEnumerable<ProductRM>>(products);
            return ReturnRM<IEnumerable<ProductRM>>.Success(productRMs, 200);
        }

        //  Kategoriye ait ürünleri getirme
        public async Task<ReturnRM<IEnumerable<ProductRM>>> GetProductsByCategoryAsync(int categoryId)
        {
            var products = await _productManager.GetAllAsync(
                x => x.ProductCategories.Any(pc => pc.CategoryId == categoryId),
                includes: x => x.Include(p => p.ProductCategories).Include(p => p.ProductTags));

            if (products == null || !products.Any())
            {
                return ReturnRM<IEnumerable<ProductRM>>.Fail("Kategoriye ait ürün bulunamadı.", 404);
            }

            var productRMs = _mapper.Map<IEnumerable<ProductRM>>(products);
            return ReturnRM<IEnumerable<ProductRM>>.Success(productRMs, 200);
        }

        //  Etikete ait ürünleri getirme
        public async Task<ReturnRM<IEnumerable<ProductRM>>> GetProductsByTagAsync(int tagId)
        {
            var products = await _productManager.GetAllAsync(
                x => x.ProductTags.Any(pt => pt.TagId == tagId),
                includes: x => x.Include(p => p.ProductCategories).Include(p => p.ProductTags));

            if (products == null || !products.Any())
            {
                return ReturnRM<IEnumerable<ProductRM>>.Fail("Etikete ait ürün bulunamadı.", 404);
            }

            var productRMs = _mapper.Map<IEnumerable<ProductRM>>(products);
            return ReturnRM<IEnumerable<ProductRM>>.Success(productRMs, 200);
        }

        //  Popüler ürünleri getirme (beğenilenleri)
        public async Task<ReturnRM<IEnumerable<ProductRM>>> GetTopProductsAsync(int count, bool orderByLikes)
        {
            var products = await _productManager.GetTopAsync(
                count,
                orderBy: orderByLikes ? q => q.OrderByDescending(p => p.LikeCount) : q => q.OrderByDescending(p => p.ViewCount),
                includes: x => x.Include(p => p.ProductCategories).Include(p => p.ProductTags));

            if (products == null || !products.Any())
            {
                return ReturnRM<IEnumerable<ProductRM>>.Fail("Popüler ürünler bulunamadı.", 404);
            }

            var productRMs = _mapper.Map<IEnumerable<ProductRM>>(products);
            return ReturnRM<IEnumerable<ProductRM>>.Success(productRMs, 200);
        }

        //  Son eklenen ürünleri getirme
        public async Task<ReturnRM<IEnumerable<ProductRM>>> GetLatestProductsAsync(int count)
        {
            var products = await _productManager.GetTopAsync(
                count,
                orderBy: q => q.OrderByDescending(p => p.CreatedDate),
                includes: x => x.Include(p => p.ProductCategories).Include(p => p.ProductTags));

            if (products == null || !products.Any())
            {
                return ReturnRM<IEnumerable<ProductRM>>.Fail("Son eklenen ürünler bulunamadı.", 404);
            }

            var productRMs = _mapper.Map<IEnumerable<ProductRM>>(products);
            return ReturnRM<IEnumerable<ProductRM>>.Success(productRMs, 200);
        }

        //  Ürün oluşturma
        public async Task<ReturnRM<string>> CreateProductAsync(CreateProductRM createProductRM)
        {
            var product = _mapper.Map<Product>(createProductRM);

            // Ürünü kaydet
            await _productManager.AddAsync(product);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Ürün oluşturulamadı.", 500);
            }

            return ReturnRM<string>.Success("Ürün başarıyla oluşturuldu.", 201);
        }

        //  Ürün güncelleme
        public async Task<ReturnRM<string>> UpdateProductAsync(UpdateProductRM updateProductRM)
        {
            var product = await _productManager.GetByIdAsync(updateProductRM.ProductId);

            if (product == null)
            {
                return ReturnRM<string>.Fail("Ürün bulunamadı.", 404);
            }

            _mapper.Map(updateProductRM, product);
            _productManager.Update(product);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Ürün güncellenemedi.", 500);
            }

            return ReturnRM<string>.Success("Ürün başarıyla güncellendi.", 200);
        }

        //  Ürün silme
        public async Task<ReturnRM<string>> DeleteProductAsync(int productId)
        {
            var product = await _productManager.GetByIdAsync(productId);

            if (product == null)
            {
                return ReturnRM<string>.Fail("Ürün bulunamadı.", 404);
            }

            _productManager.Delete(product);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Ürün silinemedi.", 500);
            }

            return ReturnRM<string>.Success("Ürün başarıyla silindi.", 200);
        }

        //  Ürün beğeni sayısını artırma
        public async Task<ReturnRM<string>> IncreaseProductLikeCountAsync(int productId)
        {
            var product = await _productManager.GetByIdAsync(productId);

            if (product == null)
            {
                return ReturnRM<string>.Fail("Ürün bulunamadı.", 404);
            }

            product.LikeCount++;
            _productManager.Update(product);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Beğeni sayısı artırılamadı.", 500);
            }

            return ReturnRM<string>.Success("Beğeni sayısı başarıyla artırıldı.", 200);
        }

        //  Ürün tıklanma sayısını artırma
        public async Task<ReturnRM<string>> IncreaseProductClickCountAsync(int productId)
        {
            var product = await _productManager.GetByIdAsync(productId);

            if (product == null)
            {
                return ReturnRM<string>.Fail("Ürün bulunamadı.", 404);
            }

            product.ClickCount++;
            _productManager.Update(product);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Tıklanma sayısı artırılamadı.", 500);
            }

            return ReturnRM<string>.Success("Tıklanma sayısı başarıyla artırıldı.", 200);
        }

        //  Ürün görüntülenme sayısını artırma
        public async Task<ReturnRM<string>> IncreaseProductViewCountAsync(int productId)
        {
            var product = await _productManager.GetByIdAsync(productId);

            if (product == null)
            {
                return ReturnRM<string>.Fail("Ürün bulunamadı.", 404);
            }

            product.ViewCount++;
            _productManager.Update(product);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Görüntülenme sayısı artırılamadı.", 500);
            }

            return ReturnRM<string>.Success("Görüntülenme sayısı başarıyla artırıldı.", 200);
        }

        //  Ürün kategori ekleme
        public async Task<ReturnRM<string>> AddProductCategoryAsync(ProductCategoryRM productCategoryRM)
        {
            var productCategory = _mapper.Map<ProductCategory>(productCategoryRM);

            await _productCategoryManager.AddAsync(productCategory);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Kategori ürüne eklenemedi.", 500);
            }

            return ReturnRM<string>.Success("Kategori başarıyla eklendi.", 201);
        }

        //  Ürün kategori kaldırma
        public async Task<ReturnRM<string>> RemoveProductCategoryAsync(ProductCategoryRM productCategoryRM)
        {
            var productCategory = await _productCategoryManager.GetAsync(
                x => x.ProductId == productCategoryRM.ProductId && x.CategoryId == productCategoryRM.CategoryId);

            if (productCategory == null)
            {
                return ReturnRM<string>.Fail("Bu kategori üründen kaldırılmamış.", 404);
            }

            _productCategoryManager.Delete(productCategory);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Kategori ürününden kaldırılamadı.", 500);
            }

            return ReturnRM<string>.Success("Kategori başarıyla ürününden kaldırıldı.", 200);
        }

        //  Ürün etiket ekleme
        public async Task<ReturnRM<string>> AddProductTagAsync(CreateProductTagRM createProductTagRM)
        {
            // Etiket ilişkisini oluşturma
            var productTag = _mapper.Map<ProductTag>(createProductTagRM);

            // Ürün etiketini ekle
            await _productTagManager.AddAsync(productTag);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Etiket ürüne eklenemedi.", 500);
            }

            return ReturnRM<string>.Success("Etiket başarıyla ürüne eklendi.", 201);
        }

        //  Ürün etiket kaldırma
        public async Task<ReturnRM<string>> RemoveProductTagAsync(UpdateProductTagRM updateProductTagRM)
        {
            // Ürün ve etiket ilişkisini bulma
            var productTag = await _productTagManager.GetAsync(
                x => x.ProductId == updateProductTagRM.ProductId && x.TagId == updateProductTagRM.TagId);

            if (productTag == null)
            {
                return ReturnRM<string>.Fail("Etiket ürünle ilişkili değil.", 404);
            }

            // Ürün etiketini kaldırma
            _productTagManager.Delete(productTag);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Etiket üründen kaldırılamadı.", 500);
            }

            return ReturnRM<string>.Success("Etiket başarıyla üründen kaldırıldı.", 200);
        }

    }
}
