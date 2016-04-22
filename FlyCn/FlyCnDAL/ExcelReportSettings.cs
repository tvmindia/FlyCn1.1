using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyCn.FlyCnDAL
{
    public class ExcelReportSettings
    {
        #region Properties
        public string reportHeader
        {
            get;
            set;
        }
        public string reportLogo
        {
            get;
            set;
        }
        public string reportGeneratedBy
        {
            get;
            set;
        }
        public DateTime isGeneratedDateRequired
        {
            get;
            set;
        }
        public string orientation
        {
            get;
            set;
        }
        public string printSize
        {
            get;
            set;
        }
        public string isClientDateRequired
        {
            get;
            set;
        }
        #endregion Properties

        #region GenerateReport
        public void GenerateReport()
        {

        }
        #endregion GenerateReport
    }
}