using AutoMapper;
using Commercium.Data.Interfaces;
using Commercium.Entity.Businness;
using Commercium.Entity.Tags;
using Commercium.Entity;
using Commercium.Service.Interfaces;
using Commercium.Shared.Businness.BusinessProfileRMs;
using Commercium.Shared.Businness.ServiceRMs;
using Commercium.Shared.ProductRMs;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Tags.TagRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Commercium.Service.Classes
{
    public class TagService : ITagService
    {
        private readonly IGenericManager<Tag> _tagManager;
        private readonly IGenericManager<Product> _productManager;
        private readonly IGenericManager<Entity.Businness.Service> _serviceManager;
        private readonly IGenericManager<BusinessProfile> _businessProfileManager;
        private readonly ITransactionManager _transactionManager;
        private readonly IMapper _mapper;

        public TagService(
            IGenericManager<Tag> tagManager,
            IGenericManager<Product> productManager,
            IGenericManager<Entity.Businness.Service> serviceManager,
            IGenericManager<BusinessProfile> businessProfileManager,
            ITransactionManager transactionManager,
            IMapper mapper)
        {
            _tagManager = tagManager;
            _productManager = productManager;
            _serviceManager = serviceManager;
            _businessProfileManager = businessProfileManager;
            _transactionManager = transactionManager;
            _mapper = mapper;
        }

        //  Etiketi ID'ye göre getirme
        public async Task<ReturnRM<TagRM>> GetTagByIdAsync(int tagId)
        {
            var tag = await _tagManager.GetByIdAsync(tagId);

            if (tag == null)
            {
                return ReturnRM<TagRM>.Fail("Etiket bulunamadı.", 404);
            }

            var tagRM = _mapper.Map<TagRM>(tag);
            return ReturnRM<TagRM>.Success(tagRM, 200);
        }

        //  Tüm etiketleri getirme
        public async Task<ReturnRM<IEnumerable<TagRM>>> GetAllTagsAsync()
        {
            var tags = await _tagManager.GetAllAsync();

            if (tags == null || !tags.Any())
            {
                return ReturnRM<IEnumerable<TagRM>>.Fail("Etiket bulunamadı.", 404);
            }

            var tagRMs = _mapper.Map<IEnumerable<TagRM>>(tags);
            return ReturnRM<IEnumerable<TagRM>>.Success(tagRMs, 200);
        }

        //  Etiket oluşturma
        public async Task<ReturnRM<string>> CreateTagAsync(CreateTagRM createTagRM)
        {
            var tag = _mapper.Map<Tag>(createTagRM);

            // Etiketi kaydet
            await _tagManager.AddAsync(tag);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Etiket oluşturulamadı.", 500);
            }

            return ReturnRM<string>.Success("Etiket başarıyla oluşturuldu.", 201);
        }

        //  Etiket güncelleme
        public async Task<ReturnRM<string>> UpdateTagAsync(UpdateTagRM updateTagRM)
        {
            var tag = await _tagManager.GetByIdAsync(updateTagRM.TagId);

            if (tag == null)
            {
                return ReturnRM<string>.Fail("Etiket bulunamadı.", 404);
            }

            _mapper.Map(updateTagRM, tag);
            _tagManager.Update(tag);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Etiket güncellenemedi.", 500);
            }

            return ReturnRM<string>.Success("Etiket başarıyla güncellendi.", 200);
        }

        //  Etiket silme
        public async Task<ReturnRM<string>> DeleteTagAsync(int tagId)
        {
            var tag = await _tagManager.GetByIdAsync(tagId);

            if (tag == null)
            {
                return ReturnRM<string>.Fail("Etiket bulunamadı.", 404);
            }

            _tagManager.Delete(tag);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Etiket silinemedi.", 500);
            }

            return ReturnRM<string>.Success("Etiket başarıyla silindi.", 200);
        }

        //  Etiket ile bağlantılı ürünleri getirme
        public async Task<ReturnRM<IEnumerable<ProductRM>>> GetProductsByTagAsync(int tagId)
        {
            var products = await _productManager.GetAllAsync(
                x => x.ProductTags.Any(pt => pt.TagId == tagId),
                includes: x => x.Include(p => p.ProductCategories).Include(p => p.ProductTags));

            if (products == null || !products.Any())
            {
                return ReturnRM<IEnumerable<ProductRM>>.Fail("Etiketle ilişkili ürün bulunamadı.", 404);
            }

            var productRMs = _mapper.Map<IEnumerable<ProductRM>>(products);
            return ReturnRM<IEnumerable<ProductRM>>.Success(productRMs, 200);
        }

        //  Etiket ile bağlantılı hizmetleri getirme
        public async Task<ReturnRM<IEnumerable<ServiceRM>>> GetServicesByTagAsync(int tagId)
        {
            var services = await _serviceManager.GetAllAsync(
                x => x.ServiceTags.Any(st => st.TagId == tagId));

            if (services == null || !services.Any())
            {
                return ReturnRM<IEnumerable<ServiceRM>>.Fail("Etiketle ilişkili hizmet bulunamadı.", 404);
            }

            var serviceRMs = _mapper.Map<IEnumerable<ServiceRM>>(services);
            return ReturnRM<IEnumerable<ServiceRM>>.Success(serviceRMs, 200);
        }

        //  Etiket ile bağlantılı işletmeleri getirme
        public async Task<ReturnRM<IEnumerable<BusinessProfileRM>>> GetBusinessesByTagAsync(int tagId)
        {
            var businesses = await _businessProfileManager.GetAllAsync(
                x => x.BusinessProfileTags.Any(bt => bt.TagId == tagId));

            if (businesses == null || !businesses.Any())
            {
                return ReturnRM<IEnumerable<BusinessProfileRM>>.Fail("Etiketle ilişkili işletme bulunamadı.", 404);
            }

            var businessProfileRMs = _mapper.Map<IEnumerable<BusinessProfileRM>>(businesses);
            return ReturnRM<IEnumerable<BusinessProfileRM>>.Success(businessProfileRMs, 200);
        }

        //  En popüler etiketleri getirme
        public async Task<ReturnRM<IEnumerable<TagRM>>> GetTopTagsAsync(int count)
        {
            var tags = await _tagManager.GetTopAsync(count, orderBy: q => q.OrderByDescending(t => t.Name));

            if (tags == null || !tags.Any())
            {
                return ReturnRM<IEnumerable<TagRM>>.Fail("Popüler etiketler bulunamadı.", 404);
            }

            var tagRMs = _mapper.Map<IEnumerable<TagRM>>(tags);
            return ReturnRM<IEnumerable<TagRM>>.Success(tagRMs, 200);
        }

        
    }

}
