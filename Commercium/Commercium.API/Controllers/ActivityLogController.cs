using Commercium.Service.Interfaces;
using Commercium.Shared.Enums;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.ActivityLogRMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commercium.API.Controllers
{
    [ApiController]
    [Route("api/activity-log")]
    public class ActivityLogController : CustomizingController
    {
        private readonly IActivityLogService _activityLogService;

        public ActivityLogController(IActivityLogService activityLogService)
        {
            _activityLogService = activityLogService;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateActivity([FromBody] CreateActivityLogRM createActivityLogRM)
        {
            var response = await _activityLogService.CreateActivityAsync(createActivityLogRM);
            return CreateReturn(response);
        }

        [Authorize]
        [HttpGet("{activityLogId}")]
        public async Task<IActionResult> GetActivityById(int activityLogId)
        {
            var response = await _activityLogService.GetActivityByIdAsync(activityLogId);
            return CreateReturn(response);
        }

        [Authorize]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserActivities(string userId)
        {
            var response = await _activityLogService.GetUserActivitiesAsync(userId);
            return CreateReturn(response);
        }

        [Authorize]
        [HttpGet("entity/{entityId}/{entityType}")]
        public async Task<IActionResult> GetActivitiesByEntity(int entityId, EntityType entityType)
        {
            var response = await _activityLogService.GetActivitiesByEntityAsync(entityId, entityType);
            return CreateReturn(response);
        }

        [Authorize]
        [HttpGet("user/{userId}/recent/{count}")]
        public async Task<IActionResult> GetRecentUserActivities(string userId, int count)
        {
            var response = await _activityLogService.GetRecentUserActivitiesAsync(userId, count);
            return CreateReturn(response);
        }

        [Authorize]
        [HttpGet("type/{activityType}")]
        public async Task<IActionResult> GetActivitiesByType(ActivityType activityType)
        {
            var response = await _activityLogService.GetActivitiesByTypeAsync(activityType);
            return CreateReturn(response);
        }

        [Authorize]
        [HttpGet("date-range")]
        public async Task<IActionResult> GetActivitiesByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var response = await _activityLogService.GetActivitiesByDateRangeAsync(startDate, endDate);
            return CreateReturn(response);
        }
    }

}
