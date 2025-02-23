using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.ReviewRMs
{
    public class CreateReviewRM
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int? ProductId { get; set; }
        public int? ServiceId { get; set; }
        public string UserId { get; set; }
    }
}
