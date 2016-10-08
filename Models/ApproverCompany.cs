using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.Models
{
    [Table("approver_company")]
    public partial class ApproverCompany
    {
        [Column("user_id")]
        public long UserId { get; set; }
        [Column("company_id")]
        public long CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        [InverseProperty("ApproverCompany")]
        public virtual Company Company { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("ApproverCompany")]
        public virtual User User { get; set; }
    }
}
