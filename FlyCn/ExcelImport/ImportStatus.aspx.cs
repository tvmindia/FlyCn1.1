using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImportStatusSetting = FlyCn.DocumentSettings.DocumentStatusSettings;
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
                if (Request.QueryString["ModuleName"] != null)
                {
                    exObj.TableName = Request.QueryString["ModuleName"];
                

                }
                lbl_FileName1.Text = exObj.FileName;

                lblModuleName.Text = (exObj.TableName != null) ? exObj.TableName : exObj.TableName;
              
                lbl_TotalRecords1.Text = Convert.ToString(exObj.TotalCount);
                lbl_InsertRecords1.Text = Convert.ToString(exObj.InsertCount);
                lbl_UpdateRecords1.Text = exObj.UpdateCount.ToString();
                lbl_ErrorCount1.Text = Convert.ToString(exObj.ErrorCount);
                ImportStatusSet(exObj.InsertStatus);
                lbl_StartTime1.Text = Convert.ToString(exObj.StartTime);
                lbl_TimeElapsed1.Text = exObj.TimeElapsed;
                lbl_TimeRemaining1.Text = exObj.TimeRemaining;
                lbl_LastUpdatedTime1.Text = Convert.ToString(exObj.LastUpdatedTime);
                lbl_UserName1.Text = exObj.UserName;
                lbl_Remarks1.Text = (exObj.Remarks.Trim() != "") ? exObj.Remarks.Trim() : "None";
                           
             }
        }
        #endregion Page_Load()
       

        #region UpdateTimer2_Tick()
        protected void UpdateTimer2_Tick(object sender, EventArgs e)
        {
            statusId = Request.QueryString["statusId"];
            exObj.getExcelImportDetailsById(statusId);
            lbl_TimeRemaining1.Text = exObj.TimeRemaining;
            ImportStatusSet(exObj.InsertStatus);
            switch(exObj.InsertStatus)
            {
                case 1:
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CallParent", "CallParentJs(1);", true);
                    break;
                case 2:
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CallParent", "CallParentJs(2);", true);
                    break;
                case 3:
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CallParent", "CallParentJs(3);", true);
                    Timer4.Enabled = false;//stops timer when status becomes finished ie:3
                    break;
            }
            lbl_InsertRecords1.Text = Convert.ToString(exObj.InsertCount);
            lbl_ErrorCount1.Text = Convert.ToString(exObj.ErrorCount);
            lbl_LastUpdatedTime1.Text = Convert.ToString(exObj.LastUpdatedTime);
            lbl_TimeElapsed1.Text = exObj.TimeElapsed;
            lbl_UpdateRecords1.Text = exObj.UpdateCount.ToString();
          
        }
        #endregion UpdateTimer2_Tick()

        #region ImportStatusSet
        public void ImportStatusSet(int stat)
        {
            switch (stat)
            {
                case 1:
                    lbl_InsertStatus1.Text = ImportStatusSetting.One;
                    break;
                case 2:
                    lbl_InsertStatus1.Text = ImportStatusSetting.Two;
                    break;
                case 3:
                    lbl_InsertStatus1.Text = ImportStatusSetting.Three;
                    break;
            }

        }
        #endregion ImportStatusSet
    }
}