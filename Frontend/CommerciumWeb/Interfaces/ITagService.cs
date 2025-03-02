using CommerciumWeb.Models;

namespace CommerciumWeb.Interfaces
{
    public interface ITagService
    {
        Task<ReturnModel<TagModel>> GetTagByIdAsync(int tagId);
        Task<ReturnModel<IEnumerable<TagModel>>> GetAllTagsAsync();
        Task<ReturnModel<string>> CreateTagAsync(TagModel createTagModel);
        Task<ReturnModel<string>> UpdateTagAsync(TagModel updateTagModel);
        Task<ReturnModel<string>> DeleteTagAsync(int tagId);
        Task<ReturnModel<IEnumerable<ProductModel>>> GetProductsByTagAsync(int tagId);
        Task<ReturnModel<IEnumerable<BusinessServiceModel>>> GetServicesByTagAsync(int tagId);
        Task<ReturnModel<IEnumerable<BusinessProfileModel>>> GetBusinessesByTagAsync(int tagId);
        Task<ReturnModel<IEnumerable<TagModel>>> GetTopTagsAsync(int count);
    }
}
