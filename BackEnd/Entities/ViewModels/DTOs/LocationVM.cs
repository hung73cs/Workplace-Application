using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class LocationVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long? ParentId { get; set; }
    }
}
