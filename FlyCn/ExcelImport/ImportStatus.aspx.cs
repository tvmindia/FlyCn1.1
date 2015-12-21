using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn.ExcelImport
{
    public partial class ImportStatus : System.Web.UI.Page
    {
        string statusId;
        //FlyCnDAL.ExcelImport exObj = new FlyCnDAL.ExcelImport();
        ImportFile exObj = new ImportFile();

        #region Page_Load()
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                statusId = Request.QueryString["statusId"];
                exObj.getExcelImportDetailsById(statusId);
                lbl_ProjNo1.Text = exObj.ProjectNo;
                lbl_FileName1.Text = exObj.FileName;
                lbl_TableName1.Text = exObj.TableName;
                lbl_TotalCount1.Text = Convert.ToString(exObj.TotalCount);
                lbl_StartTime1.Text = Convert.ToString(exObj.StartTime);
                lbl_InsertCount1.Text = Convert.ToString(exObj.InsertCount);
                lbl_UpdateCount1.Text = exObj.UpdateCount.ToString();
                lbl_ErrorCount1.Text = Convert.ToString(exObj.ErrorCount);
                lbl_LastUpdatedTime1.Text = Convert.ToString(exObj.LastUpdatedTime);
                lbl_UserName1.Text = exObj.UserName;
                lbl_InsertStatus1.Text = Convert.ToString(exObj.InsertStatus);
                lbl_Remarks1.Text =exObj.Remarks;
                if(lbl_Remarks1.Text=="")
                {
                    lbl_Remarks1.Text = "none";
                }
                lbl_TimeElapsed1.Text = exObj.TimeElapsed;
                lbl_TimeRemaining1.Text = exObj.TimeRemaining;
             }
        }
        #endregion Page_Load()

        #region UpdateTimer2_Tick()
        protected void UpdateTimer2_Tick(object sender, EventArgs e)
        {
            statusId = Request.QueryString["statusId"];
            exObj.getExcelImportDetailsById(statusId);
            lbl_TimeRemaining1.Text = exObj.TimeRemaining;
            lbl_InsertCount1.Text = Convert.ToString(exObj.InsertCount);
            lbl_ErrorCount1.Text = Convert.ToString(exObj.ErrorCount);
            lbl_LastUpdatedTime1.Text = Convert.ToString(exObj.LastUpdatedTime);
            lbl_TimeElapsed1.Text = exObj.TimeElapsed;
            lbl_UpdateCount1.Text = exObj.UpdateCount.ToString();
        }
        #endregion UpdateTimer2_Tick()
    }
}