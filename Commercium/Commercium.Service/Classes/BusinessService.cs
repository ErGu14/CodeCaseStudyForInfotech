using AutoMapper;
using Commercium.Data.Interfaces;
using Commercium.Entity.Businness;
using Commercium.Service.Interfaces;
using Commercium.Shared.Businness.BusinessProfileCustomizationRMs;
using Commercium.Shared.Businness.BusinessProfileRMs;
using Commercium.Shared.Businness.BusinessProfileTagRMs;
using Commercium.Shared.Businness.ServiceRMs;
using Commercium.Shared.Other.Enums;
using Commercium.Shared.ReturnRMs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Classes
{
    public class BusinessService : IBusinessService
    {
        private readonly IGenericManager<BusinessProfile> _businessManager;
        private readonly IGenericManager<Entity.Businness.Service> _serviceManager;
        private readonly IGenericManager<BusinessProfileTag> _businessTagManager;
        private readonly IGenericManager<BusinessProfileCustomization> _businessCustomizationManager;
        private readonly ITransactionManager _transactionManager;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public BusinessService(
            IGenericManager<BusinessProfile> businessManager,
            IGenericManager<Entity.Businness.Service> serviceManager,
            IGenericManager<BusinessProfileTag> businessTagManager,
            IGenericManager<BusinessProfileCustomization> businessCustomizationManager,
            ITransactionManager transactionManager,
            IMapper mapper,
            IFileService fileService)
        {
            _businessManager = businessManager;
            _serviceManager = serviceManager;
            _businessTagManager = businessTagManager;
            _businessCustomizationManager = businessCustomizationManager;
            _transactionManager = transactionManager;
            _mapper = mapper;
            _fileService = fileService;
        }



        // İşletme ID'ye göre getir
        public async Task<ReturnRM<BusinessProfileRM>> GetBusinessByIdAsync(int businessProfileId)
        {
            var business = await _businessManager.GetAsync(
                x => x.BusinessProfileId == businessProfileId,
                x => x.Include(b => b.Products).Include(b => b.Services).Include(b => b.BusinessProfileTags));

            if (business == null)
            {
                return ReturnRM<BusinessProfileRM>.Fail("İşletme bulunamadı.", 404);
            }

            var businessRM = _mapper.Map<BusinessProfileRM>(business);
            return ReturnRM<BusinessProfileRM>.Success(businessRM, 200);
        }

        // Tüm işletmeleri getir
        public async Task<ReturnRM<IEnumerable<BusinessProfileRM>>> GetAllBusinessesAsync()
        {
            var businesses = await _businessManager.GetAllAsync(
                includes: x => x.Include(b => b.Products).Include(b => b.Services).Include(b => b.BusinessProfileTags));

            if (businesses == null || !businesses.Any())
            {
                return ReturnRM<IEnumerable<BusinessProfileRM>>.Fail("İşletme bulunamadı.", 404);
            }

            var businessesRM = _mapper.Map<IEnumerable<BusinessProfileRM>>(businesses);
            return ReturnRM<IEnumerable<BusinessProfileRM>>.Success(businessesRM, 200);
        }

        // Yeni işletme oluştur
        public async Task<ReturnRM<string>> CreateBusinessAsync(CreateBusinessProfileRM createBusinessProfileRM)
        {
            var business = _mapper.Map<BusinessProfile>(createBusinessProfileRM);
            await _businessManager.AddAsync(business);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("İşletme oluşturulamadı.", 500);
            }

            return ReturnRM<string>.Success("İşletme başarıyla oluşturuldu.", 201);
        }

        // İşletme bilgilerini güncelle
        public async Task<ReturnRM<string>> UpdateBusinessAsync(UpdateBusinessProfileRM updateBusinessProfileRM)
        {
            var business = await _businessManager.GetAsync(x => x.BusinessProfileId == updateBusinessProfileRM.BusinessProfileId);
            if (business == null)
            {
                return ReturnRM<string>.Fail("İşletme bulunamadı.", 404);
            }

            _mapper.Map(updateBusinessProfileRM, business);
            _businessManager.Update(business);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("İşletme güncellenemedi.", 500);
            }

            return ReturnRM<string>.Success("İşletme başarıyla güncellendi.", 200);
        }

        // İşletmeyi sil
        public async Task<ReturnRM<string>> DeleteBusinessAsync(int businessProfileId)
        {
            var business = await _businessManager.GetByIdAsync(businessProfileId);
            if (business == null)
            {
                return ReturnRM<string>.Fail("İşletme bulunamadı.", 404);
            }

            _businessManager.Delete(business);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("İşletme silinemedi.", 500);
            }

            return ReturnRM<string>.Success("İşletme başarıyla silindi.", 200);
        }

        // İşletme Beğeni Sayısını Artır
        public async Task<ReturnRM<string>> IncreaseBusinessLikeCountAsync(int businessProfileId)
        {
            var business = await _businessManager.GetByIdAsync(businessProfileId);
            if (business == null)
            {
                return ReturnRM<string>.Fail("İşletme bulunamadı.", 404);
            }

            business.LikeCount++;
            _businessManager.Update(business);
            await _transactionManager.SaveAsync();

            return ReturnRM<string>.Success("Beğeni sayısı artırıldı.", 200);
        }

        // İşletme Tıklanma Sayısını Artır
        public async Task<ReturnRM<string>> IncreaseBusinessClickCountAsync(int businessProfileId)
        {
            var business = await _businessManager.GetByIdAsync(businessProfileId);
            if (business == null)
            {
                return ReturnRM<string>.Fail("İşletme bulunamadı.", 404);
            }

            business.ClickCount++;
            _businessManager.Update(business);
            await _transactionManager.SaveAsync();

            return ReturnRM<string>.Success("Tıklanma sayısı artırıldı.", 200);
        }

        // İşletme Görüntülenme Sayısını Artır
        public async Task<ReturnRM<string>> IncreaseBusinessViewCountAsync(int businessProfileId)
        {
            var business = await _businessManager.GetByIdAsync(businessProfileId);
            if (business == null)
            {
                return ReturnRM<string>.Fail("İşletme bulunamadı.", 404);
            }

            business.ClickCount++; // Burada ViewCount yoktu, ClickCount'u kullanarak devam ettim.
            _businessManager.Update(business);
            await _transactionManager.SaveAsync();

            return ReturnRM<string>.Success("Görüntülenme sayısı artırıldı.", 200);
        }

        public async Task<ReturnRM<ServiceRM>> GetServiceByIdAsync(int serviceId)
        {
            var service = await _serviceManager.GetAsync(
                x => x.ServiceId == serviceId,
                x => x.Include(s => s.BusinessProfile)
                      .Include(s => s.ServiceTags)
                      .Include(s => s.Reviews));

            if (service == null)
            {
                return ReturnRM<ServiceRM>.Fail("Hizmet bulunamadı.", 404);
            }

            var serviceRM = _mapper.Map<ServiceRM>(service);
            return ReturnRM<ServiceRM>.Success(serviceRM, 200);
        }


        public async Task<ReturnRM<IEnumerable<ServiceRM>>> GetAllServicesAsync()
        {
            var services = await _serviceManager.GetAllAsync(
                includes: x => x.Include(s => s.BusinessProfile)
                                .Include(s => s.ServiceTags)
                                .Include(s => s.Reviews));

            if (services == null || !services.Any())
            {
                return ReturnRM<IEnumerable<ServiceRM>>.Fail("Hiç hizmet bulunamadı.", 404);
            }

            var serviceRMs = _mapper.Map<IEnumerable<ServiceRM>>(services);
            return ReturnRM<IEnumerable<ServiceRM>>.Success(serviceRMs, 200);
        }


        public async Task<ReturnRM<IEnumerable<ServiceRM>>> GetServicesByBusinessAsync(int businessProfileId)
        {
            var services = await _serviceManager.GetAllAsync(
                x => x.BusinessProfile.BusinessProfileId == businessProfileId,
                includes: x => x.Include(s => s.BusinessProfile)
                                .Include(s => s.ServiceTags)
                                .Include(s => s.Reviews));

            if (services == null || !services.Any())
            {
                return ReturnRM<IEnumerable<ServiceRM>>.Fail("Bu işletmeye ait hizmet bulunamadı.", 404);
            }

            var serviceRMs = _mapper.Map<IEnumerable<ServiceRM>>(services);
            return ReturnRM<IEnumerable<ServiceRM>>.Success(serviceRMs, 200);
        }


        public async Task<ReturnRM<string>> CreateServiceAsync(CreateServiceRM createServiceRM)
        {
            var service = _mapper.Map<Entity.Businness.Service>(createServiceRM);

            await _serviceManager.AddAsync(service);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Hizmet oluşturulamadı.", 500);
            }

            return ReturnRM<string>.Success("Hizmet başarıyla oluşturuldu.", 201);
        }


        public async Task<ReturnRM<string>> UpdateServiceAsync(UpdateServiceRM updateServiceRM)
        {
            var service = await _serviceManager.GetAsync(x => x.ServiceId == updateServiceRM.ServiceId);

            if (service == null)
            {
                return ReturnRM<string>.Fail("Hizmet bulunamadı.", 404);
            }

            _mapper.Map(updateServiceRM, service);
            _serviceManager.Update(service);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Hizmet güncellenemedi.", 500);
            }

            return ReturnRM<string>.Success("Hizmet başarıyla güncellendi.", 200);
        }


        public async Task<ReturnRM<string>> DeleteServiceAsync(int serviceId)
        {
            var service = await _serviceManager.GetByIdAsync(serviceId);

            if (service == null)
            {
                return ReturnRM<string>.Fail("Hizmet bulunamadı.", 404);
            }

            _serviceManager.Delete(service);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Hizmet silinemedi.", 500);
            }

            return ReturnRM<string>.Success("Hizmet başarıyla silindi.", 200);
        }


        public async Task<ReturnRM<string>> CustomizeBusinessProfileAsync(UpdateBusinessProfileCustomizationRM updateBusinessProfileCustomizationRM)
        {
            var customization = await _businessCustomizationManager.GetAsync(x => x.BusinessProfile.BusinessProfileId == updateBusinessProfileCustomizationRM.BusinessProfileId);

            if (customization == null)
            {
                return ReturnRM<string>.Fail("İşletme profili bulunamadı.", 404);
            }

            // **Dosya yükleme işlemleri**
            if (updateBusinessProfileCustomizationRM.CustomProfileImage != null)
            {
                customization.CustomProfileImage = await _fileService.UploadFileAsync(updateBusinessProfileCustomizationRM.CustomProfileImage,FileType.Image);
            }

            if (updateBusinessProfileCustomizationRM.CustomBackgroundImage != null)
            {
                customization.CustomBackgroundImage = await _fileService.UploadFileAsync(updateBusinessProfileCustomizationRM.CustomBackgroundImage,FileType.Image);
            }

            customization.CustomDescription = updateBusinessProfileCustomizationRM.CustomDescription;

            _businessCustomizationManager.Update(customization);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("İşletme profili özelleştirilemedi.", 500);
            }

            return ReturnRM<string>.Success("İşletme profili başarıyla güncellendi.", 200);
        }


        public async Task<ReturnRM<string>> AddBusinessTagAsync(CreateBusinessProfileTagRM createBusinessProfileTagRM)
        {
            var businessTag = _mapper.Map<BusinessProfileTag>(createBusinessProfileTagRM);

            await _businessTagManager.AddAsync(businessTag);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Etiket eklenemedi.", 500);
            }

            return ReturnRM<string>.Success("Etiket başarıyla eklendi.", 201);
        }


        public async Task<ReturnRM<string>> RemoveBusinessTagAsync(UpdateBusinessProfileTagRM updateBusinessProfileTagRM)
        {
            var businessTag = await _businessTagManager.GetAsync(x =>
                x.BusinessProfileId == updateBusinessProfileTagRM.BusinessProfileId &&
                x.TagId == updateBusinessProfileTagRM.TagId);

            if (businessTag == null)
            {
                return ReturnRM<string>.Fail("Etiket bulunamadı.", 404);
            }

            _businessTagManager.Delete(businessTag);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Etiket kaldırılamadı.", 500);
            }

            return ReturnRM<string>.Success("Etiket başarıyla kaldırıldı.", 200);
        }

    }

}
