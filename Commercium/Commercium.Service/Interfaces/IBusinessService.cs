using Commercium.Shared.Businness.BusinessProfileCustomizationRMs;
using Commercium.Shared.Businness.BusinessProfileRMs;
using Commercium.Shared.Businness.BusinessProfileTagRMs;
using Commercium.Shared.Businness.ServiceRMs;
using Commercium.Shared.ReturnRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Interfaces
{
    public interface IBusinessService
    {
        //  İşletme Yönetimi
        Task<ReturnRM<BusinessProfileRM>> GetBusinessByIdAsync(int businessProfileId);
        Task<ReturnRM<IEnumerable<BusinessProfileRM>>> GetAllBusinessesAsync();
        Task<ReturnRM<string>> CreateBusinessAsync(CreateBusinessProfileRM createBusinessProfileRM);
        Task<ReturnRM<string>> UpdateBusinessAsync(UpdateBusinessProfileRM updateBusinessProfileRM);
        Task<ReturnRM<string>> DeleteBusinessAsync(int businessProfileId);

        //  İşletme Beğeni, Tıklanma & Görüntülenme Sayısı Yönetimi
        Task<ReturnRM<string>> IncreaseBusinessLikeCountAsync(int businessProfileId);
        Task<ReturnRM<string>> IncreaseBusinessClickCountAsync(int businessProfileId);
        Task<ReturnRM<string>> IncreaseBusinessViewCountAsync(int businessProfileId);

        //  İşletme Hizmetleri (Service Yönetimi)
        Task<ReturnRM<ServiceRM>> GetServiceByIdAsync(int serviceId);
        Task<ReturnRM<IEnumerable<ServiceRM>>> GetAllServicesAsync();
        Task<ReturnRM<IEnumerable<ServiceRM>>> GetServicesByBusinessAsync(int businessProfileId);
        Task<ReturnRM<string>> CreateServiceAsync(CreateServiceRM createServiceRM);
        Task<ReturnRM<string>> UpdateServiceAsync(UpdateServiceRM updateServiceRM);
        Task<ReturnRM<string>> DeleteServiceAsync(int serviceId);

        // İşletme Profili Özelleştirme
        Task<ReturnRM<string>> CustomizeBusinessProfileAsync(UpdateBusinessProfileCustomizationRM updateBusinessProfileCustomizationRM);

        //  İşletme Etiket Yönetimi
        Task<ReturnRM<string>> AddBusinessTagAsync(CreateBusinessProfileTagRM createBusinessProfileTagRM);
        Task<ReturnRM<string>> RemoveBusinessTagAsync(UpdateBusinessProfileTagRM updateBusinessProfileTagRM);
    }


}
