using Commercium.Shared.Enums;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.ActivityLogRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Interfaces
{
    public interface IActivityLogService
    {
        // Yeni aktivite kaydetme
        Task<ReturnRM<string>> CreateActivityAsync(CreateActivityLogRM createActivityLogRM);

        //  Tek bir aktiviteyi ID'ye göre getirme
        Task<ReturnRM<ActivityLogRM>> GetActivityByIdAsync(int activityLogId);

        //  Belirli bir kullanıcının aktivitelerini getirme
        Task<ReturnRM<IEnumerable<ActivityLogRM>>> GetUserActivitiesAsync(string userId);

        //  Belirli bir ürün veya hizmet için aktiviteleri getirme
        Task<ReturnRM<IEnumerable<ActivityLogRM>>> GetActivitiesByEntityAsync(int entityId, EntityType entityType);

        //  Kullanıcının son aktivitesini getirme
        Task<ReturnRM<IEnumerable<ActivityLogRM>>> GetRecentUserActivitiesAsync(string userId, int count);

        //  Belirli bir aktivite türüne göre filtreleme
        Task<ReturnRM<IEnumerable<ActivityLogRM>>> GetActivitiesByTypeAsync(ActivityType activityType);

        //  Belirli bir tarih aralığında aktiviteleri getirme
        Task<ReturnRM<IEnumerable<ActivityLogRM>>> GetActivitiesByDateRangeAsync(DateTime startDate, DateTime endDate);
    }


}
