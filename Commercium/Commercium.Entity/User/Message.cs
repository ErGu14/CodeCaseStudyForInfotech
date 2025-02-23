using Commercium.Entity.User.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.User
{
    public class Message
    {
        public int MessageId { get; set; }

        public string SenderId { get; set; }
        public AppUser Sender { get; set; }

        public string ReceiverId { get; set; }
        public AppUser Receiver { get; set; }

        public string Content { get; set; }
        public DateTime SentDate { get; set; }
        public bool IsRead { get; set; }


        public int? MediaId { get; set; }
        public Media Media { get; set; }
    }


}
