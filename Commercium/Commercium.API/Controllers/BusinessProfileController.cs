using Commercium.Service.Interfaces;
using Commercium.Shared.Businness.BusinessProfileCustomizationRMs;
using Commercium.Shared.Businness.BusinessProfileRMs;
using Commercium.Shared.Businness.BusinessProfileTagRMs;
using Commercium.Shared.Businness.ServiceRMs;
using Commercium.Shared.ReturnRMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commercium.API.Controllers
{
    [ApiController]
    [Route("api/business-profile")]
    public class BusinessProfileController : CustomizingController
    {
        private readonly IBusinessService _businessService;

        public BusinessProfileController(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        // Admin, BusinessOwner kendi işletmesini görüntüleyebilir, SalesRepresentative ve User sadece okuma yetkisine sahip
        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative, User")]
        [HttpGet("{businessProfileId}")]
        public async Task<IActionResult> GetBusinessById(int businessProfileId)
        {
            var response = await _businessService.GetBusinessByIdAsync(businessProfileId);
            return CreateReturn(response);
        }

        // Admin ve BusinessOwner tüm işletmeleri listeleyebilir, SalesRepresentative sadece kendi işletmesini görebilir
        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllBusinesses()
        {
            var response = await _businessService.GetAllBusinessesAsync();
            return CreateReturn(response);
        }

        // Yalnızca Admin BusinessProfile oluşturabilir
        [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateBusiness([FromBody] CreateBusinessProfileRM createBusinessProfileRM)
        {
            var response = await _businessService.CreateBusinessAsync(createBusinessProfileRM);
            return CreateReturn(response);
        }

        // BusinessOwner yalnızca kendi işletmesini güncelleyebilir, Admin her türlü güncellemeyi yapabilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateBusiness([FromBody] UpdateBusinessProfileRM updateBusinessProfileRM)
        {
            var response = await _businessService.UpdateBusinessAsync(updateBusinessProfileRM);
            return CreateReturn(response);
        }

        // Yalnızca Admin işletmeleri silebilir
        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{businessProfileId}")]
        public async Task<IActionResult> DeleteBusiness(int businessProfileId)
        {
            var response = await _businessService.DeleteBusinessAsync(businessProfileId);
            return CreateReturn(response);
        }

        // Beğenme Sayısı Artırma: Yalnızca User ve SalesRepresentative, BusinessOwner ve Admin bu sayıyı artırmaz
        [Authorize(Roles = "User, SalesRepresentative")]
        [HttpPost("increase-like/{businessProfileId}")]
        public async Task<IActionResult> IncreaseBusinessLikeCount(int businessProfileId)
        {
            var response = await _businessService.IncreaseBusinessLikeCountAsync(businessProfileId);
            return CreateReturn(response);
        }

        // Tıklama Sayısı Artırma: Yalnızca User ve SalesRepresentative, BusinessOwner ve Admin bu sayıyı artırmaz
        [Authorize(Roles = "User, SalesRepresentative")]
        [HttpPost("increase-click/{businessProfileId}")]
        public async Task<IActionResult> IncreaseBusinessClickCount(int businessProfileId)
        {
            var response = await _businessService.IncreaseBusinessClickCountAsync(businessProfileId);
            return CreateReturn(response);
        }

        // Görüntülenme Sayısı Artırma: Yalnızca User ve SalesRepresentative, BusinessOwner ve Admin bu sayıyı artırmaz
        [Authorize(Roles = "User, SalesRepresentative")]
        [HttpPost("increase-view/{businessProfileId}")]
        public async Task<IActionResult> IncreaseBusinessViewCount(int businessProfileId)
        {
            var response = await _businessService.IncreaseBusinessViewCountAsync(businessProfileId);
            return CreateReturn(response);
        }

        // BusinessOwner ve Admin işletme hizmetlerini yönetebilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpGet("service/{serviceId}")]
        public async Task<IActionResult> GetServiceById(int serviceId)
        {
            var response = await _businessService.GetServiceByIdAsync(serviceId);
            return CreateReturn(response);
        }

        // Admin ve BusinessOwner tüm hizmetleri görebilir, SalesRepresentative de erişebilir
        [Authorize(Roles = "Admin, BusinessOwner, SalesRepresentative")]
        [HttpGet("services")]
        public async Task<IActionResult> GetAllServices()
        {
            var response = await _businessService.GetAllServicesAsync();
            return CreateReturn(response);
        }

        // Admin ve BusinessOwner kendi işletmelerine ait hizmetleri görebilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpGet("business/{businessProfileId}/services")]
        public async Task<IActionResult> GetServicesByBusiness(int businessProfileId)
        {
            var response = await _businessService.GetServicesByBusinessAsync(businessProfileId);
            return CreateReturn(response);
        }

        // Admin BusinessService oluşturabilir, BusinessOwner kendi hizmetini oluşturabilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpPost("service/create")]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceRM createServiceRM)
        {
            var response = await _businessService.CreateServiceAsync(createServiceRM);
            return CreateReturn(response);
        }

        // Admin ve BusinessOwner hizmet güncelleyebilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpPut("service/update")]
        public async Task<IActionResult> UpdateService([FromBody] UpdateServiceRM updateServiceRM)
        {
            var response = await _businessService.UpdateServiceAsync(updateServiceRM);
            return CreateReturn(response);
        }

        // Admin ve BusinessOwner hizmet silebilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpDelete("service/delete/{serviceId}")]
        public async Task<IActionResult> DeleteService(int serviceId)
        {
            var response = await _businessService.DeleteServiceAsync(serviceId);
            return CreateReturn(response);
        }

        // Admin ve BusinessOwner işletme profilini özelleştirebilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpPost("customize-profile")]
        public async Task<IActionResult> CustomizeBusinessProfile([FromBody] UpdateBusinessProfileCustomizationRM updateBusinessProfileCustomizationRM)
        {
            var response = await _businessService.CustomizeBusinessProfileAsync(updateBusinessProfileCustomizationRM);
            return CreateReturn(response);
        }

        // Admin ve BusinessOwner işletme etiketlerini yönetebilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpPost("add-business-tag")]
        public async Task<IActionResult> AddBusinessTag([FromBody] CreateBusinessProfileTagRM createBusinessProfileTagRM)
        {
            var response = await _businessService.AddBusinessTagAsync(createBusinessProfileTagRM);
            return CreateReturn(response);
        }

        // Admin ve BusinessOwner işletme etiketlerini kaldırabilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpPost("remove-business-tag")]
        public async Task<IActionResult> RemoveBusinessTag([FromBody] UpdateBusinessProfileTagRM updateBusinessProfileTagRM)
        {
            var response = await _businessService.RemoveBusinessTagAsync(updateBusinessProfileTagRM);
            return CreateReturn(response);
        }
    }


}
