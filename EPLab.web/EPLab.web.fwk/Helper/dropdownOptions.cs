using EPlab.entity.fwk;
using EPLab.dbService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPLab.web.fwk.Helper
{
    public class dropdownOptions
    {
        protected string connS = "";
        public dropdownOptions(string connS)
        {
            this.connS = connS;
        }
        public static SelectList fromKeyValueList(
            List<KeyValuePair<string, string>> kvl)
        {
            SelectList ret;
            List<SelectListItem> _items = new List<SelectListItem>();
            foreach(KeyValuePair<string, string> pair in kvl)
            {
                _items.Add(new SelectListItem()
                {
                    Text = pair.Value,
                    Value = pair.Key
                });
            }
            ret = new SelectList(_items, "Value", "Text", null);
            return ret;
        }
        public SelectList tableList()
        {
            SelectList ret;
            List<SelectListItem> _table = new List<SelectListItem>();
            tableLib tlib = new tableLib(connS);
            List<tables> tableList = tlib.GetAll();//.getAll().ToList();
            if (tableList != null)
            {
                foreach (tables rec in tableList)
                    _table.Add(new SelectListItem()
                    {
                        Text = rec.tableName,
                        Value = rec.tableId.ToString()
                    });
            }
            ret= new SelectList(_table, "Value", "Text", null);
            return ret;
        }
        public SelectList fieldList(string tableId)
        {
            SelectList ret;
            List<SelectListItem> _table = new List<SelectListItem>();
            fieldLib flib = new fieldLib(connS);
            List<fields> fieldList = flib.FieldsByTableId(
                new Guid(tableId));
            if (fieldList != null)
            {
                foreach (fields rec in fieldList)
                    _table.Add(new SelectListItem()
                    {
                        Text = rec.fieldName,
                        Value = rec.fieldId.ToString()
                    });
            }
            ret= new SelectList(_table, "Value", "Text", null);
            return ret;
        }

        public SelectList queryList()
        {
            SelectList ret;
            List<SelectListItem> _query = new List<SelectListItem>();
            queryLib qlib = new queryLib(connS);
            List<queries> queryList = qlib.GetAll();//.getAll().ToList();
            if (queryList != null)
            {
                foreach (queries rec in queryList)
                    _query.Add(new SelectListItem()
                    {
                        Text = rec.queryName,
                        Value = rec.queryId.ToString()
                    });
            }
            ret = new SelectList(_query, "Value", "Text", null);
            return ret;
        }
        //public static SelectList systemTypeList()
        //{
        //    SelectList ret;
        //    List<SelectListItem> _item = new List<SelectListItem>();
        //    _item.Add(new SelectListItem() { Text = "Web", Value = "Web", Selected = true });
        //    _item.Add(new SelectListItem() { Text = "Console", Value = "Console", Selected = true });
        //    _item.Add(new SelectListItem() { Text = "Windows", Value = "Windows", Selected = true });
        //    _item.Add(new SelectListItem() { Text = "WindowService", Value = "WindowService", Selected = true });
        //    _item.Add(new SelectListItem() { Text = "Library", Value = "Library", Selected = true });
        //    ret = new SelectList(_item, "Value", "Text", null);
        //    return ret;
        //}
        public SelectList tableWidthList()
        {
            SelectList ret;
            List<SelectListItem> _item = new List<SelectListItem>();
            _item.Add(new SelectListItem() { Text = "100%", Value = "100%", Selected = true });
            _item.Add(new SelectListItem() { Text = "200%", Value = "200%", Selected = true });
            _item.Add(new SelectListItem() { Text = "300%", Value = "300%", Selected = true });
            _item.Add(new SelectListItem() { Text = "500%", Value = "500%", Selected = true });
            _item.Add(new SelectListItem() { Text = "1000%", Value = "1000%", Selected = true });
            ret = new SelectList(_item, "Value", "Text", null);
            return ret;
        }
        public SelectList domainList()
        {
            SelectList ret;
            List<SelectListItem> _domain = new List<SelectListItem>();
            domainLib dlib = new domainLib(connS);
            List<domains> domainList = dlib.GetAll();
            if (domainList != null)
            {
                foreach (domains rec in domainList)
                    _domain.Add(new SelectListItem()
                    {
                        Text = rec.domainName,
                        Value = rec.domainId.ToString()
                    });
            }
            ret= new SelectList(_domain, "Value", "Text", null);
            return ret;
        }
    }
}