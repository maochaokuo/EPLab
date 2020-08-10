namespace EPlab.entity.fwk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class queries
    {
        [Key]
        public Guid queryId { get; set; }

        [Required]
        [StringLength(50)]
        public string queryName { get; set; }

        [StringLength(999)]
        public string queryDesc { get; set; }

        public Guid? tableId { get; set; }

        [StringLength(50)]
        public string tableAlias { get; set; }

        public Guid? whereExpressionId { get; set; }
    }
}
