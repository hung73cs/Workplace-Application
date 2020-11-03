using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class User
    {
        public User()
        {
            Relationshipuserpermission = new HashSet<Relationshipuserpermission>();
            Reservation = new HashSet<Reservation>();
        }
        public long Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string DisplayName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public long? DepartmentId { get; set; }

        public virtual ICollection<Relationshipuserpermission> Relationshipuserpermission { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
