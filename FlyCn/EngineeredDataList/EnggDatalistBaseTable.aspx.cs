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

namespace FlyCn.EngineeredDataList
{
    
    public partial class EnggDatalistBaseTable : System.Web.UI.Page
    {
        string _moduleId;
        string _TableName;
        string _ProjectNo;
       string _tree ;
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        ImportFile importObj = new ImportFile();
        ValidationExcel validationObj = new ValidationExcel();
        CommonDAL comDAL = new CommonDAL();
        Modules moduleObj = new Modules();
        DataSet tempDS = null;
        DataSet dsTable = null;
        List<string> columnNames = new List<string>();
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

                }
                else 
                {
                    moduleObj.ModuleID = "ELE";
                    comDAL.GetTableDefinitionByModuleID(moduleObj.ModuleID);
                    
                }
               
                importObj.ProjectNo = UA.projectNo;
                importObj.UserName = UA.userName;
              

          
            if (_moduleId != null)
            {


                Modules moduleObj = new Modules();
                DataSet dsobj = new DataSet();
                dsobj = moduleObj.GetModule(_moduleId);
                lblModule.Text = dsobj.Tables[0].Rows[0]["ModuleDesc"].ToString();
                _TableName = dsobj.Tables[0].Rows[0]["BaseTable"].ToString();

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
            ExcelTemplate eObj = new ExcelTemplate();
            eObj.GenerateExcelTemplate(UA.projectNo,_TableName);
        }

        protected void dtgvalidationErros_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            //DataTable dtObj = new DataTable();
            //ImportFile imlObj = new ImportFile();
            ////dtObj = imlObj.getErrorDetails();


            //dtgvalidationErros.DataSource = dtObj;
        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {

            importObj.TableName = comDAL.tableName;

            // importObj.fileName = "file";
            try
            {
                if (DataImportFileUpload.HasFile)
                {
                    string path = Server.MapPath("~/Content/Fileupload/").ToString();
                    
                    string fileName = DataImportFileUpload.FileName.ToString();
                    hdfFileName.Value = fileName;
                    string fileLocation = path + fileName;
                    hdfFileLocation.Value = fileLocation;
                    string fileExtension = System.IO.Path.GetExtension(fileName);

                    int fileExtensionCheck=validationObj.ValidateFileExtension(fileExtension);

                    if (fileExtensionCheck != 0)//&&(sheetname=="Electrical")
                    {
                        DeleteDuplicateFile(fileLocation);//deletes the file if the same file name exists in the folder
                        DataImportFileUpload.SaveAs(fileLocation);
                        importObj.OpenExcelFile();
                        if (importObj.SheetName == "Fields")
                        {
                            bool columnExistCheck = validationObj.ValidateExcelDataStructure(tempDS, dsTable);
                        }
                        else
                        {
                            return;//invalid sheet name
                        }
                    }
                    else
                    {
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
            tempDS = new DataSet();
            importObj.ExcelFileName = hdfFileName.Value;
            importObj.fileLocation = hdfFileLocation.Value;
            tempDS=importObj.ImportExcelFile();
            CheckBoxColumns();//getting the fieldnames that has been uncheced
            RemoveColumnFromDS(tempDS);
            dsTable = comDAL.GetTableDefinition(comDAL.tableName);
           // bool columnExistCheck = validationObj.ValidateExcelDataStructure(tempDS, dsTable);

        }


        public void CheckBoxColumns()
        {
          
            GridHeaderItem headerItem = dtgUploadGrid.MasterTableView.GetItems(GridItemType.Header)[0] as GridHeaderItem;
            if(headerItem!=null)
            {
                foreach (GridDataItem dataItem in dtgUploadGrid.MasterTableView.Items)
                {
                    if (!(dataItem.FindControl("CheckBox1") as CheckBox).Checked)
                    {
                        // checkHeader = false;
                        columnNames.Add(dataItem["Field_Name"].Text);
                        string temp = dataItem["Field_Name"].Text;
                    }
                }
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



    }
}