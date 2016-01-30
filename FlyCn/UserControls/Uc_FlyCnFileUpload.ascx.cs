using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlyCn.FlyCnDAL;
using FlyCn.Approvels;
namespace Proj1
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
       dbConnection cntion=new dbConnection();
        SqlCommand cmd;
       
        SqlDataReader reader;
        DocumentAttachments boqObj = new DocumentAttachments();
       public int Id = 0;
       public string RevisionID
       {
           get;
           set;
       }
       public string type_value
       {
           get;
           set;
       }
       public string ItemID
       {
           get;
           set;
       }
        //TextBox DaTxtBox = this.Parent.FindControl("Some_Text_Box"); 
        //code for getting value from parent page(aspx) to useercontrol page
        FlyCn.UIClasses.Const Const = new FlyCn.UIClasses.Const();
        FlyCn.FlyCnDAL.Security.UserAuthendication UA;
        ErrorHandling eObj = new ErrorHandling();
        protected void Page_Load(object sender, EventArgs e)
        {
            UA = (FlyCn.FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            if ((IsPostBack == false))
            {
               
                //DropFill();
            }
            lblmsg.Text = "";
           // Guid RevId = boqObj.RevisionID;
           //string UserName= UA.userName;
            
        }
        /*  public void DropFill()
          {
              try
              {
                  cmd = new SqlCommand();
                  cmd.Connection = cntion.con;
                  cmd.CommandType = System.Data.CommandType.StoredProcedure;
                  cmd.CommandText = "[spGetAllImages]";
                  sda = new SqlDataAdapter();
                  ds = new DataSet();
                  sda.SelectCommand = cmd;
                  sda.Fill(ds);

                  IdDropDown.DataSource = ds;
                  IdDropDown.DataTextField = "Id";
                  IdDropDown.DataValueField = "Id";
                  IdDropDown.DataBind();
                  IdDropDown.Items.Insert(0, new ListItem("....Select...."));

              }
              catch (Exception ex)
              {
                  throw ex;
              }
              finally
              {

              }
          }*/
        public bool ValidateFileType()
        {
            bool isValidFile = false;
            string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg", "doc", "docx", "xls", "xlsx", "pdf" };
            string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
           
            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (ext == "." + validFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }
            }
            if (!isValidFile)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = "Invalid File. Please upload a File with extension " +
                               string.Join(",", validFileTypes);
            }
            return isValidFile;

        }
        public bool ValidateSize(int fileSize)
        {
            int size = 31457280;//30 mb in bytes
            bool largerSize = false;
            //float fileCal = fileSize / 1000000;//Converting byte into megabyte

            if (fileSize > size)
            {

                largerSize = true;
            }
            return largerSize;
        }

      

        public void FileInsert()
        {
            Control ctl = this.Parent;
            bool isValidFile = false;
            bool largerSize = false;
            try
            {
                //validation
                isValidFile = ValidateFileType();
                int Size = Convert.ToInt32(FileUpload1.PostedFile.ContentLength)/1024;
                int sizeinMB = Size / 1024;
                string fileSize;
                if (sizeinMB == 0)
                {
                     fileSize = Size + "KB";
                }
                else
                {
                    fileSize = sizeinMB + "MB";
}
                largerSize = ValidateSize(sizeinMB);
              
                if ((isValidFile) && (FileUpload1.PostedFile.ContentLength > 0))
                {
                    if (largerSize == false)
                    {
                        string tempFile = "";
                        string filePath = Server.MapPath("/Content/Fileupload/");
                        string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                        string fileName = FileUpload1.PostedFile.FileName;
                        string pathToCheck = filePath + fileName;
                        if(System.IO.File.Exists(pathToCheck))
                        {
                            int counter = 2;
                            while(System.IO.File.Exists(pathToCheck))
                            {
                                tempFile ="("+ counter.ToString()+")" + fileName;
                                pathToCheck = filePath + tempFile;
                                counter++;
                            }
                            fileName = tempFile;
                        }
                        filePath += fileName;
                        FileUpload1.SaveAs(filePath);
                        cmd = new SqlCommand();
                        cmd.Connection = cntion.GetDBConnection();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "[InsertDocAttachmentDetails]";
                        
                       // cmd.Parameters.Add("@paramId", SqlDbType.Int).Value = Id;
                        cmd.Parameters.Add("@Filename", SqlDbType.NVarChar, 100).Value = fileName.ToString();
                        cmd.Parameters.Add("@Image", SqlDbType.VarBinary).Value = FileUpload1.FileContent;
                        cmd.Parameters.Add("@Filetype", SqlDbType.NVarChar,5).Value = ext;
                        cmd.Parameters.Add("@Filesize", SqlDbType.NVarChar,50).Value = fileSize;
                        cmd.Parameters.Add("@Date",SqlDbType.SmallDateTime).Value=System.DateTime.Now;
                        cmd.Parameters.Add("@userName", SqlDbType.VarChar, 50).Value = UA.userName;
                        cmd.Parameters.Add("@Type",SqlDbType.VarChar,50).Value=type_value;
                        
                            cmd.Parameters.Add("@itemID", SqlDbType.UniqueIdentifier).Value = (Guid.Parse(ItemID) != Guid.Empty) ? Guid.Parse(ItemID) : Guid.Empty;
                      
                       
                        cmd.Parameters.Add("@RevisionID", SqlDbType.UniqueIdentifier).Value =Guid.Parse(RevisionID);
                        
                        SqlParameter ouparamid = cmd.Parameters.Add("@outparamid", SqlDbType.UniqueIdentifier);
                        ouparamid.Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
 

                        lblmsg.ForeColor = System.Drawing.Color.Green;
                        lblmsg.Text = "File uploaded successfully.";
                    }
                    else
                    {
                        if (largerSize == true)
                        {
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                            lblmsg.Text = "File should  be less than 10 mb of size";
                        }
                        if(FileUpload1.PostedFile.ContentLength == 0)
                        {
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                            lblmsg.Text = "File Does not have content..";
                        }
                    }

                }
                else
                {
                    if (isValidFile == false)
                    {
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                        lblmsg.Text = "Please Upload bmp,gif,png,jpg,jpeg,doc,docx,xls,xlsx,pdf file types";
                    }
                }

                //validation


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // DropFill();
                if (cntion.GetDBConnection() != null)
                {
                    cntion.GetDBConnection().Close();
                }
            }

        }



        /* protected void IdDropDown_SelectedIndexChanged(object sender, EventArgs e)
         {
             String fileName = null;
             if (IdDropDown.SelectedIndex != 0)
             {
                 try
                 {
                    
                     string filePath = null;
                     cmd = new SqlCommand();

                     cmd.Connection = cntion.con;
                     cmd.CommandType = System.Data.CommandType.StoredProcedure;
                     cmd.CommandText = "spGetImageById";
                     cmd.Parameters.Add("@paramId", SqlDbType.Int).Value = IdDropDown.SelectedValue;

                     reader = cmd.ExecuteReader();
                     filePath = Server.MapPath("/Pix/");


                     if (reader.HasRows)
                     {
                         if (reader.Read())
                         {
                             fileName = reader.GetString(1);
                             ValueHiddenField.Value = fileName;//hiddenvalue setting filename.jpg/pdf
                             if (reader.IsDBNull(1))
                             {
                                 lblmsg.Text = string.Format("{0} is unavailable.", fileName);

                             }
                             else
                             {
                                string ext = System.IO.Path.GetExtension(filePath + fileName);

                                 switch (ext)
                                 {
                                     case ".bmp":
                                     case ".gif":
                                     case ".png":
                                     case ".jpg":
                                     case ".jpeg":
                                                  MakeFile(reader,fileName,filePath);
                                                  Image1.ImageUrl = "~/Pix/" + fileName;
                                                 
                                                  idImageFullsize.ImageUrl = "~/Pix/" + fileName;
                                                 // Image1.Attributes.Add("onmouseover", "testmouseover();");
                                                 // Image1.Attributes.Add("onmouseout", "document.getElementById(" + idImageFullsize.ClientID+ ").style='display:normal';");
                                                  //Image1.Attributes.Add("onmouseout", "testmouseout();");
                                                  break;
                                    
                                     case ".doc": Image1.ImageUrl = "~/LogoFile/msworddoc.png";
                                                  idImageFullsize.ImageUrl = "";

                                         break;
                                     case ".docx": Image1.ImageUrl = "~/LogoFile/msworddocx.jpg";
                                                   idImageFullsize.ImageUrl = "";
                                         break;
                                     case ".xls": Image1.ImageUrl = "~/LogoFile/excelxls.png";
                                                  idImageFullsize.ImageUrl = "";
                                         break;
                                     case ".xlsx": Image1.ImageUrl = "~/LogoFile/Excelxlsxnew.png";
                                                   idImageFullsize.ImageUrl = "";
                                         break;
                                     case ".pdf": Image1.ImageUrl = "~/LogoFile/pdf-550x295.png";
                                                  idImageFullsize.ImageUrl = "";
                                         break;
                                     default:
                                         Image1.ImageUrl = "~/LogoFile/default2.jpg";
                                         break;

                                 }
                                 // Image1.ImageUrl = "~/Pix/" + photoName;
                                 txtImageId.Text = IdDropDown.SelectedValue;
                                 /*using (Bitmap productImage = new Bitmap(bytes.Stream))
                                 {
                                  * string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg", "doc", "docx", "xls", "xlsx", "pdf" };
                                     fileName = filePath + photoName;
                                     productImage.Save(fileName);
                                     lblmsg.Text = string.Format("Successfully created {0}.", fileName);
                                     Image1.ImageUrl = "~/Pix/" + photoName;
                                 }

                             }

                         }
                     }
                     else
                     {
                         Console.WriteLine("");
                         lblmsg.Text = string.Format("No records returned.");
                     }

                 }
                 catch (Exception ex)
                 {
                     throw ex;
                 }
                 finally
                 {

                     /*  if (fileName != null)//deleteing the file
                       {
                           if((System.IO.File.Exists(fileName)))
                           {
                             System.IO.File.Delete(fileName);
                           }
                       }*/
        /*  if (reader != null)
          {
              cntion.con.Close();
              reader.Dispose();

          }

      }
  }
  else
  {
      txtImageId.Text = "";
      Image1.ImageUrl = "~/LogoFile/default2.jpg";
      lblmsg.Text = "";
  }

}*/

        public void MakeFile(SqlDataReader reader, string fileName, string filePath)
        {
           byte[] buffer = new byte[reader.GetBytes(reader.GetOrdinal("BinaryFile"), 0, null, 0, int.MaxValue)];
            reader.GetBytes(reader.GetOrdinal("BinaryFile"), 0, buffer, 0, int.MaxValue);

            System.IO.File.WriteAllBytes(filePath + fileName, buffer);
           /* SqlDataAdapter sda;
            DataTable dt;
            try
            {
                cmd = new SqlCommand();

                cmd.Connection = cntion.con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "spGetImageById";
                cmd.Parameters.Add("@paramId", SqlDbType.Int).Value = 5;
                sda = new SqlDataAdapter();
                dt = new DataTable();
                reader.Dispose();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                
                byte[] buffer;
                buffer = (byte[])dt.Rows[0]["BinaryFile"];
                System.IO.File.WriteAllBytes(filePath + fileName, buffer);
               
            }
            catch(Exception ex)
            {
                throw ex;
            }*/





        }
        public void Download(string fileName, string filePath)
        {
            try
            {
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                Response.TransmitFile(filePath + fileName);
                Response.End();
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
             
               
            }
        }

        protected void lnkbtndownload_Click(object sender, EventArgs e)
        {
           // object DaTxtBox = this.Parent.FindControl("txtid");
            
            FileDownload(Id);
        }

      
        public void FileDownload(int Id)
        {
            if(Id!=0)
            {
                string filePath = Server.MapPath("/Content/Fileupload/");
                string fileName = "";

                try
                {

                    cmd = new SqlCommand();
                    cmd.Connection = cntion.GetDBConnection();;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spGetImageById";
                    cmd.Parameters.Add("@paramId", SqlDbType.Int).Value = Id;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            fileName = reader.GetString(1);

                            string ext = System.IO.Path.GetExtension(filePath + fileName);

                            
                                    MakeFile(reader, fileName, filePath);
                                    Download(fileName, filePath);
                                
                        }
                    }//reader
                }

                catch (Exception ex)
                {
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.ErrorData(ex, page);
                   
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
           

        

    

