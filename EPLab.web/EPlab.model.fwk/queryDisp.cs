using EPlab.entity.fwk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPlab.model.fwk
{
    public class queryDisp //: queries
    {
        public string queryId { get; set; }
        public string queryName { get; set; }
        public string queryDesc { get; set; }
        public Guid? tableId { get; set; }
        public string tableAlias { get; set; }
        public Guid? whereExpressionId { get; set; }
    }
}
