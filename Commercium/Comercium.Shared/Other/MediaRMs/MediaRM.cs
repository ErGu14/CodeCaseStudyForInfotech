using Commercium.Shared.Businness.ServiceRMs;
using Commercium.Shared.Enums;
using Commercium.Shared.ProductRMs;
using Commercium.Shared.Users.MessageRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Other.MediaRMs
{
    public class MediaRM
    {
        public int MediaId { get; set; }
        public string FilePath { get; set; }
        public MediaType MediaType { get; set; }
        public DateTime DateUploaded { get; set; }

        public int? ProductId { get; set; }
        public ProductRM? Product { get; set; }

        public int? ServiceId { get; set; }
        public ServiceRM? Service { get; set; }

        public int? MessageId { get; set; }
        public MessageRM? Message { get; set; }
    }

}
