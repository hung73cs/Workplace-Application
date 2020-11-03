
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ReservationVM
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long WorkspaceId { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual UserVM User { get; set; }
    }
}
