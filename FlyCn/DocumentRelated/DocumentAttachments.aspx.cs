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
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using DocStatus = FlyCn.DocumentSettings.DocumentStatusSettings;
namespace FlyCn.Approvels
{
    public partial class DocumentAttachments : System.Web.UI.Page
    {
        BOQHeaderDetails boqObj = new BOQHeaderDetails();
        BOQDetails detailsObj = new BOQDetails();
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
         public Guid Id;
         public string _RevisionID = "";
         public string _Type = "";
         public string ItemID;
         public string Status;
         public string DocOwner;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["RevisionId"] != null)
            {
                Status = Request.QueryString["Status"];
               _RevisionID = Request.QueryString["RevisionId"];
               _Type = Request.QueryString["type"];
               DocOwner = Request.QueryString["Owner"];
               if (Request.QueryString["ItemID"] != "undefined")
               {
                   ItemID = Request.QueryString["ItemID"];
               }
               else
               {
                   ItemID = "00000000-0000-0000-0000-000000000000";
               }
            }
            
            IdUc_FlyCnFileUpload.Id = 5;

            if (!IsPostBack)
            {
               
                if (Request.QueryString["RevisionId"] != null)
                {
                    _RevisionID = Request.QueryString["RevisionId"];
                    hdfRevisionID.Value = _RevisionID;
                    _Type = Request.QueryString["type"];
                    boqObj.Type = _Type;
                    Status = Request.QueryString["Status"];
                    hiddenStatusValue.Value = Status;
                    DocOwner = Request.QueryString["Owner"];
                    HiddenDocOwner.Value = DocOwner;
                    if (Request.QueryString["ItemID"] != "undefined")
                    {
                        ItemID = Request.QueryString["ItemID"];
                    }
                    else
                    {
                        ItemID = "00000000-0000-0000-0000-000000000000";
                    }
                    
                }
                BindData();
              //  GridView1.GridLines = GridLines.None;
               
            }
            hdfRevisionID.Value = _RevisionID;
            IdUc_FlyCnFileUpload.RevisionID = _RevisionID;
            hdfRevisionID.Value = _RevisionID;//////
           // string type_value = _Type;
            IdUc_FlyCnFileUpload.type_value = _Type;
            IdUc_FlyCnFileUpload.ItemID = ItemID;
            boqObj.Type = _Type;
            hiddenStatusValue.Value = Status;
            HiddenDocOwner.Value = DocOwner;
        }
    
        protected void btnsubmit_Click(object sender, EventArgs e)
        {

           
            
            IdUc_FlyCnFileUpload.FileInsert();
          
            Rebind();
            Label1.Text = "";
        }

        public void BindData()
        
        {

            DataSet ds = new DataSet();

            boqObj.RevisionID = hdfRevisionID.Value;
           // boqObj.Type = _Type;
            ds = boqObj.GetAllAttachment();
            int count = ds.Tables[0].Rows.Count;
         
            if(count==0)
            {
                Label1.Text = "No Attachments..!";
            }
            
            GridView1.DataSource = ds;
           
            try
            {
                GridView1.DataBind();
                GridView1.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                GridView1.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                GridView1.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                HideDelete();
            }
            catch (Exception)
            {

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
           // BOQHeaderDetails boqObj = new BOQHeaderDetails();
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

     
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        public void Rebind()
        {
            BindData();
        }
        public void HideDelete()
        {
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            string current_User = UA.userName;
           //Status = DocStatus.Draft;
            if (Status == "0" || Status == "3")
            {
                if ((current_User == DocOwner))
                {
                    GridView1.Columns[5].Visible = true;
                }
            
                else if ((current_User != DocOwner))
                {
                    GridView1.Columns[5].Visible = false;
                    IdUc_FlyCnFileUpload.Visible = false;
                    btnsubmit.Visible = false;
                }
            }
            else
            {
                GridView1.Columns[5].Visible = false;
                IdUc_FlyCnFileUpload.Visible = false;
                btnsubmit.Visible = false;
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Id = (Guid)GridView1.DataKeys[e.RowIndex].Value;
            boqObj.DeleteAttachmentDetails(Id);
            Rebind();
        }

        protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
           
        }
     
    }
}
