using CommerciumWeb.Models;
using CommerciumWeb.Models.ProductModels;

namespace CommerciumWeb.Interfaces
{
    public interface IProductService
    {
        Task<ReturnModel<ProductModel>> GetProductByIdAsync(int productId);
        Task<ReturnModel<IEnumerable<ProductModel>>> GetAllProductsAsync();
        Task<ReturnModel<IEnumerable<ProductModel>>> GetProductsByBusinessAsync(int businessProfileId);
        Task<ReturnModel<IEnumerable<ProductModel>>> GetProductsByCategoryAsync(int categoryId);
        Task<ReturnModel<IEnumerable<ProductModel>>> GetProductsByTagAsync(int tagId);
        Task<ReturnModel<IEnumerable<ProductModel>>> GetLatestProductsAsync(int count);

        Task<ReturnModel<string>> CreateProductAsync(ProductModel createProductModel);
        Task<ReturnModel<string>> UpdateProductAsync(ProductModel updateProductModel);
        Task<ReturnModel<string>> DeleteProductAsync(int productId);

        Task<ReturnModel<string>> IncreaseProductLikeCountAsync(int productId);
        Task<ReturnModel<string>> IncreaseProductClickCountAsync(int productId);
        Task<ReturnModel<string>> IncreaseProductViewCountAsync(int productId);

        Task<ReturnModel<string>> AddProductCategoryAsync(ProductCategoryModel productCategoryModel);
        Task<ReturnModel<string>> RemoveProductCategoryAsync(ProductCategoryModel productCategoryModel);

        Task<ReturnModel<string>> AddProductTagAsync(ProductTagModel createProductTagModel);
        Task<ReturnModel<string>> RemoveProductTagAsync(ProductTagModel updateProductTagModel);
    }

}
