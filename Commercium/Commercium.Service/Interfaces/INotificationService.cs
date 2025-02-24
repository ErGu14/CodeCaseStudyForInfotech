using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.NotificationRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Interfaces
{
    public interface INotificationService
    {
        // Bildirim Yönetimi
        Task<ReturnRM<string>> CreateNotificationAsync(CreateNotificationRM createNotificationRM);
        Task<ReturnRM<IEnumerable<NotificationRM>>> GetUserNotificationsAsync(string userId);
        Task<ReturnRM<NotificationRM>> GetNotificationByIdAsync(int notificationId);
        Task<ReturnRM<string>> DeleteNotificationAsync(int notificationId);
        Task<ReturnRM<string>> ClearUserNotificationsAsync(string userId);

        // Okunmamış Bildirim Yönetimi
        Task<ReturnRM<IEnumerable<NotificationRM>>> GetUnreadNotificationsAsync(string userId);
        Task<ReturnRM<string>> MarkNotificationAsReadAsync(int notificationId);
        Task<ReturnRM<string>> MarkAllNotificationsAsReadAsync(string userId);

        // Ekstra Fonksiyonlar
        Task<ReturnRM<IEnumerable<NotificationRM>>> GetLatestNotificationsAsync(string userId, int count);
        Task<ReturnRM<int>> GetUnreadNotificationCountAsync(string userId);
    }

}
