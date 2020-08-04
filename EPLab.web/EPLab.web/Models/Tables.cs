using System;
using System.Collections.Generic;

namespace EPLab.web.Models
{
    public partial class Tables
    {
        public Guid TableId { get; set; }
        public string TableName { get; set; }
        public string TableDesc { get; set; }
    }
}
