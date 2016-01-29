using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlyCn.FlyCnDAL;
namespace FlyCn
{
    public partial class Fileupload : System.Web.UI.Page
    {
        public string file_name;
        
       //Constants constantsObj = new Constants();
       // ExcelImportDetailsDAL exObj = new ExcelImportDetailsDAL();
        ImportFile importObj = new ImportFile();
        CommonDAL comDAL = new CommonDAL();
        Modules moduleObj = new Modules();
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];

            //if (Request.QueryString["ModuleID"] != null)
            //{
            //    moduleObj.ModuleID = Request.QueryString["ModuleID"];
            //    comDAL.GetTableDefinitionByModuleID(moduleObj.ModuleID);
               
            //}
            moduleObj.ModuleID = "ELE";
            importObj.ProjectNo = "C00001";//UA.projectNo;
            importObj.UserName = "albert";//UA.userName;
            comDAL.GetTableDefinitionByModuleID(moduleObj.ModuleID);
           
        }
        #endregion Page_Load

        #region Link_btn_ShowDetail_Click
        protected void Link_btn_ShowDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImportDetails.aspx");
        }
        #endregion Link_btn_ShowDetail_Click

        #region btn_upload_Click
        protected void btn_upload_Click(object sender, EventArgs e)
        {



            importObj.TableName = comDAL.tableName;
            
           // importObj.fileName = "file";
         
           
           
          try
          {
             if (ExcelUploader.HasFile)
             {
               string path = Server.MapPath("~/Content/Fileupload/").ToString();
               importObj.fileName = ExcelUploader.FileName.ToString();
               importObj.fileLocation = path + importObj.fileName;
               importObj.temporaryFolder = path;
               DeleteDuplicateFile(importObj.fileLocation);//deletes the file if the same file name exists in the folder
               ExcelUploader.SaveAs(importObj.fileLocation);
               importObj.testFile = importObj.fileName;
               importObj.ExcelFileName = importObj.fileName;
               //Thread excelImportThread = new Thread(new ThreadStart(importObj.ImportExcelFile));
               //excelImportThread.Start();
               importObj.GetExcelData();
               lblMsg.Text = "Thread started";
             }//end of hasfile if
          }//end try
          catch (Exception ex)
          {
            lblMsg.Text = ex.Message;
            throw ex;
          }
         finally
          {

          }       
       }

        #endregion btn_upload_Click


        public bool DeleteDuplicateFile(string location)
        {
            if (System.IO.File.Exists(location))
             {
              try
                {
                  System.IO.File.Delete(location);
                  return true;
                }
         
                catch(Exception ex)
                {
                    lblMsg.Text = "Problem while deleting previous file,Please try again!";
                    //importObj.importStatus = -1;
                    throw ex;
                }
             }
             else
             {
                return false;
             }
        }

        #region GridView1_SelectedIndexChanged
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion GridView1_SelectedIndexChanged
    }
}