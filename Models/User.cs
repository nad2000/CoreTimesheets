using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.Models
{
    [Table("user")]
    public partial class User
    {
        public User()
        {
            ApproverCompany = new HashSet<ApproverCompany>();
            EntryApprover = new HashSet<Entry>();
            EntryUser = new HashSet<Entry>();
            UserRole = new HashSet<UserRole>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("username", TypeName = "VARCHAR(255)")]
        public string Username { get; set; }
        [Required]
        [Column("password", TypeName = "VARCHAR(255)")]
        public string Password { get; set; }
        [Required]
        [Column("email", TypeName = "VARCHAR(255)")]
        public string Email { get; set; }
        [Required]
        [Column("first_name", TypeName = "VARCHAR(255)")]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name", TypeName = "VARCHAR(255)")]
        public string LastName { get; set; }
        [Column("active")]
        public long Active { get; set; }
        [Column("workplace_id")]
        public long WorkplaceId { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<ApproverCompany> ApproverCompany { get; set; }
        [InverseProperty("Approver")]
        public virtual ICollection<Entry> EntryApprover { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Entry> EntryUser { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserRole> UserRole { get; set; }
        [ForeignKey("WorkplaceId")]
        [InverseProperty("User")]
        public virtual Company Workplace { get; set; }
    }
}
