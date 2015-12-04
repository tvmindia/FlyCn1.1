using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn
{
    public partial class test1 : System.Web.UI.Page
    {
        public int url
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            url = Request.Url.Port;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string FileName = "E:\\Myfile.xlsx";
            string path = Server.MapPath("exportedfiles\\");
            ExcelTemplate etObj = new ExcelTemplate();
            etObj.GenerateExcelTemplate("C00001", "BASE_Electrical");
                string file = FileName + path;
          //     Response.TransmitFile(Server.MapPath(FileName));
       //     Response.End();


            //// CHECK IF THE FOLDER EXISTS.
            //if (Directory.Exists(path))
            //{
            //    // CHECK IF THE FILE EXISTS.
            //    if (File.Exists(path + "EmployeeDetails.xlsx"))
            //    {
            //        // SHOW (NOT DOWNLOAD) THE EXCEL FILE.
            //        Microsoft.Office.Interop.Excel.Application xlAppToView = new Microsoft.Office.Interop.Excel.Application();
            //        xlAppToView.Workbooks.Open(path + "EmployeeDetails.xlsx");
            //        xlAppToView.Visible = true;

            //    }
            //}


        }
    }
}
