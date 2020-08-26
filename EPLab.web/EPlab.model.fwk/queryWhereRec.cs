using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPlab.model.fwk
{
    [Serializable]
    public class queryWhereRec
    {
        public bool isWhereExpressId { get; set; }
        public string expressionId { get; set; }
        public string operatorName { get; set; }
        public string stringInSourceCode { get; set; }
        public bool isPrefix { get; set; }
        public int paraNum { get; set; }
        public string paraField1id { get; set; }
        public string field1Name { get; set; }
        public string paraField2id { get; set; }
        public string field2Name { get; set; }
        public string para2externalName { get; set; }
        public string subExpression1Id { get; set; }
        public string subExpression2Id { get; set; }
    }
}
