namespace EPlab.entity.fwk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class fields
    {
        [Key]
        public Guid fieldId { get; set; }

        public Guid tableId { get; set; }

        [Required]
        [StringLength(50)]
        public string fieldName { get; set; }

        [StringLength(999)]
        public string fieldDesc { get; set; }

        public int? primaryOrder { get; set; }

        public Guid? foreignFieldId { get; set; }

        [StringLength(450)]
        public string defaultValue { get; set; }

        public Guid? domainId { get; set; }

        public int? defaultOrder { get; set; }
    }
}
