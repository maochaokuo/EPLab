
using EPlab.entity.fwk;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPLab.model
{
    public class tableEditViewModel : ViewModelBase
    {
        public tables editModel { get; set; }
        public tableEditViewModel()
        {
            editModel = new tables();
        }
    }
}
