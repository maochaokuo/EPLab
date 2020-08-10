namespace EPlab.entity.fwk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class operators
    {
        [Key]
        public Guid operatorId { get; set; }

        [Required]
        [StringLength(50)]
        public string source { get; set; }

        [StringLength(999)]
        public string operatorDesc { get; set; }

        public Guid? queryId { get; set; }

        [Required]
        [StringLength(50)]
        public string stringInSourceCode { get; set; }

        public bool isPrefix { get; set; }

        public int paraNum { get; set; }
    }
}
