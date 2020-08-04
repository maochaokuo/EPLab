using System;
using System.Collections.Generic;

namespace EPLab.web.Models
{
    public partial class Domains
    {
        public Guid DomainId { get; set; }
        public string DomainName { get; set; }
        public string DomainDescription { get; set; }
        public string BasicType { get; set; }
        public Guid? IsDomainCaseId { get; set; }
    }
}
