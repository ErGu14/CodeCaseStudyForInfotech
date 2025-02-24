using Commercium.Shared.CategoryRMs;
using Commercium.Shared.ProductRMs;
using Commercium.Shared.ReturnRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Interfaces
{
    public interface ICategoryService
    {
        //  Kategori Yönetimi
        Task<ReturnRM<CategoryRM>> GetCategoryByIdAsync(int categoryId);
        Task<ReturnRM<IEnumerable<CategoryRM>>> GetAllCategoriesAsync();
        Task<ReturnRM<string>> CreateCategoryAsync(CreateCategoryRM createCategoryRM);
        Task<ReturnRM<string>> UpdateCategoryAsync(UpdateCategoryRM updateCategoryRM);
        Task<ReturnRM<string>> DeleteCategoryAsync(int categoryId);

        //  Kategoriye Bağlı Ürünleri Getirme
        Task<ReturnRM<IEnumerable<ProductRM>>> GetProductsByCategoryAsync(int categoryId);

        //  Kategorilere Göre Ürün Sayısı
        Task<ReturnRM<int>> GetProductCountByCategoryAsync(int categoryId);

        //  En Popüler Kategorileri Getirme
        Task<ReturnRM<IEnumerable<CategoryRM>>> GetTopCategoriesAsync(int count);
    }

}
