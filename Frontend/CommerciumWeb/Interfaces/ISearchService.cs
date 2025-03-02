using CommerciumWeb.Models;
using CommerciumWeb.Models.SearchModels.Commercium.MVC.Models;
using CommerciumWeb.Models.SearchModels;

namespace CommerciumWeb.Interfaces
{
    public interface ISearchService
    {
        Task<ReturnModel<IEnumerable<SearchResultModel>>> SearchAsync(string query);
        Task<ReturnModel<string>> SaveSearchHistoryAsync(string userId, string query);
        Task<ReturnModel<IEnumerable<SearchHistoryModel>>> GetUserSearchHistoryAsync(string userId);
        Task<ReturnModel<IEnumerable<SearchResultModel>>> SearchByTagAsync(int tagId);
    }
}
