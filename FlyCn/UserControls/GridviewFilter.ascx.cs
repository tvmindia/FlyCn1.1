
#region Copyright
//All rights are reserved
//Created by : SHAMILA T P
//Date : Nov-20-2015
#endregion Copyright

#region Included Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using FlyCn.FlyCnDAL;
using System.Data.Sql;



#endregion Included Namespaces

namespace FlyCn.UserControls
{ 
    public partial class GridviewFilter : System.Web.UI.UserControl
    {
        #region Public Properties


        /// <summary>
        /// table name passed to table definition to get the column names to filter
        /// </summary>
        public string tableName
        {
            get;
            set;
        }

        public string operatorToFilter
        {
            get;
            set;
        }

        public string ValueToFilter
        {
            get;
            set;
        }


        public string ColumnName
        {
            get;
            set;
        }

        public string WhereCondition
        {
            get;
            set;
        }


        #endregion Public Properties


        public event EventHandler onClick;

        //public event EventHandler searchClickFromAddClick;

        #region Public Functions

        #region Create Datatable For Where Condition

        /// <summary>
        /// function to create datatable for displaying where condition in gridview( and is called from page load)
        /// </summary>
        public void CreateDatatableForWhereCondition()
        {
            DataTable dt = new DataTable();   
   
            dt.Columns.AddRange(new DataColumn[1] { new DataColumn(" ", typeof(string)) });

            //saving databale into viewstate    
            ViewState["dtWhereCondition"] = dt;
    
            //bind Gridview 
            gvSearch.DataSource = dt;
            gvSearch.DataBind();

        }

        #endregion Create Datatable For Where Condition

        #endregion  Public Functions

        FlyCnDAL.CommonDAL CommonDALobj = new FlyCnDAL.CommonDAL();

        #region Events

        #region Page Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet dsColumnNames = null;

            CommonDALobj.tableName = tableName;
            dsColumnNames = CommonDALobj.getColumnNamesToFilter();
           
            if (!Page.IsPostBack)
            {
                ddlColumnName.Items.Add("--Select--");
                ddlColumnName.DataSource = dsColumnNames;
                ddlColumnName.DataTextField = "Field_Name";
                ddlColumnName.DataBind();

                ddlColumnName.Items.Insert(0, "--Select--");
                ddlOperator.Items.Add("--Select--");

                CreateDatatableForWhereCondition();
         }
            
                AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
                trigger.ControlID = "ddlColumnName";
                trigger.EventName = "SelectedIndexChanged";
                updatepanel.Triggers.Add(trigger);
         }
        #endregion Page Load

        #region Selected Index Changed

        /// <summary>
        /// populating operators based on column name, and removing "--select--" items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlColumnName_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DataSet dsColumnDataType = null;

            CommonDALobj.tableName = tableName;
            CommonDALobj.ColumnNameToCompare = ddlColumnName.SelectedItem.ToString();

            dsColumnDataType = new DataSet();
            dsColumnDataType = CommonDALobj.GetDatatypeOfColumn();
            string dataTypeOfColumn = dsColumnDataType.Tables[0].Rows[0]["Field_DataType"].ToString();


            ddlOperator.Items.Remove("--Select--");
            ddlColumnName.Items.Remove("--Select--");

            CommonDALobj.dataTypeOfColumn = dataTypeOfColumn;
            CommonDALobj.columnNameDropdownlistID = "ddlOperator";

