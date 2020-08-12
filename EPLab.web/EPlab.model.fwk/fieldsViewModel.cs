
using System;
using System.Collections.Generic;
using System.Text;

namespace EPlab.model.fwk
{
    [Serializable]
    public class fieldsViewModel : ViewModelBase
    {
        public fieldDisp editModel { get; set; }
        public List<fieldDisp> queryResult { get; set; }
        public fieldsViewModel()
        {
            editModel = new fieldDisp();
            queryResult = new List<fieldDisp>();
        }
    }
}
