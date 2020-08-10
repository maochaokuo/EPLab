namespace EPlab.entity.fwk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rows
    {
        [Key]
        public Guid rowId { get; set; }

        public Guid tableId { get; set; }
    }
}
