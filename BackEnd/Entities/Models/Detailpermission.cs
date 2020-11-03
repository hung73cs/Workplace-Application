using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Detailpermission
    {
        public long Id { get; set; }
        public long? PermissionId { get; set; }
        public string ActionName { get; set; }
        public string ActionCode { get; set; }
        public byte CheckAction { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
