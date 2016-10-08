using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.Models
{
    [Table("user_role")]
    public partial class UserRole
    {
        [Column("user_id")]
        public long UserId { get; set; }
        [Column("role_id")]
        public long RoleId { get; set; }

        [ForeignKey("RoleId")]
        [InverseProperty("UserRole")]
        public virtual Role Role { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("UserRole")]
        public virtual User User { get; set; }
    }
}
