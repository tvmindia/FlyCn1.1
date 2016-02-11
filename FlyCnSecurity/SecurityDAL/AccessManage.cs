using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

 namespace FlyCnSecurity.SecurityDAL
{
    public class AccessManage
    {
        DBconnection dcon = new DBconnection();

        #region Public Properties
        public string LevelId
        {
            get;
            set;
        }
        public string ObjectId
        {
            get;
            set;
        }
        public string LevelDecription
        {
            get;
            set;
        }
        public bool Add
        {
            get;
            set;
        }
        public bool Edit
        {
            get;
            set;
        }
        public bool Delete
        {
            get;
            set;
        }
        public bool ReadOnly
        {
            get;
            set;
        }
        #endregion Public Properties
        public DataTable ObjectRegistrationDetails(string RoleId)
        {

            SqlConnection con = null;
            DataTable dt = null;

            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetObjectRegistrationDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoleId", Convert.ToInt32(RoleId));
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dt = new DataTable();
            adapter.Fill(dt);
            //dt.Columns["Add"].DataType = typeof(bool);

            con.Close();
            return dt;
        }
        public DataTable ObjectRegistrationDetailsBYLevelId(string LevelId, string RoleId)
        {

            SqlConnection con = null;
            DataTable dt = null;

            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetObjectRegistrationDetailsBYId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LevelID", LevelId);
            cmd.Parameters.AddWithValue("@RoleId", Convert.ToInt32(RoleId));
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetObjRegComboBoxData()
        {
            DataTable dt = null;
            SqlConnection con = null;

            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("ObjRegDropDwn", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;


        }
    }
}