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