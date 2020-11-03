using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.DTOs
{
    public partial class UserVM
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public long DepartmentId { get; set; }
    }
}
