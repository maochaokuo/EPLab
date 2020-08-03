using System;
using System.Collections.Generic;

namespace EPLab.entity.Models
{
    public partial class Domains
    {
        public Guid DomainId { get; set; }
        public string DomainName { get; set; }
        public string DomainDescription { get; set; }
        public string BasicType { get; set; }
    }
}
