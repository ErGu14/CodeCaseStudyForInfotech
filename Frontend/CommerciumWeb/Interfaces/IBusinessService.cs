using CommerciumWeb.Models;

namespace CommerciumWeb.Interfaces
{
    public interface IBusinessService
    {
        Task<ReturnModel<BusinessProfileModel>> GetBusinessByIdAsync(int businessProfileId);
        Task<ReturnModel<IEnumerable<BusinessProfileModel>>> GetAllBusinessesAsync();
        Task<ReturnModel<string>> CreateBusinessAsync(BusinessProfileModel createBusinessProfileModel);
        Task<ReturnModel<string>> UpdateBusinessAsync(BusinessProfileModel updateBusinessProfileModel);
        Task<ReturnModel<string>> DeleteBusinessAsync(int businessProfileId);
        Task<ReturnModel<string>> IncreaseBusinessLikeCountAsync(int businessProfileId);
        Task<ReturnModel<string>> IncreaseBusinessClickCountAsync(int businessProfileId);
        Task<ReturnModel<string>> IncreaseBusinessViewCountAsync(int businessProfileId);
        Task<ReturnModel<BusinessServiceModel>> GetServiceByIdAsync(int serviceId);
        Task<ReturnModel<IEnumerable<BusinessServiceModel>>> GetAllServicesAsync();
        Task<ReturnModel<IEnumerable<BusinessServiceModel>>> GetServicesByBusinessAsync(int businessProfileId);
        Task<ReturnModel<string>> CreateServiceAsync(BusinessServiceModel createServiceModel);
        Task<ReturnModel<string>> UpdateServiceAsync(BusinessServiceModel updateServiceModel);
        Task<ReturnModel<string>> DeleteServiceAsync(int serviceId);
        Task<ReturnModel<string>> CustomizeBusinessProfileAsync(BusinessProfileCustomizationModel updateBusinessProfileCustomizationModel);
        Task<ReturnModel<string>> AddBusinessTagAsync(BusinessProfileCustomizationModel createBusinessProfileTagModel);
        Task<ReturnModel<string>> RemoveBusinessTagAsync(BusinessProfileCustomizationModel updateBusinessProfileTagModel);
    }
}
