using Commercium.Shared.ProductCategoryRMs;
using Commercium.Shared.ProductRMs;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Tags.ProductTagRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Interfaces
{
    public interface IProductService
    {
        //  Ürünleri Getirme
        Task<ReturnRM<ProductRM>> GetProductByIdAsync(int productId);
        Task<ReturnRM<IEnumerable<ProductRM>>> GetAllProductsAsync();
        Task<ReturnRM<IEnumerable<ProductRM>>> GetProductsByBusinessAsync(int businessProfileId);
        Task<ReturnRM<IEnumerable<ProductRM>>> GetProductsByCategoryAsync(int categoryId);
        Task<ReturnRM<IEnumerable<ProductRM>>> GetProductsByTagAsync(int tagId);
     
        Task<ReturnRM<IEnumerable<ProductRM>>> GetLatestProductsAsync(int count);

        //  Ürün Yönetimi
        Task<ReturnRM<string>> CreateProductAsync(CreateProductRM createProductRM);
        Task<ReturnRM<string>> UpdateProductAsync(UpdateProductRM updateProductRM);
        Task<ReturnRM<string>> DeleteProductAsync(int productId);

        //  Ürün Beğeni, Tıklanma & Görüntülenme Sayısı Yönetimi
        Task<ReturnRM<string>> IncreaseProductLikeCountAsync(int productId);
        Task<ReturnRM<string>> IncreaseProductClickCountAsync(int productId);
        Task<ReturnRM<string>> IncreaseProductViewCountAsync(int productId);

        // Ürün Kategori Yönetimi
        Task<ReturnRM<string>> AddProductCategoryAsync(ProductCategoryRM productCategoryRM);
        Task<ReturnRM<string>> RemoveProductCategoryAsync(ProductCategoryRM productCategoryRM);

        //  Ürün Etiket Yönetimi
        Task<ReturnRM<string>> AddProductTagAsync(CreateProductTagRM createProductTagRM);
        Task<ReturnRM<string>> RemoveProductTagAsync(UpdateProductTagRM updateProductTagRM);
    }

}
