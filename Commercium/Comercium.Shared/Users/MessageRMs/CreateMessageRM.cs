using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.MessageRMs
{
    public class CreateMessageRM
    {
        [Required]
        public string SenderId { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        public string Content { get; set; }

        public IFormFile? File { get; set; } // Opsiyonel dosya desteği

        public DateTime SentDate { get; set; } = DateTime.UtcNow;

        public int ConversationId { get; set; }
        
    }

}
