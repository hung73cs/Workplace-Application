using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Location
    {
        public Location()
        {
            InverseParent = new HashSet<Location>();
            Workspace = new HashSet<Workspace>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long? ParentId { get; set; }

        public virtual Location Parent { get; set; }
        public virtual ICollection<Location> InverseParent { get; set; }
        public virtual ICollection<Workspace> Workspace { get; set; }
    }
}
