using AutoMapper;
using Commercium.Data.Interfaces;
using Commercium.Entity.Businness;
using Commercium.Entity.Search;
using Commercium.Entity;
using Commercium.Service.Interfaces;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Search.SearchRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Classes
{
    public class SearchService : ISearchService
    {
        private readonly IGenericManager<SearchHistory> _searchHistoryManager;
        private readonly IGenericManager<Product> _productManager;
        private readonly IGenericManager<Entity.Businness.Service> _serviceManager;
        private readonly IGenericManager<BusinessProfile> _businessProfileManager;
        private readonly ITransactionManager _transactionManager;
        private readonly IMapper _mapper;

        public SearchService(
            IGenericManager<SearchHistory> searchHistoryManager,
            IGenericManager<Product> productManager,
            IGenericManager<Entity.Businness.Service> serviceManager,
            IGenericManager<BusinessProfile> businessProfileManager,
            ITransactionManager transactionManager,
            IMapper mapper)
        {
            _searchHistoryManager = searchHistoryManager;
            _productManager = productManager;
            _serviceManager = serviceManager;
            _businessProfileManager = businessProfileManager;
            _transactionManager = transactionManager;
            _mapper = mapper;
        }

        //  Arama yapma
        public async Task<ReturnRM<IEnumerable<SearchResultRM>>> SearchAsync(string query)
        {
            var products = await _productManager.GetAllAsync(x => x.Name.Contains(query) || x.Description.Contains(query));
            var services = await _serviceManager.GetAllAsync(x => x.ServiceName.Contains(query) || x.Description.Contains(query));
            var businessProfiles = await _businessProfileManager.GetAllAsync(x => x.BusinessName.Contains(query) || x.BusinessDescription.Contains(query));

            var searchResults = new List<SearchResultRM>();

            searchResults.AddRange(_mapper.Map<IEnumerable<SearchResultRM>>(products));
            searchResults.AddRange(_mapper.Map<IEnumerable<SearchResultRM>>(services));
            searchResults.AddRange(_mapper.Map<IEnumerable<SearchResultRM>>(businessProfiles));

            return ReturnRM<IEnumerable<SearchResultRM>>.Success(searchResults, 200);
        }

        //  Arama geçmişi kaydetme
        public async Task<ReturnRM<string>> SaveSearchHistoryAsync(string userId, string query)
        {
            var searchHistory = new SearchHistory
            {
                UserId = userId,
                SearchQuery = query,
                SearchDate = DateTime.UtcNow
            };

            await _searchHistoryManager.AddAsync(searchHistory);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Arama geçmişi kaydedilemedi.", 500);
            }

            return ReturnRM<string>.Success("Arama geçmişi başarıyla kaydedildi.", 201);
        }

        //  Kullanıcı arama geçmişini getirme
        public async Task<ReturnRM<IEnumerable<SearchHistoryRM>>> GetUserSearchHistoryAsync(string userId)
        {
            var searchHistory = await _searchHistoryManager.GetAllAsync(x => x.UserId == userId);

            if (searchHistory == null || !searchHistory.Any())
            {
                return ReturnRM<IEnumerable<SearchHistoryRM>>.Fail("Kullanıcının arama geçmişi bulunamadı.", 404);
            }

            var searchHistoryRMs = _mapper.Map<IEnumerable<SearchHistoryRM>>(searchHistory);
            return ReturnRM<IEnumerable<SearchHistoryRM>>.Success(searchHistoryRMs, 200);
        }

        
        //  Etikete göre arama
        public async Task<ReturnRM<IEnumerable<SearchResultRM>>> SearchByTagAsync(int tagId)
        {
            var products = await _productManager.GetAllAsync(
                x => x.ProductTags.Any(pt => pt.TagId == tagId));
            var services = await _serviceManager.GetAllAsync(
                x => x.ServiceTags.Any(st => st.TagId == tagId));

            var searchResults = new List<SearchResultRM>();

            searchResults.AddRange(_mapper.Map<IEnumerable<SearchResultRM>>(products));
            searchResults.AddRange(_mapper.Map<IEnumerable<SearchResultRM>>(services));

            return ReturnRM<IEnumerable<SearchResultRM>>.Success(searchResults, 200);
        }

        
    }

}
