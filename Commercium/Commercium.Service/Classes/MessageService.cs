using AutoMapper;
using Commercium.Data.Interfaces;
using Commercium.Entity.User;
using Commercium.Service.Interfaces;
using Commercium.Shared.Other.Enums;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.MessageRMs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Classes
{
    public class MessageService : IMessageService
    {
        private readonly IGenericManager<Message> _messageManager;
        private readonly IGenericManager<Conversation> _conversationManager;
        private readonly ITransactionManager _transactionManager;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public MessageService(
            IGenericManager<Message> messageManager,
            IGenericManager<Conversation> conversationManager,
            ITransactionManager transactionManager,
            IMapper mapper,
            IFileService fileService)
        {
            _messageManager = messageManager;
            _conversationManager = conversationManager;
            _transactionManager = transactionManager;
            _mapper = mapper;
            _fileService = fileService;
        }

        //  Mesaj gönderme
        public async Task<ReturnRM<string>> SendMessageAsync(CreateMessageRM createMessageRM, IFormFile? file)
        {
            var message = _mapper.Map<Message>(createMessageRM);

            if (file != null)
            {
                message.Content += await _fileService.UploadFileAsync(file,FileType.Other);  // File path ekleme
            }

            await _messageManager.AddAsync(message);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Mesaj gönderilemedi.", 500);
            }

            return ReturnRM<string>.Success("Mesaj başarıyla gönderildi.", 201);
        }

        //  Mesaj güncelleme
        public async Task<ReturnRM<string>> UpdateMessageAsync(UpdateMessageRM updateMessageRM)
        {
            var message = await _messageManager.GetByIdAsync(updateMessageRM.MessageId);

            if (message == null)
            {
                return ReturnRM<string>.Fail("Mesaj bulunamadı.", 404);
            }

            _mapper.Map(updateMessageRM, message);
            _messageManager.Update(message);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Mesaj güncellenemedi.", 500);
            }

            return ReturnRM<string>.Success("Mesaj başarıyla güncellendi.", 200);
        }

        //  Mesaj silme
        public async Task<ReturnRM<string>> DeleteMessageAsync(int messageId)
        {
            var message = await _messageManager.GetByIdAsync(messageId);

            if (message == null)
            {
                return ReturnRM<string>.Fail("Mesaj bulunamadı.", 404);
            }

            _messageManager.Delete(message);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Mesaj silinemedi.", 500);
            }

            return ReturnRM<string>.Success("Mesaj başarıyla silindi.", 200);
        }

        //  Bir konuşmadaki tüm mesajları silme
        public async Task<ReturnRM<string>> DeleteAllMessagesInConversationAsync(int conversationId)
        {
            var conversation = await _conversationManager.GetByIdAsync(conversationId);

            if (conversation == null)
            {
                return ReturnRM<string>.Fail("Konuşma bulunamadı.", 404);
            }

            var messages = await _messageManager.GetAllAsync(x => x.ConversationId == conversationId);

            foreach (var message in messages)
            {
                _messageManager.Delete(message);
            }

            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Mesajlar silinemedi.", 500);
            }

            return ReturnRM<string>.Success("Konuşmadaki tüm mesajlar başarıyla silindi.", 200);
        }

        //  Kullanıcıya ait tüm mesajları silme
        public async Task<ReturnRM<string>> DeleteAllMessagesByUserAsync(string userId)
        {
            var messages = await _messageManager.GetAllAsync(x => x.SenderId == userId || x.ReceiverId == userId);

            foreach (var message in messages)
            {
                _messageManager.Delete(message);
            }

            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Mesajlar silinemedi.", 500);
            }

            return ReturnRM<string>.Success("Kullanıcıya ait tüm mesajlar başarıyla silindi.", 200);
        }

        //  Kullanıcının tüm konuşmalarını getir
        public async Task<ReturnRM<IEnumerable<ConversationRM>>> GetUserConversationsAsync(string userId)
        {
            var conversations = await _conversationManager.GetAllAsync(
                x => x.SenderId == userId || x.ReceiverId == userId,
                includes: x => x.Include(c => c.Messages));

            if (conversations == null || !conversations.Any())
            {
                return ReturnRM<IEnumerable<ConversationRM>>.Fail("Kullanıcının konuşmaları bulunamadı.", 404);
            }

            var conversationRMs = _mapper.Map<IEnumerable<ConversationRM>>(conversations);
            return ReturnRM<IEnumerable<ConversationRM>>.Success(conversationRMs, 200);
        }

        //  Konuşma ID'ye göre mesajları getir
        public async Task<ReturnRM<IEnumerable<MessageRM>>> GetMessagesByConversationAsync(int conversationId)
        {
            var messages = await _messageManager.GetAllAsync(
                x => x.ConversationId == conversationId,
                includes: x => x.Include(m => m.Sender)
                                .Include(m => m.Receiver));

            if (messages == null || !messages.Any())
            {
                return ReturnRM<IEnumerable<MessageRM>>.Fail("Mesaj bulunamadı.", 404);
            }

            var messageRMs = _mapper.Map<IEnumerable<MessageRM>>(messages);
            return ReturnRM<IEnumerable<MessageRM>>.Success(messageRMs, 200);
        }

        //  Konuşma ID'ye göre son mesajı getir
        public async Task<ReturnRM<MessageRM>> GetLastMessageByConversationAsync(int conversationId)
        {
            var message = await _messageManager.GetAsync(
                x => x.ConversationId == conversationId,
                includes: x => x.Include(m => m.Sender)
                                .Include(m => m.Receiver));

            if (message == null)
            {
                return ReturnRM<MessageRM>.Fail("Son mesaj bulunamadı.", 404);
            }

            var messageRM = _mapper.Map<MessageRM>(message);
            return ReturnRM<MessageRM>.Success(messageRM, 200);
        }

        //  Okunmamış mesajları getir
        public async Task<ReturnRM<IEnumerable<MessageRM>>> GetUnreadMessagesAsync(string userId)
        {
            var messages = await _messageManager.GetAllAsync(
                x => (x.ReceiverId == userId && !x.IsRead),
                includes: x => x.Include(m => m.Sender)
                                .Include(m => m.Receiver));

            if (messages == null || !messages.Any())
            {
                return ReturnRM<IEnumerable<MessageRM>>.Fail("Okunmamış mesaj bulunamadı.", 404);
            }

            var messageRMs = _mapper.Map<IEnumerable<MessageRM>>(messages);
            return ReturnRM<IEnumerable<MessageRM>>.Success(messageRMs, 200);
        }

        //  Mesajı okunmuş olarak işaretle
        public async Task<ReturnRM<string>> MarkMessageAsReadAsync(int messageId)
        {
            var message = await _messageManager.GetByIdAsync(messageId);

            if (message == null)
            {
                return ReturnRM<string>.Fail("Mesaj bulunamadı.", 404);
            }

            message.IsRead = true;
            _messageManager.Update(message);
            var save = await _transactionManager.SaveAsync();

            if (save <= 0)
            {
                return ReturnRM<string>.Fail("Mesaj okunmuş olarak işaretlenemedi.", 500);
            }

            return ReturnRM<string>.Success("Mesaj başarıyla okunmuş olarak işaretlendi.", 200);
        }
    }

}
