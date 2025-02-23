using Commercium.Entity.Businness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.Tags
{
    public class ServiceTag
    {
        public int ServiceId { get; set; }
        public Service Service { get; set; }  // Hizmet

        public int TagId { get; set; }
        public Tag Tag { get; set; }  // Etiket
    }

}
