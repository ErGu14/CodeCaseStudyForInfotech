using Commercium.Entity.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; } // 1-5 arasında puan
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }

        public Product? Product { get; set; }
        public Service? Service { get; set; }
        public AppUser User { get; set; }
    }

}
