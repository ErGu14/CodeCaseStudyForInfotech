using Commercium.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity
{
    public class Media
    {
        public int MediaId { get; set; }
        public string FilePath { get; set; } // Medyanın depolandığı yol
        public MediaType MediaType { get; set; } // Medya türü (Resim, video, vs.)
        public DateTime DateUploaded { get; set; }

        public Product Product { get; set; }
        public Service Service { get; set; }
    }

}
