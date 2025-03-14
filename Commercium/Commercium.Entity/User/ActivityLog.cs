﻿using Commercium.Entity.Businness;
using Commercium.Entity.User.Account;
using Commercium.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.User
{
    public class ActivityLog
    {
        public int ActivityLogId { get; set; }
        public ActivityType ActivityType { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Details { get; set; }
        public int EntityId { get; set; }
        public EntityType EntityType { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public string EntityName { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public int? ServiceId { get; set; }
        public Service? Service { get; set; }

    }

}
