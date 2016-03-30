using FlyCn.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using FlyCn.FlyCnDAL;
using System.Data;
using FlyCn.UIClasses;
using System.Web.UI.HtmlControls;
using System.Text;


namespace FlyCn.EngineeredDataList
{
    public partial class EnggViewData : System.Web.UI.Page
    {
        string moduleID;
        string _tableName;
        string Key = "";
        string primarykeys = "";
        TabAddEditSettings tabs = new TabAddEditSettings();
        ErrorHandling eObj = new ErrorHandling();
        DataTable datatableobj = new DataTable();
        //UIClasses.Const Const = new UIClasses.Const();
        HttpContext context = HttpContext.Current;
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        FlyCnDAL.SystemDefenitionDetails systabledefenitionobj = new FlyCnDAL.SystemDefenitionDetails();
        FlyCnDAL.MasterOperations dynamicmasteroperationobj = new FlyCnDAL.MasterOperations();
        UIClasses.DynamicIcons dynamiClasObj = new UIClasses.DynamicIcons();
        
        protected void Page_Load(object sender, EventArgs e)
        {
           string moduleID = Request.QueryString["Id"];
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            SecurityCheck();

            ToolBarVisibility(4);
            //--------------------------------------------------------
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
          
            //---------------------------------------------------------
            PlaceControls();
            
            horizonaltab.Controls.Add(new LiteralControl(dynamiClasObj.EILViewDataHorizontalTabBind(UA.projectNo,Const.EILViewData)));//horizontal tile bind
        }

        #region SecurityCheck
        public void SecurityCheck()
        {
            string logicalObject = "EnggViewData";

            FlyCnDAL.Security.PageSecurity PS = new Security.PageSecurity(logicalObject, this);

            if (PS.isWrite == true)
            {
                dtgEnggDataList.MasterTableView.GetColumn("ViewDetailColumn").Display = false;
                //  dtgBOQGrid.MasterTableView.GetColumn("DeleteColumn").Display = false;
            }
            else
                if (PS.isEdit == true)
                {
                    dtgEnggDataList.MasterTableView.GetColumn("ViewDetailColumn").Display = false;
                    //  dtgBOQGrid.MasterTableView.GetColumn("DeleteColumn").Display = false;
                }
                else if (PS.isAdd == true)
                {
                    dtgEnggDataList.MasterTableView.GetColumn("EditData").Display = false;
                }
                else if (PS.isRead == true)
                {
                    dtgEnggDataList.MasterTableView.GetColumn("ViewDetailColumn").Display = true;
                    dtgEnggDataList.MasterTableView.GetColumn("EditData").Display = false;
                    
                    //   dtgBOQGrid.MasterTableView.GetColumn("DeleteColumn").Display = false;
                }

                else if (PS.isDenied == true)
                {
                    HttpContext.Current.Response.Redirect("~/General/UnderConstruction.aspx?cause=accessdenied", true);
                }
            if (PS.isDelete == true)
            {
                //  dtgBOQGrid.MasterTableView.GetColumn("DeleteColumn").Display = true;
            }

        }
        #endregion SecurityCheck


        #region  combo_ItemsRequested
        protected void combo_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            DataTable dst = new DataTable();
            string joinField;
            string selectField;
            string tableName;
            RadComboBox combo = (RadComboBox)sender;
            datatableobj = systabledefenitionobj.GetComboBoxDetails(_tableName);

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

        #region  PlaceControls

