using FlyCn.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using FlyCn.UserControls;
using FlyCn.FlyCnDAL;
using System.Data;
using FlyCn.UIClasses;
using System.Web.UI.HtmlControls;
using System.Text;


namespace FlyCn.EngineeredDataList
{
    public partial class EnggViewData : System.Web.UI.Page
    {
        string _id;
        string _tableName;
        TabAddEditSettings tabs = new TabAddEditSettings();
        ErrorHandling eObj = new ErrorHandling();
        DataTable datatableobj = new DataTable();
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        FlyCnDAL.SystemDefenitionDetails systabledefenitionobj = new FlyCnDAL.SystemDefenitionDetails();
        FlyCnDAL.MasterOperations dynamicmasteroperationobj = new FlyCnDAL.MasterOperations();

        protected void Page_Load(object sender, EventArgs e)
        {
            //--------------------------------------------------------
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
          
            //---------------------------------------------------------
            PlaceControls();
        }
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

        protected void dtgEnggDataList_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {



        }

        protected void dtgEnggDataList_PreRender(object sender, EventArgs e)
        {
            dtgEnggDataList.Rebind();
        }

        protected void dtgEnggDataList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            
            datatableobj = dynamicmasteroperationobj.BindMasters(_tableName, "C00001");
            dtgEnggDataList.DataSource = datatableobj;
        }

        #region Page_Init
        protected void Page_Init(object sender, System.EventArgs e)
        {

            //if (Request.QueryString["Id"] == null) { }
            //else
            //{
            //    _id = Request.QueryString["Id"];
               
            //}
            _id = "ELE";
           
            string Key = "";
            string primarykeys = "";
            string sdw = "";
            Modules mObj = new Modules();
            DataSet ds = new DataSet();
            ds=mObj.GetModule(_id);
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

        #region ToolBar_OnClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            if (e.Item.Value == "Save")
            {
                Insert();
            }
            if (e.Item.Value == "Update")
            {
                Update();

            }
        
        }
        #endregion ToolBar_OnClick

        #region Insert
        public void Insert()
        {

        }

        #endregion Insert

        #region Update
        public void Update()
        {

        }
        #endregion Update




    }
}