using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using FlyCn.FlyCnDAL;

namespace FlyCn.ExcelImport
{
    public partial class ImportErrorDetails : System.Web.UI.Page
    {
        string StatusId = "";
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["StatusId"] != null)
            {
                StatusId = Request.QueryString["StatusId"];
            }
            if(!IsPostBack)
            {
                BindData();
            }

        }
        #endregion Page_Load

        #region BindData()
        public void BindData()
        {
          try
            {
                if (StatusId != null)
                {
                    DataSet ds = new DataSet();
                    ErrorInformation errInfoObj = new ErrorInformation();
                    ds = errInfoObj.getErrorDetails(StatusId);
                    RadGrid1_ErrorDetails.DataSource = ds;
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion BindData()
    }
}