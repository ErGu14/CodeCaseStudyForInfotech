using Commercium.Service.Interfaces;
using Commercium.Shared.Businness.CampaignRMs;
using Commercium.Shared.ReturnRMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commercium.API.Controllers
{
    [ApiController]
    [Route("api/campaign")]
    public class CampaignController : CustomizingController
    {
        private readonly ICampaignService _campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }


        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateCampaign([FromBody] CreateCampaignRM createCampaignRM)
        {
            var response = await _campaignService.CreateCampaignAsync(createCampaignRM);
            return CreateReturn(response);
        }

       
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCampaign([FromBody] UpdateCampaignRM updateCampaignRM)
        {
            var response = await _campaignService.UpdateCampaignAsync(updateCampaignRM);
            return CreateReturn(response);
        }

       
        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{campaignId}")]
        public async Task<IActionResult> DeleteCampaign(int campaignId)
        {
            var response = await _campaignService.DeleteCampaignAsync(campaignId);
            return CreateReturn(response);
        }

    
        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpGet("{campaignId}")]
        public async Task<IActionResult> GetCampaignById(int campaignId)
        {
            var response = await _campaignService.GetCampaignByIdAsync(campaignId);
            return CreateReturn(response);
        }

        
        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllCampaigns()
        {
            var response = await _campaignService.GetAllCampaignsAsync();
            return CreateReturn(response);
        }

        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpGet("{campaignId}/products")]
        public async Task<IActionResult> GetProductsByCampaignId(int campaignId)
        {
            var response = await _campaignService.GetProductsByCampaignIdAsync(campaignId);
            return CreateReturn(response);
        }

       
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpGet("business/{businessProfileId}")]
        public async Task<IActionResult> GetCampaignsByBusinessProfileId(int businessProfileId)
        {
            var response = await _campaignService.GetCampaignsByBusinessProfileIdAsync(businessProfileId);
            return CreateReturn(response);
        }

        
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpGet("date-range")]
        public async Task<IActionResult> GetCampaignsByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var response = await _campaignService.GetCampaignsByDateRangeAsync(startDate, endDate);
            return CreateReturn(response);
        }


        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpPut("{campaignId}/update-products")]
        public async Task<IActionResult> UpdateCampaignProducts(int campaignId, [FromBody] IEnumerable<int> productIds)
        {
            var response = await _campaignService.UpdateCampaignProductsAsync(campaignId, productIds);
            return CreateReturn(response);
        }
    }



}
