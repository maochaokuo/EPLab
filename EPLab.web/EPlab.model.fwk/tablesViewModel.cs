
using System;
using System.Collections.Generic;
using System.Text;

namespace EPlab.model.fwk
{
    [Serializable]
    public class tablesViewModel : ViewModelBase
    { 
        //public string TableName { get; set; }
        //public string TableDesc { get; set; }

        //public List<Tables> tables { get; set; }
        public tableDisp editModel { get; set; }
        public List<tableDisp> queryResult { get; set; }
        public tablesViewModel()
        {
            //tables = new List<Tables>();
            editModel = new tableDisp();
            queryResult = new List<tableDisp>();
        }
    }
}
