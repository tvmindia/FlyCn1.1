using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using FlyCn.FlyCnDAL;
using System.Data;
using System.Configuration;
using System.Threading;
using SheetStatus = FlyCn.DocumentSettings.DocumentStatusSettings;
using System.IO;
namespace FlyCn.EngineeredDataList
{
    
    public partial class EnggDatalistBaseTable : System.Web.UI.Page
    {
        string _moduleId;
        string _TableName;
        string _ProjectNo;
        string _tree;
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        ImportFile importObj = new ImportFile();
        ValidationExcel validationObj = new ValidationExcel();
        CommonDAL comDAL = new CommonDAL();
        Modules moduleObj = new Modules();
        DataSet tempDS = null;
        DataSet dsTable = null;
        List<string> columnNames = new List<string>();
        List<string> ErrorRows = new List<string>();
        string currentSheet = null;
        bool columnExistCheck=false;
        ErrorHandling eObj = new ErrorHandling();
        protected void Page_Load(object sender, EventArgs e)
        {
                UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
                _moduleId = Request.QueryString["Id"];

              
                //RadTreeView node = new RadTreeView("rvleftmenu");
                //node.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
                //rvleftmenu.Nodes.Add(node);
                if (Request.QueryString["Id"] != null)
                {
                    moduleObj.ModuleID = Request.QueryString["Id"];
                    comDAL.GetTableDefinitionByModuleID(moduleObj.ModuleID);
                    DynamicSheet();
                    DisableButtonandGrid();//disables button and grid initially
                }
                //else 
                //{
                //    moduleObj.ModuleID = "ELE";
                //    comDAL.GetTableDefinitionByModuleID(moduleObj.ModuleID);
                    
                //}
               
                importObj.ProjectNo = UA.projectNo;
                importObj.UserName = UA.userName;
              

          
            if (_moduleId != null)
            {


                Modules moduleObj = new Modules();
                DataSet dsobj = new DataSet();
                dsobj = moduleObj.GetModule(_moduleId);
                lblModule.Text = dsobj.Tables[0].Rows[0]["ModuleDesc"].ToString();
                _TableName = dsobj.Tables[0].Rows[0]["BaseTable"].ToString();
                hdfTableName.Value = _TableName;
                DataSet ds = new DataSet();

                ds = moduleObj.GetModules();
                string  tabliFirst = "";
                tabliFirst = " <li style='width:80px;' >" + " <a href='EnggDataListLandingPage.aspx" + "'" + "'" + "'" + ">" + "<img" + " src=" + "'" +
                    ds.Tables[0].Rows[4]["ModuleIconURLsmall"].ToString() + "'" + ">" + "<p>" 
                    + "All" + "</p>" + "</a></li>";
                horizonaltab.Controls.Add(new LiteralControl(tabliFirst));
                string tabhtml = "";

                for (int f = 0; f < ds.Tables[0].Rows.Count; f++)
                {
                    tabhtml = " <li style='width:80px;' >" + " <a href='EnggDatalistBaseTable.aspx?Id=" + ds.Tables[0].Rows[f]["ModuleID"].ToString() + "'" + "'" + "'" + ">" + "<img" + " src=" + "'" + ds.Tables[0].Rows[f]["ModuleIconURLsmall"].ToString() + "'" + ">" + "<p>" + ds.Tables[0].Rows[f]["ModuleID"].ToString() + "</p>" + "</a></li>";

                    horizonaltab.Controls.Add(new LiteralControl(tabhtml));
                }

            }


        }

        

        protected void dtgUploadGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
           
        }

        protected void dtgUploadGrid_PreRender(object sender, EventArgs e)
        {
            dtgUploadGrid.MasterTableView.GetColumn("ProjectNo").Visible = false;
            dtgUploadGrid.MasterTableView.GetColumn("ExcelMustFields").Visible = false;
            dtgUploadGrid.MasterTableView.GetColumn("Field_DataType").Visible = false;
            dtgUploadGrid.MasterTableView.GetColumn("Key_Field").Visible = false;
            dtgUploadGrid.MasterTableView.GetColumn("Field_Name").Visible = false;
            
            
        }
        protected void dtgUploadGrid_ItemDataBound(object sender, GridItemEventArgs e)
        {
            //dtgUploadGrid.MasterTableView.GetColumn("PassWord").Visible = false;
            //((e.Item as GridDataItem)["ClientSelectColumn"].Controls[0] as CheckBox).Enabled = false;
            if (e.Item is GridDataItem) //Your condition goes here 
            {
                //((e.Item as GridDataItem)["ExcelMustFields"].Controls[0] as CheckBox).Enabled = false;

                GridDataItem item = e.Item as GridDataItem;
                if (item["ExcelMustFields"].Text == "Y")
                {
                    //string temp = (string)item["Field_Name"].Text;
                    //item.Display = false;
                    item.Enabled = false;
                }
              
            } 
        }
        
