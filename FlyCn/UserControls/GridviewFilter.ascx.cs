
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
//using System.Web.Services;



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
        public int flag = 0; //Variable which holds values 0 or 1 depending on remove button clicked or not , if clicked it gets value 1

        public event EventHandler onClick;

        //public event EventHandler searchClickFromAddClick;
        FlyCnDAL.CommonDAL CommonDALobj = new FlyCnDAL.CommonDAL();

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

        #region Make dropdownlist Into Previous Form After Add Button Click 

        //[WebMethod]
        public  void MakeDropdownlistIntoPreviousFormAfterClickingAddButton()
        {
            //FlyCnDAL.CommonDAL CommonDALobj = new FlyCnDAL.CommonDAL();

            DataSet dsColumnNames = null;

            CommonDALobj.tableName = tableName;
            dsColumnNames = CommonDALobj.getColumnNamesToFilter();


            ddlColumnName.Items.Add("--Select--");

            ddlColumnName.DataSource = dsColumnNames;
            ddlColumnName.DataTextField = "Field_Description";
            ddlColumnName.DataValueField = "Field_Name";

            ddlColumnName.DataBind();
            ddlColumnName.Items.Insert(0, "--Select--");

            ddlOperator.Items.Clear();
            ddlOperator.Items.Add("--Select--");
        }
        #endregion 

        #region create datatable on add button click and remove button click 

       /// <summary>
       /// To create datatable on add button click , or to regenerate datatable by excluding last conditon on remove condition button click
       /// </summary>
        public void CreateDatatableOnConditionRemoval()
        {
    //Add condition button clicked   
            
            if (flag == 0)
            {
                string s1 = "";
                DataTable dtCurrentTable = (DataTable)ViewState["dtForRemoval"];
                DataRow drCurrentRow = null;
                string whereConditionInGv;

                if (ViewState["gvConditionForRemoval"] != null)
                {
                    whereConditionInGv = ViewState["gvConditionForRemoval"].ToString();
                }
                else
                {
                    whereConditionInGv = "";
                }

 //Gv binding : if there is no row ,add one and condition to it until the space is full ,if space full add new row 
                if (dtCurrentTable.Rows.Count == 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    dtCurrentTable.Rows.Add(drCurrentRow);

                    int rowIndex = dtCurrentTable.Rows.Count - 1;

                    s1 = dtCurrentTable.Rows[rowIndex][0].ToString();

                    int rowLength = dtCurrentTable.Rows[rowIndex][0].ToString().Length;
                    int conditionLength = whereConditionInGv.Length;

                    if (rowLength + conditionLength < 120)
                    {
                        drCurrentRow[" "] = s1 + whereConditionInGv;
                    }

                    else
                    {
                        drCurrentRow = dtCurrentTable.NewRow();

                        dtCurrentTable.Rows[rowIndex][0] = whereConditionInGv;
                     }

                }
                else
                {
                    int rowIndex = dtCurrentTable.Rows.Count - 1;
                    int rowLength = dtCurrentTable.Rows[rowIndex][0].ToString().Length;
                    int conditionLength = whereConditionInGv.Length;
                    s1 = dtCurrentTable.Rows[rowIndex][0].ToString();
                    if (rowLength + conditionLength < 120)
                    {
                        dtCurrentTable.Rows[rowIndex][0] = s1 + " " + whereConditionInGv;
                    }

                    else
                    {
                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows.Add(drCurrentRow);
                        rowIndex = dtCurrentTable.Rows.Count - 1;
                        dtCurrentTable.Rows[rowIndex][0] = whereConditionInGv;
                    }
                }
                 }


            else
            {
                string s1 = "";//variable which holds the current row value

                DataTable dtCurrentTable = (DataTable)ViewState["dtForRemovaltest"];
                DataRow drCurrentRow = null;
                string whereConditionInGv;//incoming individual data which may appended to the row depending on the size ,otherwise added in a new row

                if (ViewState["gvConditionForRemoval"] != null)
                {
                    whereConditionInGv = ViewState["gvConditionForRemoval"].ToString();
                }
                else
                {
                    whereConditionInGv = "";
                }


                if (dtCurrentTable.Rows.Count == 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    dtCurrentTable.Rows.Add(drCurrentRow);

                    int rowIndex = dtCurrentTable.Rows.Count - 1;

                    s1 = dtCurrentTable.Rows[rowIndex][0].ToString();

                    int rowLength = dtCurrentTable.Rows[rowIndex][0].ToString().Length;
                    int conditionLength = whereConditionInGv.Length;

                    if (rowLength + conditionLength < 120)
                    {
                        //dtCurrentTable.Rows[rowIndex][0].ToString() = s1 + whereConditionInGv;
                        drCurrentRow[" "] = s1 + whereConditionInGv;
                    }

                    else
                    {
                        drCurrentRow = dtCurrentTable.NewRow();

                        dtCurrentTable.Rows[rowIndex][0] = whereConditionInGv;
                    }

                }
                else
                {
                    int rowIndex = dtCurrentTable.Rows.Count - 1;
                    int rowLength = dtCurrentTable.Rows[rowIndex][0].ToString().Length;
                    int conditionLength = whereConditionInGv.Length;
                    s1 = dtCurrentTable.Rows[rowIndex][0].ToString();
                    if (rowLength + conditionLength < 120)
                    {
                        dtCurrentTable.Rows[rowIndex][0] = s1 + " " + whereConditionInGv;
                     }

                    else
                    {
                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows.Add(drCurrentRow);
                        rowIndex = dtCurrentTable.Rows.Count - 1;
                        dtCurrentTable.Rows[rowIndex][0] = whereConditionInGv;
                    }
                 }
 }


        }

        #endregion  create datatable on add button click and remove button click

        #endregion  Public Functions

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
            lblResultReturnedCount.Text = null;

            CommonDALobj.tableName = tableName;
            dsColumnNames = CommonDALobj.getColumnNamesToFilter();
           
            if (!Page.IsPostBack)
            {
                ddlColumnName.Items.Add("--Select--");
                ddlColumnName.DataSource = dsColumnNames;

                ddlColumnName.DataTextField = "Field_Description";
                ddlColumnName.DataValueField = "Field_Name";

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
            hdnPostbackOnItemCommand.Value = "False";
            DataSet dsColumnDataType = null;

            CommonDALobj.tableName = tableName;
            //CommonDALobj.ColumnNameToCompare = ddlColumnName.SelectedItem.ToString();
            CommonDALobj.ColumnNameToCompare = ddlColumnName.SelectedItem.Value;

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

            //if (hdnClickedOrNot.Value != "clicked")
            //{
                WhereCondition = CommonDALobj.getWhereCondition();

                if (ViewState["TotalWhereConditions"] != null)
                 {

                       WhereCondition = ViewState["TotalWhereConditions"].ToString();

                 }

            //}


                //WhereCondition = CommonDALobj.getWhereCondition();

                //All conditions are in gridview,ie search button clicked only after all conditions are added
                //if (ViewState["previousRowData"] != null && ViewState["TotalWhereConditions"] != null)
                //{
                //    WhereCondition = ViewState["TotalWhereConditions"].ToString();
                //}

                ////Some conditions are in gridview,and last condition is not added. ie search button clicked without adding the last condition
                //else if (ViewState["previousRowData"] != null && ViewState["TotalWhereConditions"] == null)
                //{
                //    WhereCondition = ViewState["previousRowData"] + " AND " + WhereCondition;

                //}
            


            //else
            //{
            //    WhereCondition = ViewState["previousRowData"].ToString();
            //}


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
            lblResultReturnedCount.Text = null;
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
            ddlColumnName.DataTextField = "Field_Description";
            ddlColumnName.DataValueField = "Field_Name";

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

                //if (hdnClickedOrNot.Value != "clicked")
                //{
                    WhereCondition = CommonDALobj.getWhereCondition();
                    ViewState["IndividualWhereCondition"] = WhereCondition;
                    ViewState["condition"] = condition;
                   
              
 //Make controls into previous form after adding a condition

                txtValueToFilter.Text = "";

                DataTable dtCurrentTable = null;

                if (ViewState["dtWhereCondition"] != null)
                {
                    dtCurrentTable = (DataTable)ViewState["dtWhereCondition"];//this viewstate contains a datatable structure on page load

                }
                else
                {
                    //CreateDatatableForWhereCondition();

                    dtCurrentTable = new DataTable();
                    dtCurrentTable.Columns.AddRange(new DataColumn[1] { new DataColumn(" ", typeof(string)) });
                  }

               
                string temp = "";

                string gvTemp = "";

                if (ViewState["TotalWhereConditions"] == null)
                {
                    WhereCondition = WhereCondition;
                    ViewState["TotalWhereConditions"] = WhereCondition; // this viewstate is used to store the where condition to search ,and so used in search button click
                    whereConditionInGv = columnName + " " + operatorValue + " " + value;
                    ViewState["whereConditionInGv"] = whereConditionInGv;//this viewstate is used to store the conditions in gridview
                }

                else
                {
                    temp = ViewState["TotalWhereConditions"].ToString();
                    gvTemp = ViewState["whereConditionInGv"].ToString();

                    ViewState["TotalWhereConditions"] = " " + temp +" "+ condition+" " + WhereCondition;
                    whereConditionInGv = condition + " " + columnName + " " + operatorValue + " " + value;
                    ViewState["whereConditionInGv"] =  ViewState["whereConditionInGv"].ToString() + "|" + whereConditionInGv;
                 }

               
                //int gvTotalConditionLength = ViewState["whereConditionInGv"].ToString().Length;

                ViewState["dtForRemoval"] = dtCurrentTable;
                ViewState["dtForRemoval2"] = dtCurrentTable;


                ViewState["gvConditionForRemoval"]=whereConditionInGv;
                CreateDatatableOnConditionRemoval();

                dtCurrentTable =(DataTable) ViewState["dtForRemoval"];
                
                whereConditionInGv = ViewState["gvConditionForRemoval"].ToString();

                ViewState["dtWhereCondition"] = dtCurrentTable;
                
                //Bind Gridview with latest Row   
                gvSearch.DataSource = dtCurrentTable;
                gvSearch.DataBind();

            }
       
        }
        #endregion Add Image Button Click

        #region Remove Image Button Click
        /// <summary>
        /// To remove last condition from gridview and to generate where condition to search with remaining data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgRemove_Click(object sender, ImageClickEventArgs e)
        {
            flag = 1;
            string lastRow;
            string remainingPart;

//Generate where condition to search with remaining data when removed last condition

            string test = ViewState["TotalWhereConditions"].ToString();
            lastRow = ViewState["TotalWhereConditions"].ToString().Substring(ViewState["TotalWhereConditions"].ToString().LastIndexOf(' ') - 3);
            remainingPart = ViewState["TotalWhereConditions"].ToString().Replace(lastRow, "");
            ViewState["TotalWhereConditions"] = remainingPart;
            WhereCondition = ViewState["TotalWhereConditions"].ToString();
            ViewState["TotalWhereConditions"] = WhereCondition;

 //Remove last Condition from datatable and gridview(for this a fresh datatable is created)

            DataTable dtCurrentTable = null;
            DataRow drCurrentRow = null;
            string s1 = "";
            string whereConditionInGv;

           
                dtCurrentTable = new DataTable();
                dtCurrentTable.Columns.AddRange(new DataColumn[1] { new DataColumn(" ", typeof(string)) });
                drCurrentRow = dtCurrentTable.NewRow();
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["dtForRemovaltest"] = dtCurrentTable;
           

            string test1 = ViewState["whereConditionInGv"].ToString();//total condition seperated with pipes | are stored into this viewstate in the add condition button click
            string[] conditionsFromView = test1.Split('|');

            ViewState["dtForRemoval"] = dtCurrentTable;

            ViewState["whereConditionInGv"] = "";

            for (int i = 0; i < conditionsFromView.Length-1; i++)//loops by excluding last condition
            {
                ViewState["gvConditionForRemoval"] = conditionsFromView[i];

                CreateDatatableOnConditionRemoval();
//viewstate which holds total condition seperated with pipes | ,updated after every function call

                if (ViewState["whereConditionInGv"].ToString() == "")
                {
                    ViewState["whereConditionInGv"] = ViewState["whereConditionInGv"] + conditionsFromView[i]; // first condition doesn't need pipe
                }
                else
                {
                    ViewState["whereConditionInGv"] = ViewState["whereConditionInGv"] + "|" + conditionsFromView[i];
                }

            }

            
            gvSearch.DataSource = dtCurrentTable;
            gvSearch.DataBind();

        }
        #endregion  Remove Image Button Click

        #endregion Events

        protected void btnChange_Click(object sender, EventArgs e)
        {
           
        }

    }
}