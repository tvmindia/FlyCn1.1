#region Copyright

///All rights are reserved 
///Created by:
///
///Change History:SHAMILA T P
///Date:Nov-13-2015

#endregion Copyright

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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


            //#region GetRevisionIdByNo
            ///// <summary>
            ///// Select GetRevisionIdByNo
            ///// </summary>
            ///// <returns></returns>
            //public DataTable GetRevisionIdByNo(string RevisionNo)
            //{
            //    SqlConnection con = null;
            //    DataTable dt = null;
            //    try
            //    {


            //        dbConnection dcon = new dbConnection();
            //        con = dcon.GetDBConnection();
            //        SqlCommand cmd = new SqlCommand("GetRevisionIdByRevisionNo", con);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@RevisionNo", RevisionNo);
            //        SqlDataAdapter adapter = new SqlDataAdapter();
            //        adapter.SelectCommand = cmd;
            //        dt = new DataTable();
            //        adapter.Fill(dt);
            //        con.Close();
            //        return dt;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}
            //#endregion GetRevisionIdByNo
            #endregion CommonDALMethods
    }
}