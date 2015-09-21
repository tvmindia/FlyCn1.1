using FlyCn.FlyCnDAL;
using FlyCn.UIClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
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
        DataTable dt = new DataTable();
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        FlyCnDAL.SystemDefenitionDetails object_sysdef = new FlyCnDAL.SystemDefenitionDetails();
        FlyCnDAL.MasterOperations dl = new FlyCnDAL.MasterOperations();

        #region  Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
           
            //--------------------------------------------------------
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
            //---------------------------------------------------------

            PlaceControls();
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
          int   result = dl.DeleteMasterData(primarykeys, _mode, KeyValue);
          if (result == 1)
          {
              dtgDynamicMasterGrid.Rebind();
              RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
              RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
              TabAddEditSettings tabs = new TabAddEditSettings();
              tabs.Addtab(tab,tab1);          
              RadMultiPage1.SelectedIndex = 0;

          }
            }
          
        }

        #endregion  ToolBar_onClick


        #region  PlaceControls

        public void PlaceControls()
        {
            {
                Table table = new Table();
                StringBuilder html = new StringBuilder();
                dt = object_sysdef.GetComboBoxDetails(_mode);
                lblmasterName.Text = dt.Rows[0]["Table_Description"].ToString();
                int totalrows = dt.Rows.Count;
                if (totalrows < 6)
                {
                    for (int f = 0; f < dt.Rows.Count; f++)
                    {
                        TableRow row = new TableRow();
                        TableCell cell = new TableCell();
                        TableCell cell1 = new TableCell();
                        Label lbl = new Label();
                        lbl.Text = dt.Rows[f]["Field_Name"].ToString();
                        TextBox box = new TextBox();
                        box.ID = "txt" + dt.Rows[f]["Field_Name"].ToString();
                        if (dt.Rows[f]["Field_DataType"].ToString() == "S" | dt.Rows[f]["Field_DataType"].ToString() == "A" )
                        {
                            cell.Controls.Add(lbl);
                            cell1.Controls.Add(box);
                            row.Cells.Add(cell);
                            row.Cells.Add(cell1);
                        }
                        else if (dt.Rows[f]["Field_DataType"].ToString() == "C" | dt.Rows[f]["Field_DataType"].ToString() == "N")
                        {
                            RadComboBox combo = new RadComboBox();
                            combo.ID = "cmb" + dt.Rows[f]["Field_Name"].ToString();
                            combo.EnableLoadOnDemand = true;
                            combo.ItemsRequested += new RadComboBoxItemsRequestedEventHandler(combo_ItemsRequested);
                            cell.Controls.Add(lbl);
                            cell1.Controls.Add(combo);
                            row.Cells.Add(cell);
                            row.Cells.Add(cell1);
                        }
                        table.Rows.Add(row);
                        placeholder.Controls.Add(table);
                    }
                }
                else
                {

                    TableRow row = new TableRow();
                    for (int f = 0; f < dt.Rows.Count; f++)
                    {
                        TableCell cell = new TableCell();
                        TableCell cell1 = new TableCell();
                        TableCell cell2 = new TableCell();
                        Label lbl = new Label();
                        lbl.Text = dt.Rows[f]["Field_Name"].ToString();
                        lbl.ID = "lbl" + dt.Rows[f]["Field_Name"].ToString();
                        lbl.Attributes.CssStyle.Add("text-align", "left");
                        TextBox box = new TextBox();
                        box.ID = "txt" + dt.Rows[f]["Field_Name"].ToString();
                        string ValidationGroup = "Submit";
                        RequiredFieldValidator rfv = new RequiredFieldValidator();
                        rfv.ControlToValidate = box.ID;
                        rfv.ID = "rfv" + dt.Rows[f]["Field_Name"];
                        rfv.EnableClientScript = false;
                        rfv.ValidationGroup = ValidationGroup;
                        rfv.ForeColor = System.Drawing.Color.Red;
                        rfv.SetFocusOnError = true;
                        rfv.ErrorMessage = "*Comments field is mandatory";
                        rfv.Enabled = true;                       
                        if (dt.Rows[f]["Field_DataType"].ToString() == "S" | dt.Rows[f]["Field_DataType"].ToString() == "A" )
                        {
                            cell.Controls.Add(lbl);
                            cell1.Controls.Add(box);
                            cell2.Controls.Add(rfv);
                            row.Cells.Add(cell);
                            row.Cells.Add(cell1);
                            row.Cells.Add(cell2);
                        }
                        else if (dt.Rows[f]["Field_DataType"].ToString() == "C" | dt.Rows[f]["Field_DataType"].ToString() == "N")
                        {
                            RadComboBox combo = new RadComboBox();
                            combo.ID = "cmb" + dt.Rows[f]["Field_Name"].ToString();
                            combo.EnableLoadOnDemand = true;
                            combo.ItemsRequested += new RadComboBoxItemsRequestedEventHandler(combo_ItemsRequested);
                            cell.Controls.Add(lbl);
                            cell1.Controls.Add(combo);
                            row.Cells.Add(cell);
                            row.Cells.Add(cell1);
                        }

                        if ((f + 1) % 2 == 0)
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
            string JoinField;
            string SelectField;
            string TableName;
            RadComboBox combo = (RadComboBox)sender;
            dt = object_sysdef.GetComboBoxDetails(_mode);

            //--- generate sql for drop down based on system table defenition
            for (int f = 0; f < dt.Rows.Count; f++)
            {
                if (dt.Rows[f]["Field_DataType"].ToString() == "C"| dt.Rows[f]["Field_DataType"].ToString() == "N")
                {
                    TableName = dt.Rows[f]["Ref_TableName"].ToString();
                    string FieldName = combo.ID;
                    FieldName = FieldName.Substring(3);//remove cmb from combo id

                    if (FieldName == dt.Rows[f]["Field_Name"].ToString())
                    {
                        JoinField = dt.Rows[f]["Ref_JoinField"].ToString();
                        SelectField = dt.Rows[f]["Ref_SelectField"].ToString();
                        TableName = dt.Rows[f]["Ref_TableName"].ToString();
                        string query = "SELECT " + JoinField + "," + SelectField + " FROM " + TableName;
                        dst = dl.GetComboBoxData(query);
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
            string ProjNo = UA.projectNo;
            dt = object_sysdef.GetComboBoxDetails(_mode);
            dt.Columns.Add("Values", typeof(String));


            for (int f = 0; f < dt.Rows.Count; f++)
            {

                    if (dt.Rows[f]["Field_DataType"].ToString() == "S" | dt.Rows[f]["Field_DataType"].ToString() == "A"  )

                    {
                        TextBox box = (TextBox)placeholder.FindControl("txt" + dt.Rows[f]["Field_Name"]);

                        dt.Rows[f]["Values"] = box.Text;
                    }
                    else if (dt.Rows[f]["Field_DataType"].ToString() == "C" | dt.Rows[f]["Field_DataType"].ToString() == "N")
                    {
                        RadComboBox combo = (RadComboBox)placeholder.FindControl("cmb" + dt.Rows[f]["Field_Name"]);
                        dt.Rows[f]["Values"] = combo.SelectedValue;
                    }
            }

            int result = dl.InsertMasterData(dt, ProjNo, _mode);   
  
            dtgDynamicMasterGrid.Rebind();
            RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
            RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
            tabs.ResetTabCaptions(tab, tab1);
            //tab.Selected = true;
            RadMultiPage1.SelectedIndex = 0;
       
       
            }
            catch(Exception ex)
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

        #endregion  InsertData

        #region  dtgDynamicMasterGrid_NeedDataSource1
        protected void dtgDynamicMasterGrid_NeedDataSource1(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

            dt = dl.BindMasters(_mode, UA.projectNo);
            dtgDynamicMasterGrid.DataSource = dt;

        }
        #endregion  dtgDynamicMasterGrid_NeedDataSource1

        #region  dtgDynamicMasterGrid_DeleteCommand
        protected void dtgDynamicMasterGrid_DeleteCommand(object source, GridCommandEventArgs e)
        {
            string ID = (e.Item as GridDataItem).GetDataKeyValue("ID").ToString();
            //delete query
        }

        #endregion  dtgDynamicMasterGrid_DeleteCommand


        #region  dtgDynamicMasterGrid_ItemCommand

        protected void dtgDynamicMasterGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
            dt = object_sysdef.GetComboBoxDetails(_mode);

            //string sdw = dt.Rows[0][0].ToString();
            GridDataItem item = e.Item as GridDataItem;
            //string strId = item.GetDataKeyValue(sdw).ToString();
           
            DataTable datatbl = new DataTable();
              string Key = "";
             string primarykeys="";
             string ID = "";
             string KeyValue = "";
             string sdw="";
             datatbl = object_sysdef.GetPrimarykeys(_mode);
             for (int i = 0; i < datatbl.Rows.Count; i++)
            {
                Key = datatbl.Rows[i]["Field_Name"].ToString();
                primarykeys = primarykeys + Key + ",";

                ID = item.GetDataKeyValue(Key).ToString();
                KeyValue =KeyValue+ ID + ",";
               


            }
            primarykeys = primarykeys.TrimEnd(',', ' ');
            KeyValue = KeyValue.TrimEnd(',', ' ');
            HiddenField.Value = primarykeys;
            HiddenField1.Value = KeyValue;
            int result;
            if (e.CommandName == "Delete")
            {
              



                    result = dl.DeleteMasterData(primarykeys, _mode, KeyValue);
                    if (result == 1)
                    {
                        RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
                        RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
                        TabAddEditSettings tabs = new TabAddEditSettings();
                        tabs.Addtab(tab, tab1);
                        RadMultiPage1.SelectedIndex = 0;
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
              
                 dst = dl.FillMasterData(primarykeys, _mode, UA.projectNo, KeyValue);
                FlyCnDAL.SystemDefenitionDetails sm = new FlyCnDAL.SystemDefenitionDetails();
                dt.Columns.Add("Values", typeof(String));
                for (int f = 0; f < dst.Columns.Count; f++)
                {
                    if (dt.Rows[f]["Field_DataType"].ToString() == "S" | dt.Rows[f]["Field_DataType"].ToString() == "A")
                    {
                        string boxname = dt.Rows[f]["Field_Name"].ToString();
                        TextBox box = (TextBox)placeholder.FindControl("txt" + dt.Rows[f]["Field_Name"]);
                        box.Text = dst.Rows[0][boxname].ToString();
                        
                    }
                    else if (dt.Rows[f]["Field_DataType"].ToString() == "C" | dt.Rows[f]["Field_DataType"].ToString() == "N")
                    {
                        string boxname = dt.Rows[f]["Field_Name"].ToString();
                        RadComboBox combo = (RadComboBox)placeholder.FindControl("cmb" + dt.Rows[f]["Field_Name"]);
                        string TableName = dt.Rows[f]["Ref_TableName"].ToString();
                        string Name = dt.Rows[f]["Ref_SelectField"].ToString();
                        string Code = dt.Rows[f]["Ref_JoinField"].ToString();
                        DataTable dtable = dl.GetComboBoxDataById(dst.Rows[0][boxname].ToString(), TableName, Name, Code);
                        if (dtable.Rows.Count>0)
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
             string primarykeys="";
             string sdw="";
            dt = object_sysdef.GetPrimarykeys(_mode);
        for(int i=0;i<dt.Rows.Count;i++)
         {
             Key = dt.Rows[i]["Field_Name"].ToString();
           primarykeys =  primarykeys + Key + "," ;

           sdw =primarykeys.TrimEnd(',', ' ');
         }
           // string[] test = sdw.Split(",");
        dtgDynamicMasterGrid.MasterTableView.DataKeyNames = sdw.Split(',').ToArray();// new string[] { sdw };
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
            dt = dts.Tables[0];
            string sdw = dt.Rows[0]["Field_Name"].ToString();
            dt.Columns.Add("Values", typeof(String));
            for (int f = 0; f < dt.Rows.Count; f++)
            {
                if (dt.Rows[f]["Field_DataType"].ToString() == "S" | dt.Rows[f]["Field_DataType"].ToString() == "A")
                {
                    TextBox box = (TextBox)placeholder.FindControl("txt" + dt.Rows[f]["Field_Name"]);
                    
                    dt.Rows[f]["Values"] = box.Text;

                  

                }
                if (dt.Rows[f]["Field_DataType"].ToString() == "C" | dt.Rows[f]["Field_DataType"].ToString() == "N")
                {
                    RadComboBox combo = (RadComboBox)placeholder.FindControl("cmb" + dt.Rows[f]["Field_Name"]);
                    if(combo.SelectedValue!="")
                    { 
                    dt.Rows[f]["Values"] = combo.SelectedValue;

                    }
                    else
                    {

                        dt.Rows[f]["Values"] = null;
                    }
                }
            }
            int result = dl.UpdateMaster(dt, _mode, sdw);
            //RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("1");
            //RadTab tab1 = (RadTab)RadTabStrip1.FindTabByValue("2");
            //TabAddEditSettings tabs = new TabAddEditSettings();
            //tabs.Addtab(tab, tab1);          
                  }
            catch(Exception ex)
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