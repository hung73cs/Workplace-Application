using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Department
    {
        public Department()
        {
            InverseParent = new HashSet<Department>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long? ParentId { get; set; }
        public virtual Department Parent { get; set; }
        public virtual ICollection<Department> InverseParent { get; set; }
    }
}
