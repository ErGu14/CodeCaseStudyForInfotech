using Commercium.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Commercium.Shared.Users.ActivityLogRMs
{
    public class CreateActivityLogRM
    {
        [Required]
        public ActivityType ActivityType { get; set; }

        [Required]
        public DateTime ActivityDate { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(500, ErrorMessage = "Detaylar en fazla 500 karakter olabilir.")]
        public string Details { get; set; }

        [Required]
        public int EntityId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Entity tipi en fazla 100 karakter olabilir.")]
        public EntityType EntityType { get; set; } 

        [Required]
        public string UserId { get; set; }

        public string EntityName { get; set; }

        public int? ProductId { get; set; }

        public int? ServiceId { get; set; }
    }

}
