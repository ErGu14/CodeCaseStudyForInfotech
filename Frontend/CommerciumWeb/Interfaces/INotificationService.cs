using CommerciumWeb.Models;

namespace CommerciumWeb.Interfaces
{
    public interface INotificationService
    {
        Task<ReturnModel<string>> CreateNotificationAsync(NotificationModel createNotificationModel);
        Task<ReturnModel<IEnumerable<NotificationModel>>> GetUserNotificationsAsync(string userId);
        Task<ReturnModel<NotificationModel>> GetNotificationByIdAsync(int notificationId);
        Task<ReturnModel<string>> DeleteNotificationAsync(int notificationId);
        Task<ReturnModel<string>> ClearUserNotificationsAsync(string userId);
        Task<ReturnModel<IEnumerable<NotificationModel>>> GetUnreadNotificationsAsync(string userId);
        Task<ReturnModel<string>> MarkNotificationAsReadAsync(int notificationId);
        Task<ReturnModel<string>> MarkAllNotificationsAsReadAsync(string userId);
        Task<ReturnModel<IEnumerable<NotificationModel>>> GetLatestNotificationsAsync(string userId, int count);
        Task<ReturnModel<int>> GetUnreadNotificationCountAsync(string userId);
    }

}
