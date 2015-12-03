using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn
{
    public partial class Fileupload : System.Web.UI.Page
    {
        public string file_name;
       // UpdatedExcelImport importObj = new UpdatedExcelImport();
       // Constants constantsObj = new Constants();
       // ExcelImportDetailsDAL exObj = new ExcelImportDetailsDAL();

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
           // importObj.tableName = constantsObj.TableName;
          //  importObj.fileName = "file";

          //  importObj.request = new HttpRequestWrapper(Request);
            string path = Server.MapPath("~/Content/").ToString();
            string location;
           // importObj.temporaryFolder = Server.MapPath("~/Content/").ToString();

            if (ExcelUploader.HasFile)
            {
                file_name = ExcelUploader.FileName.ToString();
             //   location = importObj.temporaryFolder + file_name;
                //if (System.IO.File.Exists(location))
                //{
                //    try
                //    {
                //        System.IO.File.Delete(location);
                //    }

                //    catch
                //    {
                //    //    importObj.errorMessage = "Please try again!";
                //     //   importObj.importStatus = -1;
                //        return;
                //    }
                //}
               // ExcelUploader.SaveAs(location);
              //  importObj.testFile = file_name;
              //  exObj.ExcelFileName = file_name;

            }

            //Thread excelImportThread = new Thread(new ThreadStart(importObj.ImportExcelFile));
            //excelImportThread.Start();
           // importObj.ImportExcelFile();
            lblMsg.Text = "Thread started";


        }
        #endregion btn_upload_Click

        #region GridView1_SelectedIndexChanged
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion GridView1_SelectedIndexChanged
    }
}