        protected void dtgUploadGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (_moduleId != null)
            {

                DataSet dsObj = new DataSet();
                CommonDAL cmDalObj = new CommonDAL();
                dsObj = cmDalObj.GetTableDefinition(_TableName);
                DataTable dtobj = new DataTable();
                dtobj = dsObj.Tables[0];
                dtgUploadGrid.DataSource = dtobj;
              
            }
        }
    
        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            //List<string> columnNames = new List<string>();
            //((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            /////bool checkHeader = true;
            //foreach (GridDataItem dataItem in dtgUploadGrid.MasterTableView.Items)
            //{
            //    if (!(dataItem.FindControl("CheckBox1") as CheckBox).Checked)
            //    {
            //       // checkHeader = false;
            //        columnNames.Add(dataItem["Field_Name"].Text);
            //        string temp = dataItem["Field_Name"].Text;
            //    }
            //}
            //ViewState["columnNamesVs"] = columnNames;
            //GridHeaderItem headerItem = dtgUploadGrid.MasterTableView.GetItems(GridItemType.Header)[0] as GridHeaderItem;
            //(headerItem.FindControl("headerChkbox") as CheckBox).Checked = checkHeader;
        }

        protected void btnExcelIimport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelTemplate eObj = new ExcelTemplate();
                eObj.GenerateExcelTemplate(UA.projectNo, _TableName);
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
               
            }
           
        }

        protected void dtgvalidationErros_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            GridErrorvalidateBind(validationObj.importfile.status_Id);
        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {

            importObj.TableName = comDAL.tableName;
            DataSet dsFile = null;
            // importObj.fileName = "file";
            try
            {
                if (DataImportFileUpload.HasFile)
                {
                    String[] excelSheets = null;
                    string path = Server.MapPath("~/Content/Fileupload/").ToString();
                    
                    string fileName = DataImportFileUpload.FileName.ToString();
                    hdfFileName.Value = fileName;
                    importObj.fileName = fileName;
                    string fileLocation = path + fileName;
                    importObj.fileLocation = fileLocation;
                    hdfFileLocation.Value = fileLocation;
                    string fileExtension = System.IO.Path.GetExtension(fileName);

                    int fileExtensionCheck=validationObj.ValidateFileExtension(fileExtension);
                    
                    if (fileExtensionCheck != 0)//&&(sheetname=="Electrical")
                    {
                        DeleteDuplicateFile(fileLocation);//deletes the file if the same file name exists in the folder
                        DataImportFileUpload.SaveAs(fileLocation);
                        excelSheets=importObj.OpenExcelFile();
                        if (excelSheets != null)
                        {
                            if (importObj.SheetName == currentSheet)
                            {
                                dsFile = new DataSet();
                                dsFile = importObj.ScanExcelFileToDS(excelSheets);
                                dsTable = comDAL.GetTableDefinition(comDAL.tableName);
                                columnExistCheck = validationObj.ValidateExcelDataStructure(dsFile, dsTable);
                                if (columnExistCheck == true)
                                {
                                   
                                    lblMsg.Text = "Successfully Uploaded!";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "Upload", "GenerateTemplateNextClick();", true);
                                    EnaableButtonandGrid();
                                    CheckBoxAllCheck();
                                    return;
                                }
                                if (columnExistCheck == false)
                                {
                                    DeleteDuplicateFile(fileLocation);
                                    lblMsg.Text = "Sheet does not have valid structure,Please Make sure..";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Upload", "GenerateTemplateNextClick();", true);
                                    return;//excel structrue not valid
                                }
                            }
                            else
                            {
                                lblMsg.Text = "Sheet Name is Invalid";
                                DeleteDuplicateFile(fileLocation);
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Upload", "GenerateTemplateNextClick();", true);
                                return;//invalid sheet name
                            }
                        }
                        else
                        {
                            lblMsg.Text = "Either sheet name or sheet description is missing";
                            DeleteDuplicateFile(fileLocation);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Upload", "GenerateTemplateNextClick();", true);
                            return;//invalid sheet name
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Please Upload file types of xlsx or xls";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Upload", "GenerateTemplateNextClick();", true);
                        return;//invalid file extension
                    }
                   
                    //importObj.temporaryFolder = path;
                   
                    //importObj.testFile = importObj.fileName;
                    //importObj.ExcelFileName = importObj.fileName;
                    //Thread excelImportThread = new Thread(new ThreadStart(importObj.ImportExcelFile));
                    //excelImportThread.Start();
                    //tempDS = new DataSet();
                    //tempDS=importObj.ImportExcelFile();
                    // if (tempDS.Tables[0].Rows.Count>0)
                    // {
                    //     ViewState["ExcelDS"] = tempDS;
                    // }
                    // tempDS = null;
                    // tempDS = (DataSet)ViewState["ExcelDS"];
                    //lblMsg.Text = "Thread started";
                }//end of hasfile if

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Upload", "GenerateTemplateNextClick();", true);

            }//end try
            catch (Exception ex)
            {
               // lblMsg.Text = ex.Message;
                throw ex;
            }
            finally
            {

            }       
        }

        public void DisableButtonandGrid()
        {
            dtgUploadGrid.Enabled = false;
            btnValidate.Enabled = false;

        }

        public void EnaableButtonandGrid()
        {
            dtgUploadGrid.Enabled = true;
            btnValidate.Enabled = true;

        }

        public bool DeleteDuplicateFile(string location)
        {
            if (System.IO.File.Exists(location))
            {
                try
                {
                    System.IO.File.Delete(location);
                    return true;
                }

                catch (Exception ex)
                {
                   // lblMsg.Text = "Problem while deleting previous file,Please try again!";
                    //importObj.importStatus = -1;
                    throw ex;
                }
            }
            else
            {
                return false;
            }
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {

            //Thread excelImportThread = new Thread(new ThreadStart(importObj.ImportExcelFile));
            //excelImportThread.Start();
            importObj.ExcelFileName = hdfFileName.Value;
            importObj.fileLocation = hdfFileLocation.Value;
            importObj.fileName = importObj.ExcelFileName;
            
           if(File.Exists(importObj.fileLocation))
            {
                try
                {
                    tempDS = new DataSet();
                    tempDS = importObj.ImportExcelFile();
                    CheckBoxColumns();//getting the fieldnames that has been uncheced
                    RemoveColumnFromDS(tempDS);
                    ValidateDataStructure(tempDS);
                    hdfstatusID.Value = validationObj.importfile.status_Id.ToString();
                    lblVupldFilename.Text = importObj.ExcelFileName;
                   
                    lblVErrorsCount.Text=validationObj.importfile.errorCount.ToString();
                    GridErrorvalidateBind(validationObj.importfile.status_Id);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Upload", "UploadNextClick();", true);
                 
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    
                }
                
           }
       }
        public void GridErrorvalidateBind(Guid _statusid)
        {//hdfErrorRow
            
            DataSet ds = new DataSet();
            if (_statusid != Guid.Empty)
            {
               
              
                ds = importObj.getErrorDetails(_statusid);
                dtgvalidationErros.DataSource = ds;
                string temp = "";

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //temp = temp + ds.Tables[0].Rows[0]["Key_Field"].ToString()+ "||";
                    temp = temp + dr["Key_Field"].ToString() + "|";
                }


                hdfErrorRow.Value = temp;
                
            }

            if (dtgvalidationErros.DataSource == null)
            {
                dtgvalidationErros.DataSource = new string[] { };
            }  
        }
        public void CheckBoxAllCheck()
        {
            GridHeaderItem headerItem = dtgUploadGrid.MasterTableView.GetItems(GridItemType.Header)[0] as GridHeaderItem;
            if (headerItem != null)
            {
                 bool checkHeader = true;
                foreach (GridDataItem dataItem in dtgUploadGrid.MasterTableView.Items)
                {
                    if (!(dataItem.FindControl("CheckBox1") as CheckBox).Checked)
                    {

                        (dataItem.FindControl("CheckBox1") as CheckBox).Checked = checkHeader;
                       // dataItem.Selected = headerCheckBox.Checked;
                    }
                }
            }
        }

        public void ValidateDataStructure(DataSet dsFile)
        {
            //hidddnef=validationObj.importfile.status_Id;
            dsTable = comDAL.GetTableDefinition(comDAL.tableName);
            for (int i = dsFile.Tables[0].Rows.Count - 1; i >= 0; i--)
            {
                int res;
                res=validationObj.excelDatasetValidation(dsFile.Tables[0].Rows[i], dsTable);
                if (res == -1)
                {
                    validationObj.importfile.errorCount = validationObj.importfile.errorCount + 1;
                    //errorCount = errorCount + 1;
                }
            }
        }

        public void CheckBoxColumns()
        {
          string temp="";
            GridHeaderItem headerItem = dtgUploadGrid.MasterTableView.GetItems(GridItemType.Header)[0] as GridHeaderItem;
            if(headerItem!=null)
            {
                foreach (GridDataItem dataItem in dtgUploadGrid.MasterTableView.Items)
                {
                    if (!(dataItem.FindControl("CheckBox1") as CheckBox).Checked)
                    {
                        // checkHeader = false;
                        columnNames.Add(dataItem["Field_Name"].Text);
                        temp = temp + dataItem["Field_Name"].Text + "|";
                    }
                }
                hdfremovedField.Value = temp;
            }
       }
        
       public void RemoveColumnFromDS(DataSet tempDS)
        {
            DataSet checkds = new DataSet();
            checkds = tempDS;
            if ((columnNames != null) && (checkds != null))
            {
              foreach (string str in columnNames)
               {
                 for (int i = checkds.Tables[0].Columns.Count - 1; i >= 0; i--)
                  {
                    DataColumn column = checkds.Tables[0].Columns[i];
                    if (column.ColumnName == str)
                     {
                       tempDS.Tables[0].Columns.Remove(str);
                       break;
                     }
                  } 
               }
            }
        }

       public void RemoveErrorRow(DataSet tempDS)
       {
           DataSet checkds = new DataSet();
           checkds = tempDS;
           DataSet dsTable = new DataSet();
           CommonDAL tblDef = new CommonDAL();
           dsTable = tblDef.GetTableDefinition(hdfTableName.Value);//temp table name
           DataRow[] keyFieldRow = dsTable.Tables[0].Select("Key_Field='Y'");
           if ((ErrorRows != null) && (checkds != null))
           {
               //foreach (string str in ErrorRows)
               //{
                
               //       for (int i = checkds.Tables[0].Rows.Count - 1; i >= 0; i--)

               //       {
               //         DataRow dr = checkds.Tables[0].Rows[i];
               //         string[] words = str.Split(',');
               //         if (dr["projectno"] ==str)
               //         {
               //             dr.Delete();
               //             break;
               //         }
               //       }
               //}
              
               for (int i = checkds.Tables[0].Rows.Count - 1; i >= 0; i--)
               {
                   string temp = "";
                   DataRow dr = checkds.Tables[0].Rows[i];
                   //temp = dr["ProjectNo"].ToString() + "," + dr["TagNo"].ToString();
                   foreach(DataRow drw in keyFieldRow)
                   {
                       temp = temp + dr[drw["Field_Name"].ToString()].ToString() + ","; //drw[""].ToString() + "," + dr["TagNo"].ToString();
                   }
                   temp = temp.TrimEnd(',');
                   if(ErrorRows.Contains(temp))
                   {
                       dr.Delete();
                   }
               }//end of for loop
               checkds.AcceptChanges();
           }
       }

        public void SplitString()
        {
             string temps="";
            if (hdfremovedField.Value != null)
            {
                try
                {
                    temps = hdfremovedField.Value;
                    temps = temps.TrimEnd('|');
                    string[] words = temps.Split('|');
                    columnNames = new List<string>(words.Length);
                    columnNames.AddRange(words);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            if(hdfErrorRow.Value!=null)
            {
                try
                {
                    temps = hdfErrorRow.Value;
                    temps = temps.TrimEnd('|');
                    string[] words = temps.Split('|');
                    ErrorRows = new List<string>(words.Length);
                    ErrorRows.AddRange(words);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                
            }
        }

        public void DynamicSheet()
       {
            switch(moduleObj.ModuleID)
            {
                case "CIV":
                    currentSheet = SheetStatus.CIV;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                    break;

                case "ELE":
                    currentSheet = SheetStatus.ELE;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                    break;
                case "CAD":
                    currentSheet = SheetStatus.CAD;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                    break;
                case "CTL":
                    currentSheet = SheetStatus.CTL;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                    break;
                case "INS":
                    currentSheet = SheetStatus.INS;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                    break;
                case "MEC":
                    currentSheet = SheetStatus.MEC;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                    break;
                case "PIP":
                    currentSheet = SheetStatus.PIP;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                    break;
                case "TEL":
                    currentSheet = SheetStatus.TEL;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                    break;

            }
       }

        protected void dtgvalidationErros_PreRender(object sender, EventArgs e)
        {
            dtgvalidationErros.Rebind();
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            importObj.ExcelFileName = hdfFileName.Value;
            importObj.fileLocation = hdfFileLocation.Value;
            importObj.fileName = importObj.ExcelFileName;
            tempDS = new DataSet();
            tempDS = importObj.ImportExcelFile();
            SplitString();
            RemoveColumnFromDS(tempDS);
            RemoveErrorRow(tempDS);
            

            //ValidateDataStructure(tempDS);
            importObj.TableName = comDAL.tableName;
            if (hdfstatusID.Value != null)
            {
                importObj.status_Id = Guid.Parse(hdfstatusID.Value);
            }
            importObj.InsertFile(tempDS);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Upload", "Import();", true);
        }
    }
}