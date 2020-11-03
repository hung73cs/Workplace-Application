using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Permission
    {
        public Permission()
        {
            Detailpermission = new HashSet<Detailpermission>();
            Relationshipuserpermission = new HashSet<Relationshipuserpermission>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Detailpermission> Detailpermission { get; set; }
        public virtual ICollection<Relationshipuserpermission> Relationshipuserpermission { get; set; }
    }
}
