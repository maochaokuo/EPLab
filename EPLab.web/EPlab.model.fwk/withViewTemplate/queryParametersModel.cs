using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPlab.model.fwk
{
    public class queryParasViewModel
    {
        public Dictionary<string, queryParameterViewModel>
            queryParaInternal { get; set; }
        public queryParasViewModel()
        {
            queryParaInternal = new Dictionary<string, queryParameterViewModel>();
        }
    }
}
