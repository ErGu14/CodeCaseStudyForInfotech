using AutoMapper;
using Commercium.Data.Interfaces;
using Commercium.Entity.User;
using Commercium.Service.Interfaces;
using Commercium.Shared.Enums;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.ActivityLogRMs;

public class ActivityLogService : IActivityLogService
{
    private readonly IGenericManager<ActivityLog> _activityLogManager;
    private readonly ITransactionManager _transactionManager;
    private readonly IMapper _mapper;

    public ActivityLogService(IGenericManager<ActivityLog> activityLogManager, ITransactionManager transactionManager, IMapper mapper)
    {
        _activityLogManager = activityLogManager;
        _transactionManager = transactionManager;
        _mapper = mapper;
    }

    // Yeni aktivite kaydetme
    public async Task<ReturnRM<string>> CreateActivityAsync(CreateActivityLogRM createActivityLogRM)
    {
        var activityLog = _mapper.Map<ActivityLog>(createActivityLogRM);

        await _activityLogManager.AddAsync(activityLog);
        var save = await _transactionManager.SaveAsync();

        if (save <= 0)
        {
            return ReturnRM<string>.Fail("Aktivite kaydedilemedi.", 500);
        }

        return ReturnRM<string>.Success("Aktivite başarıyla kaydedildi.", 201);
    }

    // Tek bir aktiviteyi ID'ye göre getirme
    public async Task<ReturnRM<ActivityLogRM>> GetActivityByIdAsync(int activityLogId)
    {
        var activityLog = await _activityLogManager.GetAsync(x => x.ActivityLogId == activityLogId);

        if (activityLog == null)
        {
            return ReturnRM<ActivityLogRM>.Fail("Aktivite bulunamadı.", 404);
        }

        var activityLogRM = _mapper.Map<ActivityLogRM>(activityLog);
        return ReturnRM<ActivityLogRM>.Success(activityLogRM, 200);
    }

    // Belirli bir kullanıcının aktivitelerini getirme
    public async Task<ReturnRM<IEnumerable<ActivityLogRM>>> GetUserActivitiesAsync(string userId)
    {
        var activityLogs = await _activityLogManager.GetAllAsync(x => x.UserId == userId);

        if (activityLogs == null || !activityLogs.Any())
        {
            return ReturnRM<IEnumerable<ActivityLogRM>>.Fail("Kullanıcının aktivitesi bulunamadı.", 404);
        }

        var activityLogsRM = _mapper.Map<IEnumerable<ActivityLogRM>>(activityLogs);
        return ReturnRM<IEnumerable<ActivityLogRM>>.Success(activityLogsRM, 200);
    }

    // Belirli bir ürün veya hizmet için aktiviteleri getirme
    public async Task<ReturnRM<IEnumerable<ActivityLogRM>>> GetActivitiesByEntityAsync(int entityId, EntityType entityType)
    {
        var activityLogs = await _activityLogManager.GetAllAsync(x => x.EntityId == entityId && x.EntityType == entityType);

        if (activityLogs == null || !activityLogs.Any())
        {
            return ReturnRM<IEnumerable<ActivityLogRM>>.Fail("Aktivite bulunamadı.", 404);
        }

        var activityLogsRM = _mapper.Map<IEnumerable<ActivityLogRM>>(activityLogs);
        return ReturnRM<IEnumerable<ActivityLogRM>>.Success(activityLogsRM, 200);
    }

    // Kullanıcının son X aktivitesini getirme
    public async Task<ReturnRM<IEnumerable<ActivityLogRM>>> GetRecentUserActivitiesAsync(string userId, int count)
    {
        var activityLogs = await _activityLogManager.GetAllAsync(
            x => x.UserId == userId,
            values: query => query.OrderByDescending(x => x.ActivityDate)
        );

        var recentActivities = activityLogs.Take(count).ToList();

        if (!recentActivities.Any())
        {
            return ReturnRM<IEnumerable<ActivityLogRM>>.Fail("Aktivite bulunamadı.", 404);
        }

        var recentActivitiesRM = _mapper.Map<IEnumerable<ActivityLogRM>>(recentActivities);
        return ReturnRM<IEnumerable<ActivityLogRM>>.Success(recentActivitiesRM, 200);
    }

    // Belirli bir aktivite türüne göre filtreleme
    public async Task<ReturnRM<IEnumerable<ActivityLogRM>>> GetActivitiesByTypeAsync(ActivityType activityType)
    {
        var activityLogs = await _activityLogManager.GetAllAsync(x => x.ActivityType == activityType);

        if (activityLogs == null || !activityLogs.Any())
        {
            return ReturnRM<IEnumerable<ActivityLogRM>>.Fail("Aktivite bulunamadı.", 404);
        }

        var activityLogsRM = _mapper.Map<IEnumerable<ActivityLogRM>>(activityLogs);
        return ReturnRM<IEnumerable<ActivityLogRM>>.Success(activityLogsRM, 200);
    }

    // Belirli bir tarih aralığında aktiviteleri getirme
    public async Task<ReturnRM<IEnumerable<ActivityLogRM>>> GetActivitiesByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        var activityLogs = await _activityLogManager.GetAllAsync(x => x.ActivityDate >= startDate && x.ActivityDate <= endDate);

        if (activityLogs == null || !activityLogs.Any())
        {
            return ReturnRM<IEnumerable<ActivityLogRM>>.Fail("Aktivite bulunamadı.", 404);
        }

        var activityLogsRM = _mapper.Map<IEnumerable<ActivityLogRM>>(activityLogs);
        return ReturnRM<IEnumerable<ActivityLogRM>>.Success(activityLogsRM, 200);
    }
}
