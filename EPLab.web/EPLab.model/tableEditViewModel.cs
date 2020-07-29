using EPLab.entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPLab.model
{
    public class tableEditViewModel : ViewModelBase
    {
        public Tables editModel { get; set; }
        public tableEditViewModel()
        {
            editModel = new Tables();
        }
    }
}
