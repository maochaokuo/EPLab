namespace EPlab.entity.fwk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class fieldValues
    {
        [Key]
        public long fieldValueId { get; set; }

        public Guid rowId { get; set; }

        public Guid fieldId { get; set; }

        [Required]
        [StringLength(450)]
        public string fieldValue { get; set; }

        public Guid? domainCaseId { get; set; }
    }
}