        public void PlaceControls()
        {
            {
                //HtmlGenericControl divcontrol = new HtmlGenericControl();
                //divcontrol.Attributes["class"] = "col-md-12 Span-One col-md-6 form-group";
                //divcontrol.TagName = "div";
              
                Table table = new Table();
                StringBuilder html = new StringBuilder();
                datatableobj = systabledefenitionobj.GetComboBoxDetails(_tableName);
                lblTableName.Text = datatableobj.Rows[0]["Table_Description"].ToString();
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
                            //combo.Items.Insert(0, new RadComboBoxItem("Select", string.Empty));
                            combo.Items[0].Text = "Select";
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
                     
                        if (datatableobj.Rows[f]["Field_DataType"].ToString() == "U" | datatableobj.Rows[f]["Field_DataType"].ToString() == "D")
                        {

                            HtmlGenericControl divcontrol = new HtmlGenericControl("div");
                        


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

        protected void dtgEnggDataList_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
          
            datatableobj = systabledefenitionobj.GetComboBoxDetails(_tableName);

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
                datatbl = systabledefenitionobj.GetPrimarykeys(_tableName);
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
                //if (e.CommandName == "Delete")
                //{
                //    result = dynamicmasteroperationobj.DeleteMasterData(primarykeys, _tableName, KeyValue);
                //    if (result == 1)
                //    {
                //        RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                //        RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
                //        TabAddEditSettings tabs = new TabAddEditSettings();
                //        tabs.Addtab(tab, tab1);
                //        RadMultiPage1.SelectedIndex = 0;
                //    }
                //    else
                //    {

                //        RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                //        RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
                //        TabAddEditSettings tabs = new TabAddEditSettings();
                //        tabs.Addtab(tab, tab1);
                //        RadMultiPage1.SelectedIndex = 0;
                //    }
                //}
                if (e.CommandName == "EditData")
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
                    UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
                    dst = dynamicmasteroperationobj.FillMasterData(primarykeys, _tableName, UA.projectNo, KeyValue);
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

        protected void dtgEnggDataList_PreRender(object sender, EventArgs e)
        {
            dtgEnggDataList.Rebind();
        }

        protected void dtgEnggDataList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            GridBind();
        }

        public void GridBind()
        {
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            datatableobj = dynamicmasteroperationobj.BindMasters(_tableName, UA.projectNo,moduleID, true);//boolean true is used to flag the dynamic sp for current need
            dtgEnggDataList.DataSource = datatableobj;
        }

        #region Page_Init
        protected void Page_Init(object sender, System.EventArgs e)
        {

            if (Request.QueryString["Id"]!= null) 
            {
                moduleID = Request.QueryString["Id"];//id from horizontaltab click
            }
            else
            {
                moduleID = "ELE";//default id for View Data Grid
            }
          
           

            string sdw = "";
            Modules mObj = new Modules();
            DataSet ds = new DataSet();
            ds = mObj.GetModule(moduleID);
            _tableName = mObj.BaseTable;
            lblTableName.Text=_tableName;
            SystemDefenitionDetails sObj = new SystemDefenitionDetails();
            datatableobj=sObj.GetPrimarykeys(_tableName);
            for (int i = 0; i < datatableobj.Rows.Count; i++)
            {
                Key = datatableobj.Rows[i]["Field_Name"].ToString();
                primarykeys = primarykeys + Key + ",";

                sdw = primarykeys.TrimEnd(',', ' ');
            }
            // string[] test = sdw.Split(",");
            dtgEnggDataList.MasterTableView.DataKeyNames = sdw.Split(',').ToArray();// new string[] { sdw };
        }

        #endregion  Page_Init


      
        #region  ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;
            if (e.Item.Value == "Add")//It doesnot add anything but clears
            {
                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                tab.Selected = true;
                tab.Text = "New";
                RadMultiPage1.SelectedIndex = 1;
             
               ToolBarVisibility(3);
               

            }
            if (e.Item.Value == "Save")
            {
                Insert();
              ToolBarVisibility(1);
                dtgEnggDataList.Rebind();
               ToolBarVisibility(4);
                //calling js function DisableBOQHeaderTextBox()to make text box readonly
        

            }
            if (e.Item.Value == "Update")
            {
             
               ToolBarVisibility(1);
                Update();
                ToolBarVisibility(4);
            }
            if (e.Item.Value == "Edit")
            {
               ToolBarVisibility(2);
       
                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                tab.Selected = true;
                tab.Text = "Edit";
                RadMultiPage1.SelectedIndex = 1;
                ToolBarVisibility(4);
            }
            if (e.Item.Value == "Delete")
            {
                //Delete();
            }

        }
        #endregion ToolBar_onClick
        #region ToolBarVisibility
        public void ToolBarVisibility(int order)
        {
            switch (order)
            {
                case 1://after adding what should be visible
                    ToolBar.AddButton.Visible = true;
                    ToolBar.SaveButton.Visible = false;
                    ToolBar.UpdateButton.Visible = false;
                    ToolBar.EditButton.Visible = true;
                    ToolBar.DeleteButton.Visible = false;
                    break;
                case 2:
                    ToolBar.AddButton.Visible = true;
                    ToolBar.SaveButton.Visible = false;
                    ToolBar.UpdateButton.Visible = true;
                    ToolBar.EditButton.Visible = false;
                    ToolBar.DeleteButton.Visible = false;
                    break;

                case 3:
                    ToolBar.AddButton.Visible = false;
                    ToolBar.SaveButton.Visible = true;
                    ToolBar.UpdateButton.Visible = false;
                    ToolBar.EditButton.Visible = false;
                    ToolBar.DeleteButton.Visible = false;
                    break;


                case 4://toally invicible
                    ToolBar.AddButton.Visible = false;
                    ToolBar.SaveButton.Visible = false;
                    ToolBar.UpdateButton.Visible = false;
                    ToolBar.EditButton.Visible = false;
                    ToolBar.DeleteButton.Visible = false;
                    break;

            }

        }
        #endregion ToolBarVisibility

        #region Insert
        public void Insert()
        {
            try
            {
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                string projectNo =UA.projectNo;
              datatableobj = systabledefenitionobj.GetComboBoxDetails(_tableName);
            datatableobj.Columns.Add("Values", typeof(String));

              DataTable dtObj=new DataTable();


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
                    //else if (datatableobj.Rows[f]["Field_DataType"].ToString() == "D")
                    //{

                    //    TextBox box = (TextBox)placeholder.FindControl("txt" + datatableobj.Rows[f]["Field_Name"]);
                    //    datatableobj.Rows[f]["Values"] = box.Text;

                     
                    //}
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
                        
                        if ( combo.SelectedValue == "")
                        {

                            datatableobj.Rows[f]["Values"] = DBNull.Value;
                        }
                        else
                        {
                            datatableobj.Rows[f]["Values"] = combo.SelectedValue;
                          
                        }
                        
                    }


                }
                DataRow row1 = dtObj.NewRow();
                DataRow row = dtObj.NewRow();
                DataColumn column0 = new DataColumn();
                column0.ColumnName = "ProjectNo";
                column0.DataType = System.Type.GetType("System.String");
                column0.Caption = "ProjectNo";
                dtObj.Columns.Add(column0);
    
                dtObj.Rows.Add(UA.projectNo);
               
                for (int r = 0; r < datatableobj.Rows.Count; r++)
                {
                    string tempfield = datatableobj.Rows[r]["Field_Name"].ToString();
                    string fieldtype = datatableobj.Rows[r]["Field_DataType"].ToString();
                    DataColumn column = new DataColumn();
                    column.ColumnName = tempfield;
                    column.DataType = System.Type.GetType("System.String");
                    column.Caption = tempfield;
                    dtObj.Columns.Add(column);
                 
                    object value = datatableobj.Rows[r]["Values"];

                    dtObj.Rows[0][tempfield] = value;
                  

              
                }


                int result;
                ImportFile ifobj = new ImportFile();

                CommonDAL tblDef = new CommonDAL();
                DataSet ds = new DataSet();
                tblDef.tableName = _tableName;
                ifobj.TableName = _tableName;
                ds = tblDef.GetTableDefinition(tblDef.tableName);

                foreach (DataRow r in dtObj.Rows)
                {
                    result = ifobj.ImportExcelRow(ds, r);
                }
               // int result = dynamicmasteroperationobj.InsertMasterData(datatableobj, projectNo, _tableName);
               
                    
                
                dtgEnggDataList.Rebind();
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

        }

