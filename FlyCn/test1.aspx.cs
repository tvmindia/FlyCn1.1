using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlyCn.FlyCnDAL;
using System.Data.SqlClient;
using System.Data;

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

        protected void btn_ExcelMail_Click(object sender, EventArgs e)
        {
            string StatusID = "4cd93ccc-7c83-4ca7-8641-3cea4b30d3d3";
            MailSending MailObj = new MailSending();
            //FlyCnDAL.ExcelImport detailsObj = new FlyCnDAL.ExcelImport();
            ImportFile detailsObj = new ImportFile();
            DataSet ds = new DataSet();
           
            ds=detailsObj.getExcelImportDetailsById(StatusID);
            
           
                MailObj.SendExcelImportMail(StatusID, detailsObj.UserName);
            
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            ExcelTemplate eObj = new ExcelTemplate();
            eObj.GenerateExcelTemplate("C00001","BASE_Electrical");
        }
       
        
    }
}