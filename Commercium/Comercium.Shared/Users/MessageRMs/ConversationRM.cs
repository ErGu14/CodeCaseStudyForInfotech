using Commercium.Shared.Users.AccountRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.MessageRMs
{
    public class ConversationRM
    {
        public int ConversationId { get; set; }

        public string SenderId { get; set; }
        public AppUserRM Sender { get; set; }

        public string ReceiverId { get; set; }
        public AppUserRM Receiver { get; set; }

        public DateTime LastMessageDate { get; set; }

        public IEnumerable<MessageRM> Messages { get; set; }
    }

}
