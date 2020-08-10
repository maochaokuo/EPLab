namespace EPlab.entity.fwk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class queryFields
    {
        [Key]
        public int queryFieldId { get; set; }

        public Guid queryId { get; set; }

        public Guid fieldId { get; set; }

        public int displayOrder { get; set; }

        public int orderByOrder { get; set; }

        public bool editable { get; set; }
    }
}