        #endregion Insert

        #region Update
        public void Update()
        {
            try
            {

                DataTable dtObj = new DataTable();
                DataSet dts = new DataSet();
                FlyCnDAL.SystemDefenitionDetails sds = new FlyCnDAL.SystemDefenitionDetails();
                dts = sds.getData(_tableName);
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
                    else if (datatableobj.Rows[f]["Field_DataType"].ToString() == "D")
                    {
                        HiddenField hf = (HiddenField)placeholder.FindControl("hf" + datatableobj.Rows[f]["Field_Name"]);
                        DateTime date = Convert.ToDateTime(hf.Value);

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
                       

                        if (combo.SelectedValue == "")
                        {

                            datatableobj.Rows[f]["Values"] = DBNull.Value;
                        }
                        else
                        {
                            datatableobj.Rows[f]["Values"] = combo.SelectedValue;

                        }
                    }

                }
                DataRow row1 = dtObj.NewRow();
                DataRow row = dtObj.NewRow();
                DataColumn column0 = new DataColumn();
                column0.ColumnName = "ProjectNo";
                column0.DataType = System.Type.GetType("System.String");
                column0.Caption = "ProjectNo";
                dtObj.Columns.Add(column0);
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                dtObj.Rows.Add(UA.projectNo);

                for (int r = 0; r < datatableobj.Rows.Count; r++)
                {
                    string tempfield = datatableobj.Rows[r]["Field_Name"].ToString();
                    string fieldtype = datatableobj.Rows[r]["Field_DataType"].ToString();
                    DataColumn column = new DataColumn();
                    column.ColumnName = tempfield;
                    column.DataType = System.Type.GetType("System.String");
                    column.Caption = tempfield;
                    dtObj.Columns.Add(column);

                    object value = datatableobj.Rows[r]["Values"];

                    dtObj.Rows[0][tempfield] = value;



                }


                int result;
                ImportFile ifobj = new ImportFile();

                CommonDAL tblDef = new CommonDAL();
                DataSet ds = new DataSet();
                tblDef.tableName = _tableName;
                ifobj.TableName = _tableName;
                ds = tblDef.GetTableDefinition(tblDef.tableName);

                foreach (DataRow r in dtObj.Rows)
                {
                    result = ifobj.ImportExcelRow(ds, r);
                }
                // int result = dynamicmasteroperationobj.InsertMasterData(datatableobj, projectNo, _tableName);



                dtgEnggDataList.Rebind();
                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
                tabs.ResetTabCaptions(tab, tab1);
                //tab.Selected = true;
                RadMultiPage1.SelectedIndex = 0;
               
               
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
          

        }
        #endregion Update




    }
}