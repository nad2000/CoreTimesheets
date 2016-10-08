using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.Models
{
    [Table("role")]
    public partial class Role
    {
        public Role()
        {
            UserRole = new HashSet<UserRole>();
        }

        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("name", TypeName = "VARCHAR(255)")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
