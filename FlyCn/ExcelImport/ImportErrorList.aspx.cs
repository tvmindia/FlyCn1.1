#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using FlyCn.FlyCnDAL;
#endregion Namespaces

namespace FlyCn.ExcelImport
{
    public partial class ImportErrorList : System.Web.UI.Page
    {

        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        string moduleID = "";
        string StatusId = "";
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {

            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            if(Request.QueryString["Id"]!=null)
            {
                moduleID = Request.QueryString["Id"];
            }
            else
            {
                moduleID = "";
            }
           
            if(!IsPostBack)
            {
                if ((moduleID != null) || (moduleID != ""))
                {
                    BindData();
                }
            
            }
        }
        #endregion Page_Load

        #region BindData()
        public void BindData()
        {
           
            try
            {
                DataSet ds = new DataSet();
                ErrorInformation errInfoObj = new ErrorInformation();
                ds = errInfoObj.GetAllErrorDetails(UA.userName,UA.projectNo);
                RadGrid1_ErrorList.DataSource = ds;
            }
            catch (Exception ex)
            {
               
            }
            
        }
        #endregion BindData()

        #region RadGrid1_ItemCommand
        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    GridDataItem item = e.Item as GridDataItem;
                    StatusId = item.GetDataKeyValue("Status_ID").ToString();
                    Divtab1.Style.Add("display", "none");
                    BindErrorDetails(StatusId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion RadGrid1_ItemCommand

        #region BindErrorDetails()
        public void BindErrorDetails(string StatusId)
        {
            try
            {
                if (StatusId != null)
                {
                    if (StatusId != "")
                    {
                        DataSet ds = new DataSet();
                        ErrorInformation errInfoObj = new ErrorInformation();
                        ds = errInfoObj.getErrorDetails(StatusId);
                        RadGrid1_ErrorDetails.DataSource = ds;
                    }
                   
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion BindErrorDetails()

        protected void RadGrid1_ErrorList_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                ImageButton link = (ImageButton)item["EditData"].Controls[0];
                int index = e.Item.ItemIndex;
                link.Attributes.Add("onclick", "RadGrid1_ErrorList_ItemCommandClient();");
            }
        }

        protected void RadGrid1_ErrorDetails_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
          
                BindErrorDetails(StatusId);
            
           
        }

        protected void RadGrid1_ErrorDetails_PreRender(object sender, EventArgs e)
        {
            RadGrid1_ErrorDetails.Rebind();
        }

      

        
    }
}