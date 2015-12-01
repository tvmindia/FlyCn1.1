#region Copyright

///All rights are reserved 
///Created by:
///
///Change History:SHAMILA T P
///Date:Nov-13-2015
///Description :Added function to get table details to populate gridview in popup
///
///Change History:SHAMILA T P
///Date:Nov-20-2015
///Description :Added function to get column names to filter (into combobox in GridviewFilter user control)
///
///Change History:SHAMILA T P
///Date:Nov-24-2015
///Description :Added function to get datatype of column

///

#endregion Copyright

#region Included Namespaces

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using FlyCn.UserControls;

#endregion Included Namespaces

namespace FlyCn.FlyCnDAL
{
    public class CommonDAL 

    {
        #region Public Properties

        /// <summary>
        /// table name property
        /// </summary>
        public string tableName
        {
            get;
            set;
        }

        /// <summary>
        /// text field property
        /// </summary>
        public string textField
        {
            get;
            set;
        }

        /// <summary>
        /// value field property
        /// </summary>
        public string valueField
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

        public string ColumnNameToCompare
        {
            get;
            set;
        }


        public string oprtorToFilter
        {
            get;
            set;
        }

        public string dataTypeOfColumn
        {
            get;
            set;
        }

        public string columnNameDropdownlistID
        {
            get;
            set;
        }

        #endregion  Public Properties

            ErrorHandling eObj = new ErrorHandling();
            #region CommonDALMethods

        /*
            #region GetDocumentStatus
            public DataTable GetDocumentStatus()
            {
                DataTable datatableobj = null;
                SqlConnection con = null;
                try
                {
                   
                    dbConnection dcon = new dbConnection();
                    con = dcon.GetDBConnection();
                    SqlCommand cmd = new SqlCommand("GetDocumentStatusDictionary", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    datatableobj = new DataTable();
                    adapter.Fill(datatableobj);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if(con!=null)
                    {
                        con.Close();
                    }
                   
                }
                
                return datatableobj;
            }
            #endregion GetDocumentStatus
         */

            #region Get Table Details

            /// <summary>
            /// to select table details
            /// </summary>
            /// <returns></returns>
            public DataSet getTableDetails()
            {
                SqlConnection conn = null;
                dbConnection dcon = new dbConnection();
                conn = dcon.GetDBConnection();
                //conn.Open();

                SqlCommand cmd = new SqlCommand("GetMasterValuesForPopup", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@tableName1", tableName);
                cmd.Parameters.AddWithValue("@name", textField);
                cmd.Parameters.AddWithValue("@code", valueField);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);

                conn.Close();

                return ds;
            }
            #endregion Get Table Details

            #region Get Column Names By Passing Table Name (to populate drop down list) :FILTER functionality

            /// <summary>
            /// to select table details
            /// </summary>
            /// <returns></returns>
            public DataSet getColumnNamesToFilter()
            {
                SqlConnection conn = null;
                dbConnection dcon = new dbConnection();
                conn = dcon.GetDBConnection();
                //conn.Open();

                SqlCommand cmd = new SqlCommand("GetColumnNamesToFilter", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@tablename", tableName);
               
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);

                conn.Close();

                return ds;
            }
            #endregion Get Column Names By Passing Table Name

            #region Filter Gridview 

            /// <summary>
            /// to select table details
            /// </summary>
            /// <returns></returns>
            public DataSet filterGridview()
            {
                SqlConnection conn = null;
                SqlCommand cmd = null;
                dbConnection dcon = new dbConnection();
                conn = dcon.GetDBConnection();
                //conn.Open();

                //cmd = new SqlCommand("FilterGridview", conn);




                if (oprtorToFilter == "=" || oprtorToFilter == "!=" || oprtorToFilter == "<" || oprtorToFilter == ">")
                {
                    cmd = new SqlCommand("FilterGridview", conn);
                }

                else if (operatorToFilter == "Contains")
                {
                    cmd = new SqlCommand("GridviewFilterUsingContains", conn);
                }

                else if (operatorToFilter == "Starts With" || operatorToFilter == "Ends With")
                {
                    cmd = new SqlCommand("GridviewFilterUsingStartsWithOrEndsWith", conn);
                }


                //else if (operatorToFilter == ">")
                //{
                //    cmd = new SqlCommand("FilterGridviewWithOperatorGreaterThan", conn);
                //}

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@tableName", tableName);
                cmd.Parameters.AddWithValue("@fieldName", ColumnNameToCompare);
                cmd.Parameters.AddWithValue("@valueToCompare", ValueToFilter);
                cmd.Parameters.AddWithValue("@operatorToFilter", oprtorToFilter);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);

