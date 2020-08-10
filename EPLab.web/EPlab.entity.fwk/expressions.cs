namespace EPlab.entity.fwk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class expressions
    {
        [Key]
        public Guid expressionId { get; set; }

        [Required]
        [StringLength(50)]
        public string source { get; set; }

        [StringLength(999)]
        public string expressionDesc { get; set; }

        public Guid? queryId { get; set; }

        public Guid operatorId { get; set; }

        public Guid paraField1id { get; set; }

        public Guid? paraField2id { get; set; }

        public Guid? paraField3id { get; set; }

        public Guid? paraField4id { get; set; }

        public Guid? paraField5id { get; set; }

        public Guid resultFieldId { get; set; }
    }
}