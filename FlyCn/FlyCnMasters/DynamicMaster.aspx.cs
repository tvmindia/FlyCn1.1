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

        DataTable dt = new DataTable();
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        FlyCnDAL.SystemDefenitionDetails sd = new FlyCnDAL.SystemDefenitionDetails();
        FlyCnDAL.MasterOperations dl = new FlyCnDAL.MasterOperations();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["Mode"] == null) { } else {
              //  lblmasterName.Text = Request.Params["Mode"].ToString();
            }

            PlaceControls();
        }
     
      
          


       


        public void PlaceControls()
        {
            {
                Table table = new Table();

                //table.Attributes.Add("align", "left");
                //table.Attributes.Add("border", "1");
                //table.Attributes.Add("Width", "700px");
                //table.Style.Add("width", "50% !important");

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
                        //cell.Style.Add("width", "25% !important");
                        //cell.Style.Add("border-color", "Red");
                        //cell.Style.Add("border-style", "solid");
                        //cell.Style.Add("border-width", "1px");
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
                        //  string ErrorMessage = "This Field is Required";

                        RequiredFieldValidator rfv = new RequiredFieldValidator();
                        rfv.ControlToValidate = box.ID;
                        //  rfv.ErrorMessage = ErrorMessage;
                        rfv.ID = "rfv" + dt.Rows[f]["Field_Name"];
                        //   rfv.Text = "*";
                        //  rfv.ValidateRequestMode = System.Web.UI.ValidateRequestMode.Enabled;
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
                    //Label lbl = (Label)placeholder.FindControl("lbl" + dt.Rows[f]["Field_Name"]);
                    //string labeltext ="M_"+lbl.Text;
                    TableName = dt.Rows[f]["Ref_TableName"].ToString();

                    string FieldName = combo.ID;

                    //   int index = FieldName.IndexOf("cmb");
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
                //  item.Attributes.Add("ContactName", row["ContactName"].ToString());

                combo.Items.Add(item);

                item.DataBind();

            }
        }



  
      public  void ClearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                ClearInputs(ctrl.Controls);
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {


            InsertData();


        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            //RadTab tab = (RadTab)RadTabStrip1.FindTabByText("Edit");
            ////  tab.Selected = false;
            //tab.Text = "New";
            //RadTabStrip1.SelectedIndex = 0;
            UpdateData();


        }

        public void InsertData()
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
            //if (result == 1)
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Inserted Succesfully');", true);
            //    //rec.Field1 = "";

            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data not Inserted Succesfully')", true);
            //}
        }
        protected void RadGrid1_NeedDataSource1(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

            dt = dl.BindMasters(_mode, UA.projectNo);
            RadGrid1.DataSource = dt;

        }


        protected void RadGrid1_DeleteCommand(object source, GridCommandEventArgs e)
        {
            string ID = (e.Item as GridDataItem).GetDataKeyValue("ID").ToString();
            //delete query
        }



        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            dt = sd.GetComboBoxDetails(_mode);

            string sdw = dt.Rows[0][0].ToString();
            //GridDataItem dataItem = (GridDataItem)e.Item;

            GridDataItem item = e.Item as GridDataItem;
            string strId = item.GetDataKeyValue(sdw).ToString();
            int result;
            if (e.CommandName == "Delete")
            {


                result = dl.DeleteMasterData(strId, _mode, sdw);
                if (result == 1)
                {

                }

            }
            else if (e.CommandName == "EditData")
            {

                RadTab tab = (RadTab)RadTabStrip1.FindTabByValue("2");
                tab.Selected = true;
                tab.Text = "Edit";
                RadMultiPage1.SelectedIndex = 1;
            
                DataTable dst = new DataTable();


                string ID = (e.Item as GridDataItem).GetDataKeyValue(sdw).ToString();
                //  _rowId= (e.Item as GridDataItem).GetDataKeyValue("WelderID").ToString();
                //string ID2 = (e.Item as GridDataItem).GetDataKeyValue("ProjectNo").ToString();
                dst = dl.FillMasterData(ID, _mode, UA.projectNo, sdw);


                FlyCnDAL.SystemDefenitionDetails sm = new FlyCnDAL.SystemDefenitionDetails();


                dt.Columns.Add("Values", typeof(String));
                for (int f = 0; f < dst.Columns.Count; f++)
                {

                    if (dt.Rows[f]["Field_DataType"].ToString() == "S" | dt.Rows[f]["Field_DataType"].ToString() == "A")
                    {
                        string boxname = dt.Rows[f]["Field_Name"].ToString();
                        TextBox box = (TextBox)placeholder.FindControl("txt" + dt.Rows[f]["Field_Name"]);

                        //dt.Rows[f]["Values"] = box.Text;
                        box.Text = dst.Rows[0][boxname].ToString();
                    }

                    else if (dt.Rows[f]["Field_DataType"].ToString() == "C" | dt.Rows[f]["Field_DataType"].ToString() == "N")
                    {
                        string boxname = dt.Rows[f]["Field_Name"].ToString();
                        RadComboBox combo = (RadComboBox)placeholder.FindControl("cmb" + dt.Rows[f]["Field_Name"]);
                        //  dt.Rows[f]["Values"] = combo.SelectedValue;
                        //combo.Text = dst.Rows[0][boxname].ToString();
                        string TableName = dt.Rows[f]["Ref_TableName"].ToString();
                        string Name = dt.Rows[f]["Ref_SelectField"].ToString();
                        string Code = dt.Rows[f]["Ref_JoinField"].ToString();
                        DataTable dtable = dl.GetComboBoxDataById(dst.Rows[0][boxname].ToString(), TableName, Name, Code);
                        combo.Text = dtable.Rows[0][Name].ToString();
                        combo.SelectedValue = dst.Rows[0][boxname].ToString();
                    }
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "EditData", "UpdateFunction();", true);
                //result = dl.UpdateMaster(dt);

                //if(result==1)
                //{

                //}

            }

        }

        protected void Page_Init(object sender, System.EventArgs e)
        {
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            if (Request.Params["Mode"] == null) { }
            else
            {
                lblmasterName.Text = Request.Params["Mode"].ToString();
                _mode = Request.Params["Mode"].ToString();
            }


            dt = sd.GetComboBoxDetails(_mode);

            string sdw = dt.Rows[0][0].ToString();
            RadGrid1.MasterTableView.DataKeyNames = new string[] { sdw };
        }
        public void UpdateData()
        {

            DataSet dts = new DataSet();
            FlyCnDAL.SystemDefenitionDetails sds = new FlyCnDAL.SystemDefenitionDetails();
            dts = sds.getData(_mode);

            dt = dts.Tables[0];
            //dt = sd.getFieldNames("M_Country");
            string sdw = dt.Rows[0]["Field_Name"].ToString();
            dt.Columns.Add("Values", typeof(String));

            for (int f = 0; f < dt.Rows.Count; f++)
            {
                if (dt.Rows[f]["Field_DataType"].ToString() == "S" | dt.Rows[f]["Field_DataType"].ToString() == "A")
                {
                    TextBox box = (TextBox)placeholder.FindControl("txt" + dt.Rows[f]["Field_Name"]);
                    //if (box.Text == "")
                    //{
                    //    RequiredFieldValidator RequiredFieldValidator1 = (RequiredFieldValidator)placeholder.FindControl("rfv" + dt.Rows[f]["Field_Name"]);
                    //    RequiredFieldValidator1.Visible = true;
                    //    RequiredFieldValidator1.Enabled = true;
                    //    RequiredFieldValidator1.ErrorMessage = "This field is required.";
                    //}
                    //else
                    //{
                    dt.Rows[f]["Values"] = box.Text;

                    //}

                }
                if (dt.Rows[f]["Field_DataType"].ToString() == "C" | dt.Rows[f]["Field_DataType"].ToString() == "N")
                {
                    RadComboBox combo = (RadComboBox)placeholder.FindControl("cmb" + dt.Rows[f]["Field_Name"]);
                    dt.Rows[f]["Values"] = combo.SelectedValue;


                }
            }
            int result = dl.UpdateMaster(dt, _mode, sdw);
            if (result == 1)
            {
                RadGrid1.Rebind();
                RadTab tab = (RadTab)RadTabStrip1.FindTabByText("View");
                tab.Selected = true;
                RadTab tab1 = (RadTab)RadTabStrip1.FindTabByText("Edit");
                tab1.Text = "New";
                RadMultiPage1.SelectedIndex = 0;
            }


        }
        
    }
}