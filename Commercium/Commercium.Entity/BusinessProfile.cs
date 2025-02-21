﻿using Commercium.Entity.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity
{
    public class BusinessProfile
    {
        public int BusinessProfileId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessDescription { get; set; }
        public string ContactInfo { get; set; }
        public string Location { get; set; }

        public int ClickCount { get; set; }  // Tıklanma sayısı
        public int LikeCount { get; set; }   // Beğenilme sayısı

        public AppUser Owner { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Service> Services { get; set; }

        // Etiketler
        public ICollection<BusinessProfileTag> BusinessProfileTags { get; set; }  // Etiket bağlantısı
    }




}
