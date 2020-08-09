using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPLab.web.baseCls
{
    public class ControllerBase : Controller
	{
		// just archive it, no use
		protected const string PageStatus = "pageStatus";
		protected const string MultiSelect = "multiSelect";
		protected readonly string modelName;
		protected readonly string modelMessage;
		public ControllerBase(string modelName, string modelMessage)
		{
			this.modelName = modelName;
			this.modelMessage = modelMessage;
		}
	}
}
