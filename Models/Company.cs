using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.Models
{
    [Table("company")]
    public partial class Company
    {
        public Company()
        {
            ApproverCompany = new HashSet<ApproverCompany>();
            User = new HashSet<User>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("name", TypeName = "VARCHAR(255)")]
        public string Name { get; set; }
        [Required]
        [Column("code", TypeName = "VARCHAR(255)")]
        public string Code { get; set; }

        [InverseProperty("Company")]
        public virtual ICollection<ApproverCompany> ApproverCompany { get; set; }
        [InverseProperty("Workplace")]
        public virtual ICollection<User> User { get; set; }
    }
}