                conn.Close();

                return ds;
            }
            #endregion Filter Gridview 

            #region  Get Datatype Of Column(column name is the selected value from combobox)

            /// <summary>
            /// to select table details
            /// </summary>
            /// <returns></returns>
            public DataSet GetDatatypeOfColumn()
            {
                SqlConnection conn = null;
                dbConnection dcon = new dbConnection();
                conn = dcon.GetDBConnection();
                //conn.Open();

                SqlCommand cmd = new SqlCommand("GetDatatypeOfColumn", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@tableName", tableName);
                cmd.Parameters.AddWithValue("@fieldName", ColumnNameToCompare);
              

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);

                conn.Close();

                return ds;
            }
            #endregion Get Table Details

            #region Populate Operator combobox Based On DataType Of Column
        /// <summary>
            /// To populate combo box containing comparison operator based on the selection of dropdown list of column name
        /// </summary>
        /// <param name="ddlColumnName"></param>
            public void PopulateOperatorBasedOnDataTypeOfColumnName(DropDownList ddlColumnName)
            {
               // DropDownList ddlColumnName = (GridviewFilter).FindControl("columnNameDropdownlistID") as DropDownList;

                if (dataTypeOfColumn == "S")
                {

                    // Response.Write ("string type");
                    ddlColumnName.Items.Add("=");
                    ddlColumnName.Items.Add("!=");

                    ddlColumnName.Items.Add("Contains");
                    ddlColumnName.Items.Add("Starts With");
                    ddlColumnName.Items.Add("Ends With");

                }
                else if (dataTypeOfColumn == "N")
                {
                    ddlColumnName.Items.Add("=");
                    ddlColumnName.Items.Add("!=");
                    ddlColumnName.Items.Add("<");
                    ddlColumnName.Items.Add(">");
                }
                else if (dataTypeOfColumn == "D")
                {
                    ddlColumnName.Items.Add("=");
                    ddlColumnName.Items.Add("!=");
                    ddlColumnName.Items.Add("<");
                    ddlColumnName.Items.Add(">");
                }

            }


            #endregion Populate Operator combobox Based On DataType Of Column

            #region Get Where Condition

            /// <summary>
            /// To get where condition on search button click (to select from dataset to be binded to gridview)
            /// </summary>
            /// <returns></returns>
            public string getWhereCondition()
            {

                string WhereCondition = null;

                if (oprtorToFilter == "=" || oprtorToFilter == "!=" || oprtorToFilter == "<" || oprtorToFilter == ">")
                {
                    WhereCondition = ColumnNameToCompare + oprtorToFilter.Replace("!=", "<>") + "'" + ValueToFilter + "'";

                }


                else if (oprtorToFilter == "Starts With")
                {
                    WhereCondition = ColumnNameToCompare + " LIKE '" + ValueToFilter + "%'";
                }

                else if (oprtorToFilter == "Ends With")
                {
                    WhereCondition = ColumnNameToCompare + " LIKE  '%" + ValueToFilter + "'";
                }


                else if (oprtorToFilter == "Contains")
                {
                    WhereCondition = ColumnNameToCompare + " LIKE  '%" + ValueToFilter + "%'";
                }

                return WhereCondition;
            }

            #endregion Get Where Condition 

            #endregion CommonDALMethods
    }
}