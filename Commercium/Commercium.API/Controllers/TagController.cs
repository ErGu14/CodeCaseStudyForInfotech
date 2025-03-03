using Commercium.Service.Interfaces;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Tags.TagRMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commercium.API.Controllers
{
    [ApiController]
    [Route("api/tag")]
    public class TagController : CustomizingController
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpGet("{tagId}")]
        public async Task<IActionResult> GetTagById(int tagId)
        {
            var response = await _tagService.GetTagByIdAsync(tagId);
            return CreateReturn(response);
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllTags()
        {
            var response = await _tagService.GetAllTagsAsync();
            return CreateReturn(response);
        }

       
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateTag([FromBody] CreateTagRM createTagRM)
        {
            var response = await _tagService.CreateTagAsync(createTagRM);
            return CreateReturn(response);
        }

     
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateTag([FromBody] UpdateTagRM updateTagRM)
        {
            var response = await _tagService.UpdateTagAsync(updateTagRM);
            return CreateReturn(response);
        }

     
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpDelete("delete/{tagId}")]
        public async Task<IActionResult> DeleteTag(int tagId)
        {
            var response = await _tagService.DeleteTagAsync(tagId);
            return CreateReturn(response);
        }

      
        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpGet("{tagId}/products")]
        public async Task<IActionResult> GetProductsByTag(int tagId)
        {
            var response = await _tagService.GetProductsByTagAsync(tagId);
            return CreateReturn(response);
        }

        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpGet("{tagId}/services")]
        public async Task<IActionResult> GetServicesByTag(int tagId)
        {
            var response = await _tagService.GetServicesByTagAsync(tagId);
            return CreateReturn(response);
        }

       
        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpGet("{tagId}/businesses")]
        public async Task<IActionResult> GetBusinessesByTag(int tagId)
        {
            var response = await _tagService.GetBusinessesByTagAsync(tagId);
            return CreateReturn(response);
        }

  
        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpGet("top")]
        public async Task<IActionResult> GetTopTags([FromQuery] int count)
        {
            var response = await _tagService.GetTopTagsAsync(count);
            return CreateReturn(response);
        }
    }

}
