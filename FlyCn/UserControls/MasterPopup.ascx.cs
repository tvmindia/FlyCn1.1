using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn.UserControls
{
    public partial class MasterPopup : System.Web.UI.UserControl
    {
        #region Public Properties

        /// <summary>
        /// Table name property
        /// </summary>
        public string tableName
        {
            get;
            set;
        }

        /// <summary>
        /// Text field property holds name like bank name
        /// </summary>
        public string textField
        {
            get;
            set;

        }

        /// <summary>
        /// Value field property holds code like bankcode
        /// </summary>
        public string valueField
        {
            get;
            set;
        }

        /// <summary>
        /// Div name property
        /// </summary>
        public string divName
        {
            get;
            set;
        }

        /// <summary>
        /// Code Header Property(gridview column 1)
        /// </summary>
        public string codeHeader
        {
            get;
            set;
        }

        /// <summary>
        /// Name Header Property(gridview column 2)
        /// </summary>
        public string nameHeader
        {
            get;
            set;
        }

        public string selectedRowCode
        {
            get;
            set;
        }



        #endregion Public Properties


        protected void Page_Load(object sender, EventArgs e)
        {
            btnGo.Attributes.Add("onclick", "return " + ClientID + "_ChangeDivposition();");
            lblDivName.Text = divName;
           
        }
    }
}