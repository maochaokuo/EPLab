
using System;
using System.Collections.Generic;
using System.Text;

namespace EPlab.model.fwk
{
    [Serializable]
    public class queriesViewModel : ViewModelBase
    {
        public queryDisp editModel { get; set; }
        public List<queryDisp> queryResult { get; set; }
        public queriesViewModel()
        {
            editModel = new queryDisp();
            queryResult = new List<queryDisp>();
        }
    }
}
