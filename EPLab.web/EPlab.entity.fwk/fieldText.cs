namespace EPlab.entity.fwk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fieldText")]
    public partial class fieldText
    {
        public long fieldTextId { get; set; }

        public Guid rowId { get; set; }

        public Guid fieldId { get; set; }

        [Required]
        public string fieldStrMax { get; set; }
    }
}
