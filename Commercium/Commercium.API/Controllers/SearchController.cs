using Commercium.Service.Interfaces;
using Commercium.Shared.ReturnRMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commercium.API.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : CustomizingController
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

      
        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            var response = await _searchService.SearchAsync(query);
            return CreateReturn(response);
        }


        [Authorize(Roles = "User")]
        [HttpPost("save-history")]
        public async Task<IActionResult> SaveSearchHistory([FromBody] string query, [FromQuery] string userId)
        {
            var response = await _searchService.SaveSearchHistoryAsync(userId, query);
            return CreateReturn(response);
        }

        [Authorize(Roles = "User")]
        [HttpGet("user/{userId}/history")]
        public async Task<IActionResult> GetUserSearchHistory(string userId)
        {
            var response = await _searchService.GetUserSearchHistoryAsync(userId);
            return CreateReturn(response);
        }

     
        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpGet("search-by-tag/{tagId}")]
        public async Task<IActionResult> SearchByTag(int tagId)
        {
            var response = await _searchService.SearchByTagAsync(tagId);
            return CreateReturn(response);
        }
    }

}
