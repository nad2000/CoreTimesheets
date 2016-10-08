using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreTimesheets.Models
{
    [Table("break")]
    public partial class Break
    {
        public Break()
        {
            Entry = new HashSet<Entry>();
        }

        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("code", TypeName = "VARCHAR(255)")]
        public string Code { get; set; }
        [Required]
        [Column("name", TypeName = "VARCHAR(255)")]
        public string Name { get; set; }
        [Column("minutes")]
        public long Minutes { get; set; }
        [Required]
        [Column("alternative_code", TypeName = "VARCHAR(255)")]
        public string AlternativeCode { get; set; }

        [InverseProperty("BreakFor")]
        public virtual ICollection<Entry> Entry { get; set; }
    }
}
