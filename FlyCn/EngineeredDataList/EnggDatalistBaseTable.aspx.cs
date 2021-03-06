﻿using System;
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
//using SheetStatus = FlyCn.DocumentSettings.DocumentStatusSettings;
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
        ErrorInformation ErrorInfoObj = new ErrorInformation();
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
                _moduleId = Request.QueryString["ID"];
                if(Request.QueryString["ID"]!="")
                {
                     hdfModuleID.Value = _moduleId;
                     Session["ModuleID"] = _moduleId;
                }
                
                //ViewState["ModuleID"] = _moduleId;
                //RadTreeView node = new RadTreeView("rvleftmenu");
                //node.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
                //rvleftmenu.Nodes.Add(node);
                if (Request.QueryString["Id"] != "")
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
         
            if (!string.Equals(_moduleId,""))
            {
                Modules moduleObj = new Modules();
                DataSet dsobj = new DataSet();
                dsobj = moduleObj.GetModule(_moduleId);
                if(dsobj.Tables[0].Rows.Count>0)
                {
                    lblModule.Text = dsobj.Tables[0].Rows[0]["ModuleDesc"].ToString();
                    _TableName = dsobj.Tables[0].Rows[0]["BaseTable"].ToString();
                    hdfTableName.Value = _TableName;
                    DataSet ds = new DataSet();
                    ds = moduleObj.GetModules(importObj.ProjectNo);
                    if((ds.Tables[0].Rows.Count>0)&&(ds!=null))
                    {
                       // string tabliFirst = "";
                        //tabliFirst = " <li style='width:80px;' >" + " <a href='EnggDataListLandingPage.aspx" + "'" + "'" + "'" + ">" + "<img" + " src=" + "'" +
                        //    ds.Tables[0].Rows[4]["ModuleIconURLsmall"].ToString() + "'" + ">" + "<p>"
                        //    + "All" + "</p>" + "</a></li>";
                        //horizonaltab.Controls.Add(new LiteralControl(tabliFirst));
                        string tabhtml = "";

                        for (int f = 0; f < ds.Tables[0].Rows.Count; f++)
                        {
                            tabhtml = " <li style='width:80px;' >" + " <a href='EnggDatalistBaseTable.aspx?Id=" + ds.Tables[0].Rows[f]["ModuleID"].ToString() + "'" + "'" + "'" + ">" + "<img" + " src=" + "'" + ds.Tables[0].Rows[f]["ModuleIconURLsmall"].ToString() + "'" + ">" + "<p>" + ds.Tables[0].Rows[f]["ModuleID"].ToString() + "</p>" + "</a></li>";

                            horizonaltab.Controls.Add(new LiteralControl(tabhtml));
                        }
                    }
                   
                }
               
            }
        }
      
        protected void dtgUploadGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
           
        }

       
        //protected void dtgUploadGrid_ItemCreated(object sender, GridItemEventArgs e)
        //{
        //    if (e.Item is GridDataItem) //Your condition goes here 
        //    {
        //        ((e.Item as GridDataItem)["ExcelMustFields"].Controls[0] as CheckBox).Enabled = false;

        //        GridDataItem item = e.Item as GridDataItem;
        //        if (item["ExcelMustFields"].Text == "Y")
        //        {
        //            item.Enabled = false;
        //            //string temp = (string)item["Field_Name"].Text;
        //            // item.Display = false;
        //            //filterImage.Attributes["disabled"] = "true";
        //        }
 
        //    }  
        //}
       
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
                      item.Enabled = false;
                    //string temp = (string)item["Field_Name"].Text;
                   // item.Display = false;
                   //filterImage.Attributes["disabled"] = "true";
                   
                }
              
            } 
        }
        protected void dtgUploadGrid_PreRender(object sender, EventArgs e)
        {
            //dtgUploadGrid.MasterTableView.GetColumn("ProjectNo").Visible = false;
            ////dtgUploadGrid.MasterTableView.GetColumn("ExcelMustFields").Visible = true;
            //dtgUploadGrid.MasterTableView.GetColumn("ExcelMustFields").HeaderText = "albert";
            //dtgUploadGrid.MasterTableView.GetColumn("Field_DataType").Visible = false;
            //dtgUploadGrid.MasterTableView.GetColumn("Key_Field").Visible = false;
            //dtgUploadGrid.MasterTableView.GetColumn("Field_Name").Visible = false;
            //dtgUploadGrid.MasterTableView.GetColumn("Ref_TableName").Visible = false;
            //dtgUploadGrid.MasterTableView.GetColumn("Ref_JoinField").Visible = false;
            //dtgUploadGrid.MasterTableView.GetColumn("Ref_SelectField").Visible = false;
            //dtgUploadGrid.Rebind();

        }
        protected void dtgUploadGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (_moduleId != null)
            {
               _TableName = hdfTableName.Value;
                if(_TableName != null)
                {
                    DataSet dsObj = new DataSet();
                    CommonDAL cmDalObj = new CommonDAL();
                    dsObj = cmDalObj.GetTableDefinition(_TableName);
                    DataTable dtobj = new DataTable();
                    dtobj = dsObj.Tables[0];
                    dtgUploadGrid.DataSource = dtobj;
                }
               
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
            GridErrorvalidateBind(importObj.status_Id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_upload_Click(object sender, EventArgs e)
        {

            importObj.TableName = comDAL.tableName;
            DataSet dsFile = null;
          
            try
            {
                if (DataImportFileUpload.HasFile)
                {
                    String[] excelSheets = null;
                    string path = Server.MapPath("~/Content/Fileupload/").ToString();

                    string fileName = UA.projectNo +"_"+ UA.userName + "_" + DataImportFileUpload.FileName.ToString();
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
                                dsTable = comDAL.GetTableDefinition(comDAL.tableName);
                                dsFile = importObj.ScanExcelFileToDS(excelSheets,dsTable);
                                columnExistCheck = validationObj.ValidateExcelDataStructure(dsFile, dsTable);
                                if (columnExistCheck == true)
                                {
                                    //SlideEffectUpload
                                    lblMsg.Text = "";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "Upload", "GenerateTemplateNextClick();", true);
                                    //ScriptManager.RegisterStartupScript(this, GetType(), "SlideEffect", "SlideEffectUpload();", true);
                                    ScriptManager.RegisterStartupScript(this, GetType(), "SlideEffect", "ShowGridButton();", true);
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
                   
                  
                }//end of hasfile if

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Upload", "GenerateTemplateNextClick();", true);

            }//end try
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {

            }       
        }

        public void DisableButtonandGrid()
        {
            dtgUploadGrid.Enabled = false;
          
            btnValidate.CssClass= "buttonValidateAndImport";
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
                    //lblMsg.Text = "Problem while deleting previous file,Please try again!";
                    //importObj.importStatus = -1;
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.ErrorData(ex, page);
                    throw ex;
                }
            }
            else
            {
                return false;
            }
        }

       
        public void GridErrorvalidateBind(Guid _statusid)
        {
            int errorCount,warningCount;
           
            if (_statusid != Guid.Empty)
            {
                DataSet ds = new DataSet();
                ds = ErrorInfoObj.getErrorDetails(_statusid.ToString());
                dtgvalidationErros.DataSource = ds;
                if(ds.Tables[0].Rows.Count>0)
                {
                   errorCount=ds.Tables[0].Select("IsError='TRUE'").Length;
                   warningCount = ds.Tables[0].Select("IsError='FALSE'").Length;
                   lblVErrorsCount.Text= errorCount.ToString();
                   lblwarningCount.Text = warningCount.ToString();
                   validationObj.ErrorInfoObj.ErrorCount = errorCount;
                   validationObj.ErrorInfoObj.WarningCount = warningCount;
                   string temp = "";
                   foreach (DataRow dr in ds.Tables[0].Rows)
                   {
                       if (dr["IsError"].ToString() == "True")
                       {
                           temp = temp + dr["Key_Field"].ToString() + "|";
                       }
                   }
                   hdfErrorRow.Value = temp;
                }
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
                    }
                }
            }
        }

        public void ValidateDataStructure(DataSet dsFile)
        {
            //hidddnef=validationObj.importfile.status_Id;
            DataSet MasterDS=null;
            CommonDAL tblDef = new CommonDAL();
            List<string> MasterColumns = new List<string>();
            MasterDS = tblDef.SelectAllMastersDataByTableName(comDAL.tableName, UA.projectNo);
            dsTable = comDAL.GetTableDefinition(comDAL.tableName);
            importObj.TotalCount = dsFile.Tables[0].Rows.Count;
            //validationObj.importfile.TotalCount = dsFile.Tables[0].Rows.Count;
            //validationObj.importfile.ErrorInfoObj.Status_ID = importObj.ErrorInfoObj.Status_ID;
            DataRow[] MasterFieldDetails = dsTable.Tables[0].Select("Ref_TableName IS NOT NULL");
            foreach (DataRow row in MasterFieldDetails)//storing master having columns
            {
                MasterColumns.Add(row["Field_Description"].ToString());//column 2 field descrption
            }
           
            dbConnection dbCon = new dbConnection();
            dbCon.GetDBConnection();
            for (int i = dsFile.Tables[0].Rows.Count-1; i >= 0; i--)
            {
                bool IsError = false;
                IsError = validationObj.excelDatasetValidation(dsFile.Tables[0].Rows[i], dsTable, i, dbCon);
                if(IsError!=true)
                {
                   IsError = validationObj.MasterDataExist(dsTable, MasterDS, dsFile.Tables[0].Rows[i], i+2, comDAL.tableName, MasterColumns, dbCon);
                   if (comDAL.ExcelSheetName == "Cables")
                   {
                       if(IsError != true)
                       {
                         IsError = validationObj.CableLengthValidation(dsFile.Tables[0].Rows[i], dsTable, i, dbCon);
                       }
                     if (IsError != true)
                     {
                         IsError = validationObj.DrumValidation(dsFile.Tables[0].Rows[i], dsTable, i, dbCon);
                     }
                   }
                }
                //if (IsError)
                //{
                //    //validationObj.importfile.errorCount = validationObj.importfile.errorCount + 1;
                //    //validationObj.importfile.errorCount = validationObj.importfile.errorCount - validationObj.importfile.WarningCount;

                //  //  validationObj.ErrorInfoObj.ErrorCount = validationObj.ErrorInfoObj.ErrorCount + 1;
                   
                //}
            }
            
             dbCon.DisconectDB();
        }

        public void CheckBoxColumns()
        {
          string temp=null;
            GridHeaderItem headerItem = dtgUploadGrid.MasterTableView.GetItems(GridItemType.Header)[0] as GridHeaderItem;
            if(headerItem!=null)
            {
                foreach (GridDataItem dataItem in dtgUploadGrid.MasterTableView.Items)
                {
                    if (!(dataItem.FindControl("CheckBox1") as CheckBox).Checked)
                    {
                        // checkHeader = false;Field_Description
                        //columnNames.Add(dataItem["Field_Name"].Text);
                        columnNames.Add(dataItem["Field_Description"].Text);
                        //temp = temp + dataItem["Field_Name"].Text + "|";
                        temp = temp + dataItem["Field_Description"].Text + "|";
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
                  if(str!="")
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
                 }//end of if
               }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempDS"></param>

       public void RemoveErrorRow(DataSet tempDS)
       {
           DataSet checkds = new DataSet();
           checkds = tempDS;
           DataSet dsTable = new DataSet();
           CommonDAL tblDef = new CommonDAL();
           dsTable = tblDef.GetTableDefinition(hdfTableName.Value);//temp table name
           DataRow[] keyFieldRow = dsTable.Tables[0].Select("Key_Field='Y'");
           if ((ErrorRows.Count >0) && (checkds != null))
           {
              for (int i = checkds.Tables[0].Rows.Count - 1; i >= 0; i--)
               {
                   string temp = "";
                   DataRow dr = checkds.Tables[0].Rows[i];
                   //temp = dr["ProjectNo"].ToString() + "," + dr["TagNo"].ToString();
                   foreach(DataRow drw in keyFieldRow)
                   {
                       temp = temp + dr[drw["Field_Description"].ToString()].ToString() + ","; //drw[""].ToString() + "," + dr["TagNo"].ToString();
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
        /// <summary>
        /// 
        /// </summary>
        public void GetUserSelectedFields()
        {
             string temps="";
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
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.ErrorData(ex, page);
                    throw ex;
                }
                        
        }
        /// <summary>
        /// 
        /// </summary>
       
        public void GetErrorRows()
        {
            string temps = "";
              try
                {
                    temps = hdfErrorRow.Value;
                    if (temps != "")
                    {
                        temps = temps.TrimEnd('|');
                        string[] words = temps.Split('|');
                        ErrorRows = new List<string>(words.Length);
                       for (int i = 0; i < words.Length; i++)
                        {
                            ErrorRows.Add(words[i].TrimEnd(','));
                        }
                    }

                }
                catch(Exception ex)
                {
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.ErrorData(ex, page);
                    throw ex;
                }
           
        }
        /// <summary>
        /// 
        /// </summary>
        public void DynamicSheet()
       {
            switch(moduleObj.ModuleID)
            {
                case "CIV":
                    comDAL.GetProcedureName(comDAL.tableName);
                    currentSheet = comDAL.ExcelSheetName;
                    //currentSheet = SheetStatus.CIV;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.expandnode();", true);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                    break;

                case "ELE":
                    comDAL.GetProcedureName(comDAL.tableName);
                    currentSheet =comDAL.ExcelSheetName;// SheetStatus.ELE;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.expandnode();", true);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                    break;
                case "CAD":
                    comDAL.GetProcedureName(comDAL.tableName);
                    currentSheet = comDAL.ExcelSheetName;
                    //currentSheet = SheetStatus.CAD;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.expandnode();", true);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                    break;
                case "CTL":
                    comDAL.GetProcedureName(comDAL.tableName);
                    currentSheet = comDAL.ExcelSheetName;
                    //currentSheet = SheetStatus.CTL;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.expandnode();", true);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                    break;
                case "INS":
                    comDAL.GetProcedureName(comDAL.tableName);
                    currentSheet = comDAL.ExcelSheetName;
                    //currentSheet = SheetStatus.INS;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.expandnode();", true);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                    break;
                case "MEC":
                    comDAL.GetProcedureName(comDAL.tableName);
                    currentSheet = comDAL.ExcelSheetName;
                    //currentSheet = SheetStatus.MEC;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.expandnode();", true);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                    break;
                case "PIP":
                    comDAL.GetProcedureName(comDAL.tableName);
                    currentSheet = comDAL.ExcelSheetName;
                    //currentSheet = SheetStatus.PIP;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.expandnode();", true);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                    break;
                case "TEL":
                    comDAL.GetProcedureName(comDAL.tableName);
                    currentSheet = comDAL.ExcelSheetName;
                    //currentSheet = SheetStatus.TEL;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.expandnode();", true);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
                    break;

            }
       }

        protected void dtgvalidationErros_PreRender(object sender, EventArgs e)
        {
            dtgvalidationErros.Rebind();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnNext_Click(object sender, EventArgs e)//btn validate
        {

            //Thread excelImportThread = new Thread(new ThreadStart(importObj.ImportExcelFile));
            //excelImportThread.Start();
            importObj = new ImportFile(Guid.NewGuid());
            importObj.ExcelFileName = hdfFileName.Value;
            importObj.fileLocation = hdfFileLocation.Value;
            importObj.fileName = importObj.ExcelFileName;
            validationObj.ErrorInfoObj.Status_ID = importObj.status_Id;
            /////
            //validationObj.importfile.ExcelFileName = hdfFileName.Value;
            //validationObj.importfile.fileLocation = hdfFileLocation.Value;
            //validationObj.importfile.fileName = validationObj.importfile.ExcelFileName;
            /////

            if (File.Exists(importObj.fileLocation))
            {
                try
                {
                    dsTable = comDAL.GetTableDefinition(comDAL.tableName);
                    tempDS = new DataSet();
                    tempDS = importObj.GetExcelData(dsTable);
                    CheckBoxColumns();//getting the fieldnames that has been unchecked
                    RemoveColumnFromDS(tempDS);
                    ValidateDataStructure(tempDS);
                    hdfstatusID.Value = validationObj.ErrorInfoObj.Status_ID.ToString();
                    lblVupldFilename.Text = importObj.fileName;
                    lblVtotltowcount.Text = importObj.TotalCount.ToString();
                    
                   // GridErrorvalidateBind(validationObj.importfile.status_Id);
                    GridErrorvalidateBind(validationObj.ErrorInfoObj.Status_ID);
                    //if(validationObj.importfile.errorCount==validationObj.importfile.TotalCount)
                    if (validationObj.ErrorInfoObj.ErrorCount == importObj.TotalCount)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(),"DisableImport","DisableImportButton();",true);
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Upload", "UploadNextClick();", true);
                }
                catch (Exception ex)
                {
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.ErrorData(ex, page);
                    throw ex;
                }
                finally
                {

                }

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnImport_Click(object sender, EventArgs e)
        {
            // validationObj.importfile
            try
            {
                importObj = new ImportFile(new Guid(hdfstatusID.Value));
                importObj.ExcelFileName = hdfFileName.Value;
                importObj.fileLocation = hdfFileLocation.Value;
                importObj.fileName = importObj.ExcelFileName;
                importObj.TableName = comDAL.tableName;
                if (hdfstatusID.Value != null)
                {
                    importObj.status_Id = Guid.Parse(hdfstatusID.Value);
                    validationObj.ErrorInfoObj.Status_ID = importObj.status_Id;
                    
                }
                importObj.ProjectNo = UA.projectNo;
                importObj.UserName = UA.userName;
                dsTable = comDAL.GetTableDefinition(comDAL.tableName);
                tempDS = new DataSet();
                tempDS = importObj.GetExcelData(dsTable);
                if (hdfremovedField.Value != null)
                {
                    GetUserSelectedFields();//results stored in 'columnNames' Global variable list
                    RemoveColumnFromDS(tempDS);
                }
                if (hdfErrorRow.Value != null)
                {
                    GetErrorRows();//results stored in 'ErrorRows'  Global variable list
                    RemoveErrorRow(tempDS);
                }
                if (tempDS.Tables[0].Rows.Count > 0)
                {

                    //new Thread(delegate()
                    //{
                    //    importObj.ImportExcelData(tempDS);
                    //}).Start();
                  importObj.ImportExcelData(tempDS);//<a href="../ExcelImport/ImportStatusList.aspx" target="_self" class="a">Click to see Import Status</a>
                }
                //ContentIframe.Attributes["src"] = "BOQDetails.aspx?Revisionid=" + Revisionid + "&QueryTimeStatus="+ QueryTimeStatus;
                ContentIframe.Attributes["src"] = "../ExcelImport/ImportStatus.aspx?StatusID=" + importObj.status_Id + "&ModuleName=" + importObj.SheetName;//iframe page ImportStatusList.aspx is called with query string revisonid and module name from excel sheet name
                hdfErrorRow.Value = "";
                hdfFileLocation.Value = "";
                hdfFileName.Value = "";
                hdfremovedField.Value = "";
                
                hdfTableName.Value = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Upload", "Import();", true);
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {
              
            }
        }

       
        protected void BtnDone_Click(object sender, EventArgs e)
        {
            //Guid statusid;
            //if((hdfstatusID.Value!=null)||(hdfstatusID.Value!=""))
            //{
                
            //   Guid.TryParse(hdfstatusID.Value, out statusid);
            //   ErrorInfoObj.Status_ID = statusid;
            //   ErrorInfoObj.DeleteExcelErrorDetails(hdfstatusID.Value);
            //}
           
        }

       
    }
}