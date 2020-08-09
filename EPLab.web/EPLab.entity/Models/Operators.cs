using System;
using System.Collections.Generic;

namespace EPLab.entity.Models
{
    public partial class Operators
    {
        public Guid OperatorId { get; set; }
        public string Source { get; set; }
        public string OperatorDesc { get; set; }
        public Guid? QueryId { get; set; }
        public string StringInSourceCode { get; set; }
        public bool IsPrefix { get; set; }
        public int ParaNum { get; set; }
    }
}
