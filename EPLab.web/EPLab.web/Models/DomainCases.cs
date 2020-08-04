using System;
using System.Collections.Generic;

namespace EPLab.web.Models
{
    public partial class DomainCases
    {
        public Guid DomainCaseId { get; set; }
        public Guid DomainId { get; set; }
        public string DomainCaseName { get; set; }
        public string RangeMin { get; set; }
        public string RangeMax { get; set; }
        public string DomainCaseDescription { get; set; }
    }
}
