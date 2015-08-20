using FlyCn.FlyCnDAL;
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
        string _rowId;
        ErrorHandling eObj = new ErrorHandling();
        DataTable dt = new DataTable();
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        FlyCnDAL.SystemDefenitionDetails sd = new FlyCnDAL.SystemDefenitionDetails();
        FlyCnDAL.MasterOperations dl = new FlyCnDAL.MasterOperations();

        #region  Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["Mode"] == null) { } else {
              //  lblmasterName.Text = Request.Params["Mode"].ToString();
            }

            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";

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
              RadGrid1.Rebind();
              RadTab tab = (RadTab)RadTabStrip1.FindTabByText("View");
              tab.Selected = true;
              RadTab tab1 = (RadTab)RadTabStrip1.FindTabByText("Edit");
              tab1.Text = "New";
              tab1.ImageUrl = "~/Images/Icons/NewIcon.png";
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
                dt = sd.GetComboBoxDetails(_mode);
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
            dt = sd.GetComboBoxDetails(_mode);
            for (int f = 0; f < dt.Rows.Count; f++)
            {
                if (dt.Rows[f]["Field_DataType"].ToString() == "C"| dt.Rows[f]["Field_DataType"].ToString() == "N")
                {
                    TableName = dt.Rows[f]["Ref_TableName"].ToString();
                    string FieldName = combo.ID;
                    FieldName = FieldName.TrimStart('c');
                    FieldName = FieldName.TrimStart('m');
                    FieldName = FieldName.TrimStart('b');
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
            dt = sd.GetComboBoxDetails(_mode);
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
            RadGrid1.Rebind();
            RadTab tab = (RadTab)RadTabStrip1.FindTabByText("View");
            tab.Selected = true;
            RadMultiPage1.SelectedIndex = 0;
       
            }
            catch(Exception ex)
            {

                ToolBar.AddButton.Visible = false;
                ToolBar.SaveButton.Visible = true;
                ToolBar.UpdateButton.Visible = false;
                ToolBar.DeleteButton.Visible = false;
                throw ex;
              
            }
        } 

        #endregion  InsertData

        #region  RadGrid1_NeedDataSource1
        protected void RadGrid1_NeedDataSource1(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

            dt = dl.BindMasters(_mode, UA.projectNo);
            RadGrid1.DataSource = dt;

        }
        #endregion  RadGrid1_NeedDataSource1

        #region  RadGrid1_DeleteCommand
        protected void RadGrid1_DeleteCommand(object source, GridCommandEventArgs e)
        {
            string ID = (e.Item as GridDataItem).GetDataKeyValue("ID").ToString();
            //delete query
        }

        #endregion  RadGrid1_DeleteCommand


        #region  RadGrid1_ItemCommand

        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            dt = sd.GetComboBoxDetails(_mode);

            //string sdw = dt.Rows[0][0].ToString();
            GridDataItem item = e.Item as GridDataItem;
            //string strId = item.GetDataKeyValue(sdw).ToString();
           
            DataTable datatbl = new DataTable();
              string Key = "";
             string primarykeys="";
             string ID = "";
             string KeyValue = "";
             string sdw="";
             datatbl = sd.GetPrimarykeys(_mode);
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
                result = dl.DeleteMasterData(primarykeys, _mode,KeyValue);
              //  string _strId = strId;
                if (result == 1)
                {
                    //RadGrid1.Rebind();

                }

            }
            else if (e.CommandName == "EditData")
            {

                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                tab.Selected = true;
                tab.Text = "Edit";
                tab.ImageUrl = "~/Images/Icons/editIcon.png";

                RadMultiPage1.SelectedIndex = 1;
                ToolBar.AddButton.Visible = false;
                ToolBar.SaveButton.Visible = false;
                ToolBar.UpdateButton.Visible = true;
                ToolBar.DeleteButton.Visible = true;
                DataTable dst = new DataTable();
                //DataTable datatbl = new DataTable();
                //datatbl = sd.GetPrimarykeys(_mode);
        //        string key="";
        //        string  Id="";
        //for(int i=0;i<dt.Rows.Count;i++)
        // {
        //     key = dt.Rows[i]["Field_Name"].ToString();
        //     Id = dt.Rows[i]["Field_Name"].ToString() + "id";
        //     Id= RadGrid1.Items[0].GetDataKeyValue(key).ToString();//(e.Item as GridDataItem).GetDataKeyValue(sdw).ToString();
        //    }
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
        #endregion  RadGrid1_ItemCommand

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
            dt = sd.GetPrimarykeys(_mode);
        for(int i=0;i<dt.Rows.Count;i++)
         {
             Key = dt.Rows[i]["Field_Name"].ToString();
           primarykeys =  primarykeys + Key + "," ;

           sdw =primarykeys.TrimEnd(',', ' ');
         }
           // string[] test = sdw.Split(",");
        RadGrid1.MasterTableView.DataKeyNames = sdw.Split(',').ToArray();// new string[] { sdw };
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
                    dt.Rows[f]["Values"] = combo.SelectedValue;


                }
            }
            int result = dl.UpdateMaster(dt, _mode, sdw);
                  }
            catch(Exception ex)
             {
                 var page = HttpContext.Current.CurrentHandler as Page;
                 var master = page.Master;
                 eObj.ErrorData(ex, page);
             }
            //if (result == 1)
            //{
            //    RadGrid1.Rebind();
            //    RadTab tab = (RadTab)RadTabStrip1.FindTabByText("View");
            //    tab.Selected = true;
            //    RadTab tab1 = (RadTab)RadTabStrip1.FindTabByText("Edit");
            //    tab1.Text = "New";
            //    tab1.ImageUrl = "~/Images/Icons/NewIcon.png";

            //    RadMultiPage1.SelectedIndex = 0;
            //}


        }

        #endregion  UpdateData

        #region RadGrid1_PreRender
        protected void RadGrid1_PreRender(object sender, EventArgs e)
        {

            RadGrid1.Rebind();
        }

        #endregion RadGrid1_PreRender

    }
}