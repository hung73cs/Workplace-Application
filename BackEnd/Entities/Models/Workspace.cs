using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Workspace
    {
        public Workspace()
        {
            Reservation = new HashSet<Reservation>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public long LocationId { get; set; }
        public byte Status { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
