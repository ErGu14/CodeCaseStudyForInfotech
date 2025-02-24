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

namespace Commercium.Service.Interfaces
{
    public interface ITagService
    {
        //  Etiket Yönetimi
        Task<ReturnRM<TagRM>> GetTagByIdAsync(int tagId);
        Task<ReturnRM<IEnumerable<TagRM>>> GetAllTagsAsync();
        Task<ReturnRM<string>> CreateTagAsync(CreateTagRM createTagRM);
        Task<ReturnRM<string>> UpdateTagAsync(UpdateTagRM updateTagRM);
        Task<ReturnRM<string>> DeleteTagAsync(int tagId);

        //  Etiket ile Bağlantılı Varlıkları Getirme
        Task<ReturnRM<IEnumerable<ProductRM>>> GetProductsByTagAsync(int tagId);
        Task<ReturnRM<IEnumerable<ServiceRM>>> GetServicesByTagAsync(int tagId);
        Task<ReturnRM<IEnumerable<BusinessProfileRM>>> GetBusinessesByTagAsync(int tagId);

        //  Ekstra Fonksiyonlar
        Task<ReturnRM<IEnumerable<TagRM>>> GetTopTagsAsync(int count); // En popüler etiketleri getir
       
    }

}
