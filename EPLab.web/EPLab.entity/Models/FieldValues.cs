using System;
using System.Collections.Generic;

namespace EPLab.entity.Models
{
    public partial class FieldValues
    {
        public long FieldValueId { get; set; }
        public Guid RowId { get; set; }
        public Guid FieldId { get; set; }
        public string FieldValue { get; set; }
    }
}
