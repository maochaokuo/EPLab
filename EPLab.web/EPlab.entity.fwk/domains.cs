namespace EPlab.entity.fwk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class domains
    {
        [Key]
        public Guid domainId { get; set; }

        [Required]
        [StringLength(50)]
        public string domainName { get; set; }

        [StringLength(999)]
        public string domainDescription { get; set; }

        [StringLength(50)]
        public string basicType { get; set; }

        public Guid? isDomainCaseId { get; set; }
    }
}
