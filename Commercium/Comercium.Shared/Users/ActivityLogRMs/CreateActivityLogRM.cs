using Commercium.Shared.AccountRMs;
using Commercium.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.ActivityLogRMs
{
    public class CreateActivityLogRM
    {
        [Required]
        public ActivityType ActivityType { get; set; }

        [Required]
        public DateTime ActivityDate { get; set; } = DateTime.UtcNow; // Varsayılan olarak şu anın zamanı

        [Required]
        [StringLength(500, ErrorMessage = "Detaylar en fazla 500 karakter olabilir.")]
        public string Details { get; set; }

        [Required]
        public int EntityId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Entity tipi en fazla 100 karakter olabilir.")]
        public string EntityType { get; set; }

        [Required]
        public string UserId { get; set; }


        public string? EntityName { get; set; }

        public int? ProductId { get; set; }

        public int? ServiceId { get; set; }
    }
}
