
using EPLab.web.fwk.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPLab.web.Controllers
{
	public class ControllerBase : Controller
	{
		protected string connEPLabDB = "";
		protected dropdownOptions ddO = null;
		protected const string PageStatus = "pageStatus";
		protected const string MultiSelect = "multiSelect";
		protected readonly string modelName;
		protected readonly string modelMessage;
		public ControllerBase(string modelName, string modelMessage)
		{
			connEPLabDB = ConfigurationManager.ConnectionStrings["EPlabContext"].ConnectionString;
			ddO = new dropdownOptions(connEPLabDB);
			this.modelName = modelName;
			this.modelMessage = modelMessage;
        }
	}
}