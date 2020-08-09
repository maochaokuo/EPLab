using System;
using System.Collections.Generic;

namespace EPLab.entity.Models
{
    public partial class Expressions
    {
        public Guid ExpressionId { get; set; }
        public string Source { get; set; }
        public string ExpressionDesc { get; set; }
        public Guid? QueryId { get; set; }
        public Guid OperatorId { get; set; }
        public Guid ParaField1id { get; set; }
        public Guid? ParaField2id { get; set; }
        public Guid? ParaField3id { get; set; }
        public Guid? ParaField4id { get; set; }
        public Guid? ParaField5id { get; set; }
        public Guid ResultFieldId { get; set; }
    }
}
