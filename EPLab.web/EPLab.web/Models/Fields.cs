using System;
using System.Collections.Generic;

namespace EPLab.web.Models
{
    public partial class Fields
    {
        public Guid FieldId { get; set; }
        public Guid TableId { get; set; }
        public string FieldName { get; set; }
        public string FieldDesc { get; set; }
        public int? PrimaryOrder { get; set; }
        public Guid? ForeignFieldId { get; set; }
        public string DefaultValue { get; set; }
        public Guid? DomainId { get; set; }
    }
}
