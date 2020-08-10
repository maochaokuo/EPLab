﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EPLab.model
{
    public enum PAGE_STATUS
    {
        ADD = 2,
        EDIT = 1,
        SAVED = 0,
        ADDSAVED = -1,
        QUERY = -2,
        QUERYED = -3
    }
    public class ViewModelBase
    {
        public string cmd { get; set; }
        private string _errorMsg = "";
        public string errorMsg
        {
            get { return _errorMsg; }
            set
            {
                _errorMsg = value;
                _successMsg = "";
            }
        }
        private string _successMsg = "";
        public string successMsg
        {
            get { return _successMsg; }
            set
            {
                _successMsg = value;
                _errorMsg = "";
            }
        }
        public string singleSelect { get; set; }
        //public string multiSelect { get; set; } cannot use this column, must declared as hidden field and use request.form to receive
        public int pagesize { get; set; }
        public int pageindex { get; set; }
        private int _pageStatus = (int)PAGE_STATUS.SAVED;
        public int pageStatus
        {
            get
            {
                return _pageStatus;
            }
            set
            {
                _pageStatus = value;
            }
        }
        public ViewModelBase()
        {
            //pageStatus = PAGE_STATUS.SAVED;
        }
        public void clearMsg()
        {
            errorMsg = "";
            successMsg = "";
        }
    }
}
