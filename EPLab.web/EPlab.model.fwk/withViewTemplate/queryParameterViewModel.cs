using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPlab.model.fwk
{
    public class queryParameterViewModel
    {
        public string paraName { get; set; }
        public List<KeyValuePair<string, string>>
            comboboxSource { get; set; }
        protected void init()
        {
            comboboxSource = new List<KeyValuePair<string, string>>();
        }
        public queryParameterViewModel()
        {
            init();
        }
        public queryParameterViewModel(string paraName)
        {
            this.paraName = paraName;
            init();
        }
    }
}
