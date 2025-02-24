using AutoMapper;
using Commercium.Data.Interfaces;
using Commercium.Entity.User;
using Commercium.Service.Interfaces;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.NotificationRMs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Classes
{
    public class NotificationService : INotificationService
    {
        private readonly IGenericManager<Notification> _notificationManager;
        private readonly ITransactionManager _transactionManager;
        private readonly IMapper _mapper;

        public NotificationService(
            IGenericManager<Notification> notificationManager,
            ITransactionManager transactionManager,
            IMapper mapper)
        {
            _notificationManager = notificationManager;
            _transactionManager = transactionManager;
            _mapper = mapper;
        }

        //  Bildirim oluşturma
        public async Task<ReturnRM<string>> CreateNotificationAsync(CreateNotificationRM createNotificationRM)
        {
            var notification = _mapper.Map<Notification>(createNotificationRM);

            await _notificationManager.AddAsync(notification);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Bildirim oluşturulamadı.", 500);
            }

            return ReturnRM<string>.Success("Bildirim başarıyla oluşturuldu.", 201);
        }

        //  Kullanıcının bildirimlerini getirme
        public async Task<ReturnRM<IEnumerable<NotificationRM>>> GetUserNotificationsAsync(string userId)
        {
            var notifications = await _notificationManager.GetAllAsync(
                x => x.UserId == userId,
                includes: x => x.Include(n => n.User));

            if (notifications == null || !notifications.Any())
            {
                return ReturnRM<IEnumerable<NotificationRM>>.Fail("Kullanıcının bildirimleri bulunamadı.", 404);
            }

            var notificationRMs = _mapper.Map<IEnumerable<NotificationRM>>(notifications);
            return ReturnRM<IEnumerable<NotificationRM>>.Success(notificationRMs, 200);
        }

        //  Bildirim ID'ye göre getirme
        public async Task<ReturnRM<NotificationRM>> GetNotificationByIdAsync(int notificationId)
        {
            var notification = await _notificationManager.GetByIdAsync(notificationId);

            if (notification == null)
            {
                return ReturnRM<NotificationRM>.Fail("Bildirim bulunamadı.", 404);
            }

            var notificationRM = _mapper.Map<NotificationRM>(notification);
            return ReturnRM<NotificationRM>.Success(notificationRM, 200);
        }

        //  Bildirim silme
        public async Task<ReturnRM<string>> DeleteNotificationAsync(int notificationId)
        {
            var notification = await _notificationManager.GetByIdAsync(notificationId);

            if (notification == null)
            {
                return ReturnRM<string>.Fail("Bildirim bulunamadı.", 404);
            }

            _notificationManager.Delete(notification);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Bildirim silinemedi.", 500);
            }

            return ReturnRM<string>.Success("Bildirim başarıyla silindi.", 200);
        }

        //  Kullanıcıya ait tüm bildirimleri temizleme
        public async Task<ReturnRM<string>> ClearUserNotificationsAsync(string userId)
        {
            var notifications = await _notificationManager.GetAllAsync(x => x.UserId == userId);

            foreach (var notification in notifications)
            {
                _notificationManager.Delete(notification);
            }

            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Bildirimler temizlenemedi.", 500);
            }

            return ReturnRM<string>.Success("Kullanıcının bildirimleri başarıyla temizlendi.", 200);
        }

        //  Kullanıcının okunmamış bildirimlerini getirme
        public async Task<ReturnRM<IEnumerable<NotificationRM>>> GetUnreadNotificationsAsync(string userId)
        {
            var notifications = await _notificationManager.GetAllAsync(
                x => x.UserId == userId && !x.IsRead,
                includes: x => x.Include(n => n.User));

            if (notifications == null || !notifications.Any())
            {
                return ReturnRM<IEnumerable<NotificationRM>>.Fail("Okunmamış bildirim bulunamadı.", 404);
            }

            var notificationRMs = _mapper.Map<IEnumerable<NotificationRM>>(notifications);
            return ReturnRM<IEnumerable<NotificationRM>>.Success(notificationRMs, 200);
        }

        //  Bildirimi okunmuş olarak işaretle
        public async Task<ReturnRM<string>> MarkNotificationAsReadAsync(int notificationId)
        {
            var notification = await _notificationManager.GetByIdAsync(notificationId);

            if (notification == null)
            {
                return ReturnRM<string>.Fail("Bildirim bulunamadı.", 404);
            }

            notification.IsRead = true;
            _notificationManager.Update(notification);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Bildirim okunmuş olarak işaretlenemedi.", 500);
            }

            return ReturnRM<string>.Success("Bildirim başarıyla okunmuş olarak işaretlendi.", 200);
        }

        //  Tüm bildirimleri okunmuş olarak işaretle
        public async Task<ReturnRM<string>> MarkAllNotificationsAsReadAsync(string userId)
        {
            var notifications = await _notificationManager.GetAllAsync(x => x.UserId == userId && !x.IsRead);

            foreach (var notification in notifications)
            {
                notification.IsRead = true;
                _notificationManager.Update(notification);
            }

            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Bildirimler okunmuş olarak işaretlenemedi.", 500);
            }

            return ReturnRM<string>.Success("Tüm bildirimler başarıyla okunmuş olarak işaretlendi.", 200);
        }

        //  Kullanıcının en son bildirimlerini getir
        public async Task<ReturnRM<IEnumerable<NotificationRM>>> GetLatestNotificationsAsync(string userId, int count)
        {
            var notifications = await _notificationManager.GetTopAsync(
                count,
                x => x.UserId == userId,
                 q => q.OrderByDescending(n => n.DateCreated),
                 x => x.Include(n => n.User));

            if (notifications == null || !notifications.Any())
            {
                return ReturnRM<IEnumerable<NotificationRM>>.Fail("En son bildirimler bulunamadı.", 404);
            }

            var notificationRMs = _mapper.Map<IEnumerable<NotificationRM>>(notifications);
            return ReturnRM<IEnumerable<NotificationRM>>.Success(notificationRMs, 200);
        }

        //  Okunmamış bildirim sayısını getir
        public async Task<ReturnRM<int>> GetUnreadNotificationCountAsync(string userId)
        {
            var unreadCount = await _notificationManager.CountAsync(x => x.UserId == userId && !x.IsRead);
            return ReturnRM<int>.Success(unreadCount, 200);
        }
    }

}
