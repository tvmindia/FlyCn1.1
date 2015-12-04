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
        

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {

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
         
            string path = Server.MapPath("~/Content/Fileupload/").ToString();
            string location="";
          try
          {
             if (ExcelUploader.HasFile)
             {
               file_name = ExcelUploader.FileName.ToString();
               location = path + file_name;
               DeleteDuplicateFile(location);//deletes the file if the same file name exists in the folder
               ExcelUploader.SaveAs(location);
        
               //Thread excelImportThread = new Thread(new ThreadStart(importObj.ImportExcelFile));
               //excelImportThread.Start();
               importObj.ImportExcelFile();
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