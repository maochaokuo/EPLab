using System;
using System.Collections.Generic;

namespace EPLab.web.Models
{
    public partial class AllIdHistory
    {
        public long AllIdHistoryId { get; set; }
        public Guid Uid { get; set; }
        public string FromTable { get; set; }
        public DateTime? Createtime { get; set; }
        public DateTime? Modifytime { get; set; }
        public string CreateBy { get; set; }
        public string ModifyBy { get; set; }
        public string Tag { get; set; }
    }
}
