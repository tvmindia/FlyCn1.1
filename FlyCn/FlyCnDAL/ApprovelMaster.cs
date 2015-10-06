using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

 namespace FlyCn.FlyCnDAL
{
    public class ApprovelMaster
    {

        public DataTable getDataFromApprovelMaster()
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetAprrovelLevelsDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;       
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            datatableobj = new DataTable();
            adapter.Fill(datatableobj);
            con.Close();
            return datatableobj;
        }
    }
}