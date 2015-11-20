using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FlyCn.FlyCnDAL
{
    public class Users
    {

        public string UserName
        {
            get;
            set;

        }
        public string UserEMail
        {
            get;
            set;
        }
     
        public string CreatedBy
        {
            get;
            set;
        }
        public Users(string userName)
        {
            DataTable dtobj = new DataTable();
            dtobj = GetUserDetailsByUserName(userName);
            UserName = dtobj.Rows[0]["UserName"].ToString();
            UserEMail = dtobj.Rows[0]["EmailId"].ToString();         
            CreatedBy = dtobj.Rows[0]["CreatedBy"].ToString();

        }
        public DataTable GetUserDetailsByUserName(string userName)
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetUserDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", userName);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            datatableobj = new DataTable();
            adapter.Fill(datatableobj);
            con.Close();
            return datatableobj;
        }
    }
}