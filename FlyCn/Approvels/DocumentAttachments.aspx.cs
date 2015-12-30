using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FlyCn.FlyCnDAL;
using System.Data;
using System.Data.SqlClient;
using Proj1;
namespace FlyCn.Approvels
{
    public partial class DocumentAttachments : System.Web.UI.Page
    {
        BOQHeaderDetails boqObj = new BOQHeaderDetails();
         public Guid Id;
         public string _RevisionID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["RevisionId"] != null)
            {
               _RevisionID = Request.QueryString["RevisionId"];
                
            }
            IdUc_FlyCnFileUpload.Id = 5;
            if (!IsPostBack)
            {
                if (Request.QueryString["RevisionId"] != null)
                {
                    _RevisionID = Request.QueryString["RevisionId"];
                    hdfRevisionID.Value = _RevisionID;
                }
                BindData();
                GridView1.GridLines = GridLines.None;
               
            }
            hdfRevisionID.Value = _RevisionID;
            IdUc_FlyCnFileUpload.RevisionID = _RevisionID;
            hdfRevisionID.Value = _RevisionID;//////
            
        }
    
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            IdUc_FlyCnFileUpload.FileInsert();
        }

        public void BindData()
        
        {
            DataSet ds = new DataSet();
            BOQHeaderDetails boqObj = new BOQHeaderDetails();
            boqObj.RevisionID = hdfRevisionID.Value;
            ds = boqObj.GetAllAttachment();
            GridView1.DataSource = ds;
        //  Id =Guid.Parse(GridView1.SelectedRow.Cells[0].Text);
         //   Id =(Guid)ds.Tables[0].Rows[0]["ImageID"];
            try
            {
                GridView1.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            BOQHeaderDetails boqObj = new BOQHeaderDetails();
            boqObj.RevisionID = hdfRevisionID.Value;
            ds = boqObj.GetAllAttachment();
            //Id = (Guid)ds.Tables[0].Rows[0]["ImageID"];
            Id = (Guid)GridView1.SelectedDataKey.Value;
            FileDownload(Id);

        }

        public void Download(string fileName, string filePath)
        {
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.TransmitFile(filePath + fileName);
           // Response.End();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public void MakeFile(SqlDataReader reader, string fileName, string filePath)
        {
            byte[] buffer = new byte[reader.GetBytes(reader.GetOrdinal("Image"), 0, null, 0, int.MaxValue)];
            reader.GetBytes(reader.GetOrdinal("Image"), 0, buffer, 0, int.MaxValue);

            System.IO.File.WriteAllBytes(filePath + fileName, buffer);
        }
        public void FileDownload(Guid Id)
        {
            dbConnection cntion = new dbConnection();
            SqlCommand cmd;
            SqlDataReader reader = null;
            
            if (Id != Guid.Empty)
            {
                string filePath = Server.MapPath("/Pix/");
                string fileName = "";
                
                
                try
                {

                    cmd = new SqlCommand();
                    cmd.Connection = cntion.GetDBConnection(); ;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spGetImageById";
                    cmd.Parameters.Add("@paramId", SqlDbType.UniqueIdentifier).Value =Id;
                    reader = cmd.ExecuteReader();
                   
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            fileName =reader.GetString(2);
                            DALConstants constObj = new DALConstants();
                            constObj.Extensions.Replace(",","");
                            string ext = System.IO.Path.GetExtension(filePath + fileName);
                            MakeFile(reader, fileName, filePath);
                            Download(fileName, filePath);
                            
                             } 
                           }//reader
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    reader.Dispose();
                    cntion.GetDBConnection().Close();
                }

            }

        }
    }
}