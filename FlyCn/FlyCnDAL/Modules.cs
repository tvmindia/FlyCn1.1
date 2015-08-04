using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;

namespace FlyCn.FlyCnDAL
{
    public class Modules
    {
        public string cmbTextField = "ModuleID";
        public string cmbValueField = "ModuleDesc";

        public DataSet GetModules()
        {
            DataSet dataset = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();


            SqlCommand cmd = new SqlCommand("GetModules", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dataset = new DataSet();
            adapter.Fill(dataset);
            con.Close();
            return dataset;
        
        }
    }
}