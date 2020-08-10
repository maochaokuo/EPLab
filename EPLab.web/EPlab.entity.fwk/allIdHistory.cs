namespace EPlab.entity.fwk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("allIdHistory")]
    public partial class allIdHistory
    {
        public long allIdHistoryId { get; set; }

        public Guid uid { get; set; }

        [StringLength(50)]
        public string fromTable { get; set; }

        public DateTime? createtime { get; set; }

        public DateTime? modifytime { get; set; }

        [StringLength(50)]
        public string createBy { get; set; }

        [StringLength(50)]
        public string modifyBy { get; set; }

        [StringLength(50)]
        public string tag { get; set; }
    }
}
