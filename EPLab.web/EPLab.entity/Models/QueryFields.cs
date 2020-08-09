using System;
using System.Collections.Generic;

namespace EPLab.entity.Models
{
    public partial class QueryFields
    {
        public int QueryFieldId { get; set; }
        public Guid QueryId { get; set; }
        public Guid FieldId { get; set; }
        public int DisplayOrder { get; set; }
        public int OrderByOrder { get; set; }
        public bool Editable { get; set; }
    }
}
