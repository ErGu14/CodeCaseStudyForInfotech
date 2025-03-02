using Commercium.Shared.Enums;
using CommerciumWeb.Models;

namespace CommerciumWeb.Interfaces
{
    public interface IActivityLogService
    {
        Task<ReturnModel<ActivityLogModel>> GetActivityByIdAsync(int activityLogId);
        Task<ReturnModel<IEnumerable<ActivityLogModel>>> GetUserActivitiesAsync(string userId);
        Task<ReturnModel<IEnumerable<ActivityLogModel>>> GetActivitiesByEntityAsync(int entityId, EntityType entityType);
        Task<ReturnModel<IEnumerable<ActivityLogModel>>> GetRecentUserActivitiesAsync(string userId, int count);
        Task<ReturnModel<IEnumerable<ActivityLogModel>>> GetActivitiesByTypeAsync(ActivityType activityType);
        Task<ReturnModel<IEnumerable<ActivityLogModel>>> GetActivitiesByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<ReturnModel<string>> CreateActivityAsync(CreateActivityLogModel createActivityLogModel);
    }

}
