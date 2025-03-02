using CommerciumWeb.Models;

namespace CommerciumWeb.Interfaces
{
    public interface ICategoryService
    {
        Task<ReturnModel<CategoryModel>> GetCategoryByIdAsync(int categoryId);
        Task<ReturnModel<IEnumerable<CategoryModel>>> GetAllCategoriesAsync();
        Task<ReturnModel<string>> CreateCategoryAsync(CategoryModel createCategoryModel);
        Task<ReturnModel<string>> UpdateCategoryAsync(CategoryModel updateCategoryModel);
        Task<ReturnModel<string>> DeleteCategoryAsync(int categoryId);
        Task<ReturnModel<IEnumerable<ProductModel>>> GetProductsByCategoryAsync(int categoryId);
        Task<ReturnModel<int>> GetProductCountByCategoryAsync(int categoryId);
        Task<ReturnModel<IEnumerable<CategoryModel>>> GetTopCategoriesAsync(int count);
    }

}
