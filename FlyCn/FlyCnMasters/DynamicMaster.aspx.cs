﻿using FlyCn.FlyCnDAL;
using FlyCn.UIClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.FlyCnMasters
{
    public partial class DynamicMaster : System.Web.UI.Page
    {
        string _mode;
        //  string _rowId;

        TabAddEditSettings tabs = new TabAddEditSettings();
        ErrorHandling eObj = new ErrorHandling();
        DataTable datatableobj = new DataTable();
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        FlyCnDAL.SystemDefenitionDetails systabledefenitionobj = new FlyCnDAL.SystemDefenitionDetails();
        FlyCnDAL.MasterOperations dynamicmasteroperationobj = new FlyCnDAL.MasterOperations();
        FlyCnDAL.Users userObj = new FlyCnDAL.Users();
        #region  Page_Load
       
        protected void Page_Load(object sender, EventArgs e)
        {
            SecurityCheck();

            //--------------------------------------------------------
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
            //---------------------------------------------------------

            PlaceControls();
            eObj.ClearMessage(this);
          
        }

        #endregion  Page_Load

        #region  ToolBar_onClick

        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;
            if (functionName == "Save")
            {


                InsertData();
            }
            else if (functionName == "Update")
            {
                UpdateData();
            }
            else if (functionName == "Delete")
            {
                string primarykeys = HiddenField.Value;
                string KeyValue = HiddenField1.Value;
                int checkProjectNo = userObj.ValidateProjectNoInMastersTable();
                if (checkProjectNo == 0)
                {
                    int result = dynamicmasteroperationobj.DeleteMasterData(primarykeys, _mode, KeyValue);
                    if (result == 1)
                    {
                        dtgDynamicMasterGrid.Rebind();
                        RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                        RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
                        TabAddEditSettings tabs = new TabAddEditSettings();
                        tabs.Addtab(tab, tab1);
                        RadMultiPage1.SelectedIndex = 0;

                    }
                }
            }

        }

        #endregion  ToolBar_onClick

        #region SecurityCheck
        public void SecurityCheck()
        {
            string logicalObject = "DynamicMaster";

            FlyCnDAL.Security.PageSecurity PS = new Security.PageSecurity(logicalObject, this);

            if (PS.isWrite == true)
            {
                dtgDynamicMasterGrid.MasterTableView.GetColumn("ViewDetailColumn").Display = false;
                dtgDynamicMasterGrid.MasterTableView.GetColumn("Delete").Display = false;
            }
            else
                if (PS.isEdit == true)
                {
                    dtgDynamicMasterGrid.MasterTableView.GetColumn("ViewDetailColumn").Display = false;
                    dtgDynamicMasterGrid.MasterTableView.GetColumn("Delete").Display = false;
                }
                else if (PS.isAdd == true)
                {
                    dtgDynamicMasterGrid.MasterTableView.GetColumn("EditData").Display = false;
                }
                else if (PS.isRead == true)
                {
                    dtgDynamicMasterGrid.MasterTableView.GetColumn("ViewDetailColumn").Display = true;
                    dtgDynamicMasterGrid.MasterTableView.GetColumn("EditData").Display = false;
                    dtgDynamicMasterGrid.MasterTableView.GetColumn("Delete").Display = false;
                }

                else if (PS.isDenied == true)
                {
                    HttpContext.Current.Response.Redirect("~/General/UnderConstruction.aspx?cause=accessdenied", true);
                }
            if (PS.isDelete == true)
            {
                dtgDynamicMasterGrid.MasterTableView.GetColumn("Delete").Display = true;
            }

        }
        #endregion SecurityCheck

        #region  PlaceControls

        public void PlaceControls()
        {
            {
                //HtmlGenericControl divcontrol = new HtmlGenericControl();
                //divcontrol.Attributes["class"] = "col-md-12 Span-One col-md-6 form-group";
                //divcontrol.TagName = "div";
                Table table = new Table();
                StringBuilder html = new StringBuilder();
                datatableobj = systabledefenitionobj.GetComboBoxDetails(_mode);
                lblmasterName.Text = datatableobj.Rows[0]["Table_Description"].ToString();
                int totalrows = datatableobj.Rows.Count;
                if (totalrows < 6)//------if no of rows less than 6 place all controls in one side
                {
                    for (int f = 0; f < datatableobj.Rows.Count; f++)
                    {

                        TableRow row = new TableRow();
                        TableCell cell = new TableCell();
                        TableCell cell1 = new TableCell();
                        Label lbl = new Label();
                        lbl.Attributes.Add("class", "control-label col-md-3");

                        lbl.Text = datatableobj.Rows[f]["Field_Name"].ToString();
                        TextBox box = new TextBox();
                        box.Attributes.Add("class", "form-control");
                        box.ID = "txt" + datatableobj.Rows[f]["Field_Name"].ToString();

                       
                       
                        CheckBox checkbox = new CheckBox();
                        checkbox.ID = "chk" + datatableobj.Rows[f]["Field_Name"].ToString();
                        checkbox.Text = "chk" + datatableobj.Rows[f]["Field_Name"].ToString();
                       // CheckBoxList chkCheckbox = new CheckBoxList();
                       
                       
                        if (datatableobj.Rows[f]["Field_DataType"].ToString() == "B")
                        {
                            cell.Controls.Add(lbl);
                            cell1.Controls.Add(checkbox);
                            row.Cells.Add(cell);
                            row.Cells.Add(cell1);
                        }
                        else if (datatableobj.Rows[f]["Field_DataType"].ToString() == "S" | datatableobj.Rows[f]["Field_DataType"].ToString() == "A")
                        {
                            cell.Controls.Add(lbl);
                            cell1.Controls.Add(box);
                            row.Cells.Add(cell);
                            row.Cells.Add(cell1);
                        }
                        else if (datatableobj.Rows[f]["Field_DataType"].ToString() == "C" | datatableobj.Rows[f]["Field_DataType"].ToString() == "N")
                        {
                            RadComboBox combo = new RadComboBox();
                            //combo.Attributes.Add("class", "span1 col-md-1 form-control");
                            combo.ID = "cmb" + datatableobj.Rows[f]["Field_Name"].ToString();

                            combo.EnableLoadOnDemand = true;
                            combo.ItemsRequested += new RadComboBoxItemsRequestedEventHandler(combo_ItemsRequested);
                            cell.Controls.Add(lbl);
                            cell1.Controls.Add(combo);
                            row.Cells.Add(cell);
                            row.Cells.Add(cell1);
                        }
                        table.Rows.Add(row);
                        placeholder.Controls.Add(table);
                       
                    
                    if (datatableobj.Rows[f]["Field_DataType"].ToString() == "U" | datatableobj.Rows[f]["Field_DataType"].ToString() == "D")
                    {
                        HtmlGenericControl divcontrol = new HtmlGenericControl("div");
                      //  divYogesh.Attributes.Add("class", "myClass");

                    
                        HiddenField hf = new HiddenField();
                        hf.ID = "hf" + datatableobj.Rows[f]["Field_Name"].ToString();
                        divcontrol.Controls.Add(hf);
                        placeholder.Controls.Add(divcontrol);
                    }
                    
                    }
                }
                //---- if no of rows greater than 6 then place controls in 2 sides
                else
                {
                    //HiddenField hf = new HiddenField();
                    TableRow row = new TableRow();
                    
                    for (int f = 0; f < datatableobj.Rows.Count; f++)
                    {
                      
                        TableCell cell = new TableCell();
                        TableCell cell1 = new TableCell();
                       // TableCell cell2 = new TableCell();
                        Label lbl = new Label();
                        lbl.Attributes.Add("class", "control-label col-md-3");

                        lbl.Text = datatableobj.Rows[f]["Field_Name"].ToString();
                        lbl.ID = "lbl" + datatableobj.Rows[f]["Field_Name"].ToString();

                        TextBox box = new TextBox();
                        box.Attributes.Add("class", "form-control");

                        box.ID = "txt" + datatableobj.Rows[f]["Field_Name"].ToString();
                       // box.ValidationGroup = "Submit";
                       // string ValidationGroup = "Submit";
                        //RequiredFieldValidator rfv = new RequiredFieldValidator();
                        //rfv.ControlToValidate = box.ID;
                        //rfv.ID = "rfv" + datatableobj.Rows[f]["Field_Name"];
                        ////rfv.EnableClientScript = false;
                        //rfv.ValidationGroup = ValidationGroup;
                        //rfv.ForeColor = System.Drawing.Color.Red;
                        //rfv.SetFocusOnError = true;
                        //rfv.ErrorMessage = "*Comments field is mandatory";
                        //rfv.Enabled = true;

                        if (datatableobj.Rows[f]["Field_DataType"].ToString() == "U" | datatableobj.Rows[f]["Field_DataType"].ToString() == "D")
                        {

                            HtmlGenericControl divcontrol = new HtmlGenericControl("div");
                            //  divYogesh.Attributes.Add("class", "myClass");


                            HiddenField hf = new HiddenField();
                            hf.ID = "hf" + datatableobj.Rows[f]["Field_Name"].ToString();
                            divcontrol.Controls.Add(hf);
                            placeholder.Controls.Add(divcontrol);


                        }
                         if (datatableobj.Rows[f]["Field_DataType"].ToString() == "B")
                        {
                            CheckBox checkbox = new CheckBox();
                            checkbox.ID = "chk" + datatableobj.Rows[f]["Field_Name"].ToString();
                            // checkbox.Text = "chk" + datatableobj.Rows[f]["Field_Name"].ToString();
                            cell.Controls.Add(lbl);
                            cell1.Controls.Add(checkbox);
                            row.Cells.Add(cell);
                            row.Cells.Add(cell1);
                        }
                        else if (datatableobj.Rows[f]["Field_DataType"].ToString() == "S" | datatableobj.Rows[f]["Field_DataType"].ToString() == "A")
                           {
                            cell.Controls.Add(lbl);
                            cell1.Controls.Add(box);
                           // cell1.Controls.Add(rfv);
                            //cell2.Controls.Add(rfv);
                            row.Cells.Add(cell);
                            row.Cells.Add(cell1);
                            //row.Cells.Add(cell2);
                        }
                        else if (datatableobj.Rows[f]["Field_DataType"].ToString() == "C" | datatableobj.Rows[f]["Field_DataType"].ToString() == "N")
                        {
                            RadComboBox combo = new RadComboBox();
                            combo.ID = "cmb" + datatableobj.Rows[f]["Field_Name"].ToString();
                            combo.EnableLoadOnDemand = true;
                            combo.ItemsRequested += new RadComboBoxItemsRequestedEventHandler(combo_ItemsRequested);
                            cell.Controls.Add(lbl);
                            cell1.Controls.Add(combo);
                            row.Cells.Add(cell);
                            row.Cells.Add(cell1);
                         
                        }
                         int s = row.Cells.Count;
                      //  if ((f + 1) % 2 == 0)
                         if (s % 4 == 0)// take coloum count . if count is multiple of 4 then it create next row. so each row contain 4 coloumns
                        {
                            table.Rows.Add(row);

                            row = new TableRow();
                        }
                        table.Rows.Add(row);
                     
                    }
                    
                }
               
                placeholder.Controls.Add(table);

                
               
            }
        }

        #endregion  PlaceControls

        #region  combo_ItemsRequested
        protected void combo_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            DataTable dst = new DataTable();
            string joinField;
            string selectField;
            string tableName;
            RadComboBox combo = (RadComboBox)sender;
            datatableobj = systabledefenitionobj.GetComboBoxDetails(_mode);

            //--- generate sql for drop down based on system table defenition
            for (int f = 0; f < datatableobj.Rows.Count; f++)
            {
                if (datatableobj.Rows[f]["Field_DataType"].ToString() == "C" | datatableobj.Rows[f]["Field_DataType"].ToString() == "N")
                {
                    tableName = datatableobj.Rows[f]["Ref_TableName"].ToString();
                    string fieldName = combo.ID;
                    fieldName = fieldName.Substring(3);//remove cmb from combo id

                    if (fieldName == datatableobj.Rows[f]["Field_Name"].ToString())
                    {
                        joinField = datatableobj.Rows[f]["Ref_JoinField"].ToString();
                        selectField = datatableobj.Rows[f]["Ref_SelectField"].ToString();
                        tableName = datatableobj.Rows[f]["Ref_TableName"].ToString();
                        string query = "SELECT " + joinField + "," + selectField + " FROM " + tableName;
                        dst = dynamicmasteroperationobj.GetComboBoxData(query);
                    }
                }
            }
            combo.Items.Clear();
            foreach (DataRow row in dst.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();
                item.Text = row[dst.Columns[1].ColumnName].ToString();
                item.Value = row[dst.Columns[0].ColumnName].ToString();
                combo.Items.Add(item);
                item.DataBind();
            }
        }

        #endregion  combo_ItemsRequested

        #region  InsertData
        public void InsertData()
        {
            try
            {
                string projectNo = UA.projectNo;
                datatableobj = systabledefenitionobj.GetComboBoxDetails(_mode);
                datatableobj.Columns.Add("Values", typeof(String));


                for (int f = 0; f < datatableobj.Rows.Count; f++)
                {
                    if (datatableobj.Rows[f]["Field_DataType"].ToString() == "U")
                    {
                        System.Guid guid = System.Guid.NewGuid();
                        String id = guid.ToString();
                        datatableobj.Rows[f]["Values"] = id;
                    }
                    else if (datatableobj.Rows[f]["Field_DataType"].ToString() == "V")
                    {

                        datatableobj.Rows[f]["Values"] = UA.userName;
                    }
                    else if (datatableobj.Rows[f]["Field_DataType"].ToString() == "D")
                    {
                        //  string date = System.DateTime.Now.ToString();
                        datatableobj.Rows[f]["Values"] = System.DateTime.Now.ToString("MM/dd/yyyy");
                    }
                    else if (datatableobj.Rows[f]["Field_DataType"].ToString() == "B")
                    {

                        CheckBox checkbox = (CheckBox)placeholder.FindControl("chk" + datatableobj.Rows[f]["Field_Name"]);

                        datatableobj.Rows[f]["Values"] = checkbox.Checked;
                    }


                    else if (datatableobj.Rows[f]["Field_DataType"].ToString() == "S" | datatableobj.Rows[f]["Field_DataType"].ToString() == "A")
                    {
                        TextBox box = (TextBox)placeholder.FindControl("txt" + datatableobj.Rows[f]["Field_Name"]);

                        datatableobj.Rows[f]["Values"] = box.Text;
                    }
                    else if (datatableobj.Rows[f]["Field_DataType"].ToString() == "C" | datatableobj.Rows[f]["Field_DataType"].ToString() == "N")
                    {
                        RadComboBox combo = (RadComboBox)placeholder.FindControl("cmb" + datatableobj.Rows[f]["Field_Name"]);
                        datatableobj.Rows[f]["Values"] = combo.SelectedValue;
                    }
                }

                int result = dynamicmasteroperationobj.InsertMasterData(datatableobj, projectNo, _mode, UA.userName);

                dtgDynamicMasterGrid.Rebind();
                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
                tabs.ResetTabCaptions(tab, tab1);
                //tab.Selected = true;
                RadMultiPage1.SelectedIndex = 0;


            }
            catch (Exception ex)
            {

                ToolBar.AddButton.Visible = false;
                ToolBar.SaveButton.Visible = true;
                ToolBar.UpdateButton.Visible = false;
                ToolBar.DeleteButton.Visible = false;


                //RadTab tab = (RadTab)RadTabStrip1.FindTabByText("View");
                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
                // TabAddEditSettings tabs = new TabAddEditSettings();
                tabs.ResetTabCaptions(tab, tab1);
                RadMultiPage1.SelectedIndex = 0;

                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);

            }

            foreach (Control c in placeholder.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)(c)).Text = string.Empty;
                }

            }
        }
        #endregion  InsertData

        //#region CleartextBoxes
        //public void CleartextBoxes()
        //{
           
        //    foreach (Control Cleartext in this.Controls)
        //    {
        //        if (Cleartext is TextBox)
        //        {
        //            ((TextBox)Cleartext).Text = "";
        //        }
        //    }
        //}
        //#endregion CleartextBoxes

        #region  dtgDynamicMasterGrid_NeedDataSource1
        protected void dtgDynamicMasterGrid_NeedDataSource1(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

            datatableobj = dynamicmasteroperationobj.BindMasters(_mode, UA.projectNo);         
            dtgDynamicMasterGrid.DataSource = datatableobj;
            //GridColumn col = dtgDynamicMasterGrid.MasterTableView.Columns.FindByUniqueNameSafe("VerifierID");
            //if(col!=null)
            //{
            //    col.Display = false;
            //}
           

        }
        #endregion  dtgDynamicMasterGrid_NeedDataSource1




        #region  dtgDynamicMasterGrid_ItemCommand

        protected void dtgDynamicMasterGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
            datatableobj = systabledefenitionobj.GetComboBoxDetails(_mode);

            //string sdw = dt.Rows[0][0].ToString();
            GridDataItem item = e.Item as GridDataItem;
            //string strId = item.GetDataKeyValue(sdw).ToString();
            if (item != null)
            {
                DataTable datatbl = new DataTable();
                string Key = "";
                string primarykeys = "";
                string ID = "";
                string KeyValue = "";
                string sdw = "";
                datatbl = systabledefenitionobj.GetPrimarykeys(_mode);
                for (int i = 0; i < datatbl.Rows.Count; i++)
                {
                    Key = datatbl.Rows[i]["Field_Name"].ToString();
                    primarykeys = primarykeys + Key + ",";

                    ID = item.GetDataKeyValue(Key).ToString();
                    KeyValue = KeyValue + ID + ",";



                }
                primarykeys = primarykeys.TrimEnd(',', ' ');
                KeyValue = KeyValue.TrimEnd(',', ' ');
                HiddenField.Value = primarykeys;
                HiddenField1.Value = KeyValue;
                int result;
                if (e.CommandName == "Delete")
                {
                     int checkProjectNo = userObj.ValidateProjectNoInMastersTable();
                     if (checkProjectNo == 0)
                     {
                         result = dynamicmasteroperationobj.DeleteMasterData(primarykeys, _mode, KeyValue);
                         if (result == 1)
                         {
                             RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                             RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
                             TabAddEditSettings tabs = new TabAddEditSettings();
                             tabs.Addtab(tab, tab1);
                             RadMultiPage1.SelectedIndex = 0;
                         }
                     }
                     else
                     {

                         RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                         RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
                         TabAddEditSettings tabs = new TabAddEditSettings();
                         tabs.Addtab(tab, tab1);
                         RadMultiPage1.SelectedIndex = 0;
                     }
                }
                else if (e.CommandName == "EditData")
                {

                    TabAddEditSettings tabs = new TabAddEditSettings();
                    RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                    tabs.EditTab(tab);
                    RadMultiPage1.SelectedIndex = 1;
                    ToolBar.AddButton.Visible = false;
                    ToolBar.SaveButton.Visible = false;
                    ToolBar.UpdateButton.Visible = true;
                    ToolBar.DeleteButton.Visible = true;
                    DataTable dst = new DataTable();

                    dst = dynamicmasteroperationobj.FillMasterData(primarykeys, _mode, UA.projectNo, KeyValue);
                    FlyCnDAL.SystemDefenitionDetails sm = new FlyCnDAL.SystemDefenitionDetails();
                    datatableobj.Columns.Add("Values", typeof(String));

                    for (int f = 0; f < dst.Columns.Count; f++)
                    {

                        if (datatableobj.Rows[f]["Field_DataType"].ToString() == "U" | datatableobj.Rows[f]["Field_DataType"].ToString() == "D")
                        {

                            string boxname = datatableobj.Rows[f]["Field_Name"].ToString();
                            HiddenField hf = (HiddenField)placeholder.FindControl("hf" + datatableobj.Rows[f]["Field_Name"]);
                            hf.Value = dst.Rows[0][boxname].ToString();
                        }

                        else if (datatableobj.Rows[f]["Field_DataType"].ToString() == "V")
                        {

                            datatableobj.Rows[f]["Values"] = UA.userName;
                        }

                        else if (datatableobj.Rows[f]["Field_DataType"].ToString() == "B")
                        {

                            string boxname = datatableobj.Rows[f]["Field_Name"].ToString();
                            CheckBox box = (CheckBox)placeholder.FindControl("chk" + datatableobj.Rows[f]["Field_Name"]);
                            box.Checked = Convert.ToBoolean(dst.Rows[0][boxname].ToString());
                        }

                        else if (datatableobj.Rows[f]["Field_DataType"].ToString() == "S" | datatableobj.Rows[f]["Field_DataType"].ToString() == "A")
                        {
                            string boxname = datatableobj.Rows[f]["Field_Name"].ToString();
                            TextBox box = (TextBox)placeholder.FindControl("txt" + datatableobj.Rows[f]["Field_Name"]);
                            box.Text = dst.Rows[0][boxname].ToString();

                        }
                        else if (datatableobj.Rows[f]["Field_DataType"].ToString() == "C" | datatableobj.Rows[f]["Field_DataType"].ToString() == "N")
                        {
                            string boxname = datatableobj.Rows[f]["Field_Name"].ToString();
                            RadComboBox combo = (RadComboBox)placeholder.FindControl("cmb" + datatableobj.Rows[f]["Field_Name"]);
                            string TableName = datatableobj.Rows[f]["Ref_TableName"].ToString();
                            string Name = datatableobj.Rows[f]["Ref_SelectField"].ToString();
                            string Code = datatableobj.Rows[f]["Ref_JoinField"].ToString();
                            DataTable dtable = dynamicmasteroperationobj.GetComboBoxDataById(dst.Rows[0][boxname].ToString(), TableName, Name, Code);
                            if (dtable.Rows.Count > 0)
                            {
                                combo.Text = dtable.Rows[0][Name].ToString();
                                //  combo.SelectedValue = dst.Rows[0][boxname].ToString();
                                combo.SelectedValue = dtable.Rows[0][Code].ToString();
                                string s = combo.Text;
                                string b = combo.SelectedValue;
                            }
                            else
                            {
                                combo.Text = "";
                                combo.SelectedValue = "";

                            }

                        }
                    }


                }
            }
        }
        #endregion  dtgDynamicMasterGrid_ItemCommand

        #region  Page_Init

        protected void Page_Init(object sender, System.EventArgs e)
        {
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            if (Request.Params["Mode"] == null) { }
            else
            {
                lblmasterName.Text = Request.Params["Mode"].ToString();
                _mode = Request.Params["Mode"].ToString();
            }

            string Key = "";
            string primarykeys = "";
            string sdw = "";
            datatableobj = systabledefenitionobj.GetPrimarykeys(_mode);
            for (int i = 0; i < datatableobj.Rows.Count; i++)
            {
                Key = datatableobj.Rows[i]["Field_Name"].ToString();
                primarykeys = primarykeys + Key + ",";

                sdw = primarykeys.TrimEnd(',', ' ');
            }
            // string[] test = sdw.Split(",");
            if (sdw != "")
            {
                dtgDynamicMasterGrid.MasterTableView.DataKeyNames = sdw.Split(',').ToArray();// new string[] { sdw };
            }
        }

        #endregion  Page_Init

        #region  UpdateData
        public void UpdateData()
        {
            try
            {


                DataSet dts = new DataSet();
                FlyCnDAL.SystemDefenitionDetails sds = new FlyCnDAL.SystemDefenitionDetails();
                dts = sds.getData(_mode);
                datatableobj = dts.Tables[0];
                string sdw = datatableobj.Rows[0]["Field_Name"].ToString();
                datatableobj.Columns.Add("Values", typeof(String));
                for (int f = 0; f < datatableobj.Rows.Count; f++)
                {

                    if (datatableobj.Rows[f]["Field_DataType"].ToString() == "U")
                    {
                        HiddenField hf = (HiddenField)placeholder.FindControl("hf" + datatableobj.Rows[f]["Field_Name"]);
                        datatableobj.Rows[f]["Values"] = hf.Value;
                    }
                    else if (datatableobj.Rows[f]["Field_DataType"].ToString() == "V")
                    {
                        datatableobj.Rows[f]["Values"] = UA.userName;
                       
                    }
                    else if (datatableobj.Rows[f]["Field_DataType"].ToString() == "B")
                    {
                        CheckBox box = (CheckBox)placeholder.FindControl("chk" + datatableobj.Rows[f]["Field_Name"]);

                        datatableobj.Rows[f]["Values"] = box.Checked;

                    }
                  else  if (datatableobj.Rows[f]["Field_DataType"].ToString() == "D")
                    {
                        HiddenField hf = (HiddenField)placeholder.FindControl("hf" + datatableobj.Rows[f]["Field_Name"]);
                        DateTime date =Convert.ToDateTime(hf.Value);

                        datatableobj.Rows[f]["Values"] = date.ToString("MM/dd/yyyy");
                          //  Convert.ToDateTime(date);
                        
                           
                    }
                       
                    else if (datatableobj.Rows[f]["Field_DataType"].ToString() == "S" | datatableobj.Rows[f]["Field_DataType"].ToString() == "A")
                    {
                        TextBox box = (TextBox)placeholder.FindControl("txt" + datatableobj.Rows[f]["Field_Name"]);

                        datatableobj.Rows[f]["Values"] = box.Text;



                    }
                    if (datatableobj.Rows[f]["Field_DataType"].ToString() == "C" | datatableobj.Rows[f]["Field_DataType"].ToString() == "N")
                    {
                        RadComboBox combo = (RadComboBox)placeholder.FindControl("cmb" + datatableobj.Rows[f]["Field_Name"]);
                        if (combo.SelectedValue != "")
                        {
                            datatableobj.Rows[f]["Values"] = combo.SelectedValue;

                        }
                        else
                        {

                            datatableobj.Rows[f]["Values"] = null;
                        }
                    }
                }
                int result = dynamicmasteroperationobj.UpdateMaster(datatableobj, _mode, sdw);
                //RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                //RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
                //TabAddEditSettings tabs = new TabAddEditSettings();
                //tabs.Addtab(tab, tab1);          
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
            //if (result == 1)
            //{
            //    dtgDynamicMasterGrid.Rebind();
            //    RadTab tab = (RadTab)RadTabStrip1.FindTabByText("View");
            //    tab.Selected = true;
            //    RadTab tab1 = (RadTab)RadTabStrip1.FindTabByText("Edit");
            //    tab1.Text = "New";
            //    tab1.ImageUrl = "~/Images/Icons/NewIcon.png";

            //    RadMultiPage1.SelectedIndex = 0;
            //}


        }

        #endregion  UpdateData

        #region dtgDynamicMasterGrid_PreRender
        protected void dtgDynamicMasterGrid_PreRender(object sender, EventArgs e)
        {

            dtgDynamicMasterGrid.Rebind();
        }

        #endregion dtgDynamicMasterGrid_PreRender

        protected void dtgDynamicMasterGrid_DataBound(object sender, EventArgs e)
        {
            if (_mode == "M_Verifiers")
            {
                dtgDynamicMasterGrid.MasterTableView.GetColumn("VerifierID").Display = false;
            }
        }


        //protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
        //{
        //    RadTab tab = (RadTab)RadTabStrip1.FindTabByText("View");
        //    tab.Selected = true;
        //    RadTab tab1 = (RadTab)RadTabStrip1.FindTabByText("Edit");
        //    tab1.Text = "New";
        //    tab1.ImageUrl = "~/Images/Icons/NewIcon.png";
        //}
    }
}