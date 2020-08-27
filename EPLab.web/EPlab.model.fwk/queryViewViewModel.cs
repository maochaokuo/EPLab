
using EPlab.entity.fwk;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPlab.model.fwk
{
    [Serializable]
    public class queryViewViewModel : ViewModelBase
    {
        public List<queryDisp> query2select { get; set; }
        public queryDisp currentQuery { get; set; }
        public List<string> queryPara ()
        {
            List<string> ret = null;
            if (currentQuery == null)
                return ret;
            ret = new List<string>();
            Guid? expId = currentQuery.whereExpressionId;
            if (expId == null)
                return ret;
            expressions expr = null;//todo !!... (3) get by expId
            if (!string.IsNullOrWhiteSpace(expr.para1externalName))
                ret.Add(expr.para1externalName.Trim());
            if (!string.IsNullOrWhiteSpace(expr.para2externalName))
                ret.Add(expr.para2externalName.Trim());
            if (!string.IsNullOrWhiteSpace(expr.para3externalName))
                ret.Add(expr.para3externalName.Trim());
            if (!string.IsNullOrWhiteSpace(expr.para4externalName))
                ret.Add(expr.para4externalName.Trim());
            if (!string.IsNullOrWhiteSpace(expr.para5externalName))
                ret.Add(expr.para5externalName.Trim());
            return ret;
        }

        public queryViewViewModel()
        {
            query2select = new List<queryDisp>();
            currentQuery = new queryDisp();
        }
    }
}
