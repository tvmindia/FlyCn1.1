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

        public DataTable getDataFromApprovelLevel()
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


        public DataTable getDataFromVarifierMaster(int Level,string documentType,string projectNo)
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetVarifierDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Level", Level);
            cmd.Parameters.AddWithValue("@DocumentType", documentType);
            cmd.Parameters.AddWithValue("@ProjectNo", projectNo);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            datatableobj = new DataTable();
            adapter.Fill(datatableobj);
            con.Close();
            return datatableobj;
        }
    }
}