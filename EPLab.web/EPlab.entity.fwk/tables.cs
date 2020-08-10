namespace EPlab.entity.fwk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tables
    {
        [Key]
        public Guid tableId { get; set; }

        [Required]
        [StringLength(50)]
        public string tableName { get; set; }

        [StringLength(999)]
        public string tableDesc { get; set; }
    }
}