            if (ddlOperator.Items.Count == 0)
            {
                CommonDALobj.PopulateOperatorBasedOnDataTypeOfColumnName(ddlOperator);
            }
      
            
        }
        #endregion Selected Index Changed

        #region Search Image Button Click
        /// <summary>
        /// Button which submits where condition to the event(the value of WhereCondition is assigned to search query in the event)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnSearch_Click1(object sender, ImageClickEventArgs e)
        {

            string fieldName = ddlColumnName.SelectedValue;
            string comparisonOperator = ddlOperator.SelectedValue;
            string ValueToFilter = txtValueToFilter.Text;

            CommonDALobj.tableName = tableName;
            CommonDALobj.ColumnNameToCompare = fieldName;
            CommonDALobj.oprtorToFilter = comparisonOperator;
            CommonDALobj.ValueToFilter = ValueToFilter;

            //If we've only 1 condition WhereCondition assigns with value returned from getWhereCondition() of CommonDAL class. 
            //If we've multiple conditions, WhereCondition updated with the value from "Add Condition " button click(values are stored in viewstates)

            WhereCondition = CommonDALobj.getWhereCondition();

            //All conditions are in gridview,ie search button clicked only after all conditions are added
            if (ViewState["previousRowData"]!=null && ViewState["TotalWhereConditions"] != null)
            {
                WhereCondition = ViewState["TotalWhereConditions"].ToString();
            }

            //Some conditions are in gridview,and last condition is not added. ie search button clicked without adding the last condition
            else if (ViewState["previousRowData"] != null && ViewState["TotalWhereConditions"] == null)
            {
                WhereCondition = ViewState["previousRowData"] + " AND " + WhereCondition;
              
            }
           

            this.onClick(sender, e);
        }
        #endregion Search Image Button Click

        #region Refresh image Button Click
        /// <summary>
        /// To make the page to be appear as in page load, also clear the gridview and viewstates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            //gvSearch.Columns.Clear();
            gvSearch.DataSource = null;
           
            ViewState["dtWhereCondition"] = null;
            ViewState["previousRowData"] = null;
            ViewState["TotalWhereConditions"] = null;

           
            gvSearch.DataBind();
            

            this.onClick(sender, e);

            DataSet dsColumnNames = null;


            CommonDALobj.tableName = tableName;
            dsColumnNames = CommonDALobj.getColumnNamesToFilter();


            ddlColumnName.Items.Add("--Select--");
            ddlColumnName.DataSource = dsColumnNames;
            ddlColumnName.DataTextField = "Field_Name";
            ddlColumnName.DataBind();
            ddlColumnName.Items.Insert(0, "--Select--");

            ddlOperator.Items.Clear();
            ddlOperator.Items.Add("--Select--");
            txtValueToFilter.Text = "";
        }
        #endregion Refresh image Button Click

        #region Add Image Button Click
        /// <summary>
        /// To add more where conditions ,and display them in gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgAddIcon_Click(object sender, ImageClickEventArgs e)
        {
            string whereConditionInGv; //variable which holds the value of where condition to be displayed in gridview
            string columnName = ddlColumnName.SelectedValue;
            string operatorValue = ddlOperator.SelectedValue;
            string value = txtValueToFilter.Text;
            string condition = ddlANDorOR.SelectedValue;
            
            //Condition to ensure that button is clicked only after selecting the value from dropdown list
            if (columnName != "--Select--" || operatorValue != "--Select--")
            {
                CommonDALobj.tableName = tableName;
                CommonDALobj.ColumnNameToCompare = columnName;
                CommonDALobj.oprtorToFilter = operatorValue;
                CommonDALobj.ValueToFilter = value;

                WhereCondition = CommonDALobj.getWhereCondition();

                DataTable dtCurrentTable = null;

                if (ViewState["dtWhereCondition"] != null)
                {
                    dtCurrentTable = (DataTable)ViewState["dtWhereCondition"];
                }
                else
                {
                    //CreateDatatableForWhereCondition();

                    dtCurrentTable = new DataTable();
                    dtCurrentTable.Columns.AddRange(new DataColumn[1] { new DataColumn(" ", typeof(string)) });
                }

                DataRow drCurrentRow = null;
                drCurrentRow = dtCurrentTable.NewRow();

              //checks whether dt contains only one condition 
                if (dtCurrentTable.Rows.Count < 1)
                {
                    whereConditionInGv = columnName+" "+ operatorValue+" "+ value;
                    WhereCondition = WhereCondition;

                    ViewState["previousRowData"] = WhereCondition;
                }
                else
                {
                    whereConditionInGv = condition + " " + columnName + " " + operatorValue + " " + value;
                    WhereCondition = ViewState["previousRowData"] + " " +condition+ " "+WhereCondition;

                    ViewState["TotalWhereConditions"] = WhereCondition;
                }

                drCurrentRow[" "] = whereConditionInGv;
                dtCurrentTable.Rows.Add(drCurrentRow);

                ViewState["dtWhereCondition"] = dtCurrentTable;

                //Bind Gridview with latest Row   
                gvSearch.DataSource = dtCurrentTable;
                gvSearch.DataBind();
            }
       
        }
        #endregion Add Image Button Click


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string fieldName = ddlColumnName.SelectedValue;
            string comparisonOperator = ddlOperator.SelectedValue;
            string ValueToFilter = txtValueToFilter.Text;


            CommonDALobj.tableName = tableName;
            CommonDALobj.ColumnNameToCompare = fieldName;
            CommonDALobj.oprtorToFilter = comparisonOperator;
            CommonDALobj.ValueToFilter = ValueToFilter;

            WhereCondition = CommonDALobj.getWhereCondition();

            this.onClick(sender, e);

        }

        protected void ddlOperator_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Write("HI");
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            //    this.onClick(sender, e);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void ddlColumnName_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Dropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
        {

        }

        #endregion Events

    }
}