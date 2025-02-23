using Commercium.Shared.Other.MediaRMs;
using Commercium.Shared.Users.AccountRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.MessageRMs
{
    public class MessageRM
    {
        public int MessageId { get; set; }

        public string SenderId { get; set; }
        public AppUserRM Sender { get; set; }

        public string ReceiverId { get; set; }
        public AppUserRM Receiver { get; set; }

        public string Content { get; set; }
        public DateTime SentDate { get; set; }
        public bool IsRead { get; set; }

        public int? MediaId { get; set; }
        public MediaRM? Media { get; set; }
    }

}
