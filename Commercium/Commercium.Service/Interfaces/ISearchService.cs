using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Search.SearchRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Interfaces
{
    public interface ISearchService
    {
        //  Arama İşlemleri
        Task<ReturnRM<IEnumerable<SearchResultRM>>> SearchAsync(string query);
        Task<ReturnRM<string>> SaveSearchHistoryAsync(string userId, string query);
        Task<ReturnRM<IEnumerable<SearchHistoryRM>>> GetUserSearchHistoryAsync(string userId);


        //  Etiketlere Göre Arama
        Task<ReturnRM<IEnumerable<SearchResultRM>>> SearchByTagAsync(int tagId);

       
    }

}
