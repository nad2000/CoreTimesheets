using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.Models
{
    [Table("entry")]
    public partial class Entry
    {   
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("date", TypeName = "DATE")]
        public string Date { get; set; }
        [Column("user_id")]
        public long UserId { get; set; }
        [Column("approver_id")]
        public long? ApproverId { get; set; }
        [Required]
        [Column("started_at", TypeName = "TIME")]
        public string StartedAt { get; set; }
        [Required]
        [Column("finished_at", TypeName = "TIME")]
        public string FinishedAt { get; set; }
        [Required]
        [Column("modified_at", TypeName = "DATETIME")]
        public string ModifiedAt { get; set; }
        [Column("approved_at", TypeName = "DATETIME")]
        public string ApprovedAt { get; set; }
        [Column("comment")]
        public string Comment { get; set; }
        [Column("break_for_id")]
        public long? BreakForId { get; set; }
        [Column("is_approved")]
        public long IsApproved { get; set; }

        [ForeignKey("ApproverId")]
        [InverseProperty("EntryApprover")]
        public virtual User Approver { get; set; }
        [ForeignKey("BreakForId")]
        [InverseProperty("Entry")]
        public virtual Break BreakFor { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("EntryUser")]
        public virtual User User { get; set; }
    }
}
