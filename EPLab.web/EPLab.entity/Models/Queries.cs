using System;
using System.Collections.Generic;

namespace EPLab.entity.Models
{
    public partial class Queries
    {
        public Guid QueryId { get; set; }
        public string QueryName { get; set; }
        public string QueryDesc { get; set; }
        public Guid? TableId { get; set; }
        public string TableAlias { get; set; }
        public Guid? WhereExpressionId { get; set; }
    }
}
