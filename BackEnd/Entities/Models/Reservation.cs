using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Reservation
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long WorkspaceId { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual User User { get; set; }
        public virtual Workspace Workspace { get; set; }
    }
}
