using Commercium.Entity.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.Businness
{
    public class BusinessProfileTag
    {
        public int BusinessProfileId { get; set; }
        public BusinessProfile BusinessProfile { get; set; }  // İşletme Profili

        public int TagId { get; set; }
        public Tag Tag { get; set; }  // Etiket
    }

}
