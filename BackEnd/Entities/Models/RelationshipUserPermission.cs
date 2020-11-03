using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Relationshipuserpermission
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? PermissionId { get; set; }
        public short? Suspended { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual User User { get; set; }
    }
}
