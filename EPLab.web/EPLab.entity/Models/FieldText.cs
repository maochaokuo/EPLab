using System;
using System.Collections.Generic;

namespace EPLab.entity.Models
{
    public partial class FieldText
    {
        public long FieldTextId { get; set; }
        public Guid RowId { get; set; }
        public Guid FieldId { get; set; }
        public string FieldStrMax { get; set; }
    }
}
