namespace EPlab.entity.fwk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class domainCases
    {
        public Guid domainCaseId { get; set; }

        [Key]
        [Column(Order = 0)]
        public Guid domainId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string domainCaseName { get; set; }

        [StringLength(50)]
        public string rangeMin { get; set; }

        [StringLength(50)]
        public string rangeMax { get; set; }

        [StringLength(999)]
        public string domainCaseDescription { get; set; }
    }
}
