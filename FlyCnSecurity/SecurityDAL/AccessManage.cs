#region CopyRight

//All rights are reserved
//Created By   :
//Created Date : 
//Purpose      : 

//Modified BY   : SHAMILA T P
//Modified Date : 12.2.2016
//Purpose       : To add save functionality 

#endregion CopyRight

#region Included Namespaces

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

#endregion Included Namespaces

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

        //#region Add Object Access For Roles

        //public void AddObjectAccessForRoles()
        //{
           
        //    SqlConnection conn = null;
        //    SqlCommand cmd = null;

        //    try
        //    {
        //        conn = dcon.GetDBConnection();
        //        cmd = new SqlCommand("AddObjectAccessForRoles", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        //cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = RoleID;
        //        cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 50).Value = RoleName;
        //        cmd.Parameters.Add("@RoleType", SqlDbType.NVarChar, 10).Value = RoleType;
        //        cmd.Parameters.Add("@RoleScope", SqlDbType.Int).Value = RoleScope;
        //        cmd.Parameters.Add("@ScopeValue", SqlDbType.NVarChar, 250).Value = ScopeValue;
        //        cmd.Parameters.Add("@ProjectGroup1", SqlDbType.NVarChar, 10).Value = ProjectGroup1;
        //        cmd.Parameters.Add("@ProjectGroup2", SqlDbType.NVarChar, 10).Value = ProjectGroup2;
        //        cmd.Parameters.Add("@ProjectGroup3", SqlDbType.NVarChar, 10).Value = ProjectGroup3;
        //        cmd.Parameters.Add("@AccessType", SqlDbType.NVarChar, 1).Value = AccessType;
        //        cmd.Parameters.Add("@Created_By", SqlDbType.NVarChar, 250).Value = Created_By;
        //        //cmd.Parameters.Add("@Created_Date", SqlDbType.SmallDateTime).Value = Created_Date;

        //        cmd.ExecuteNonQuery();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //#endregion Add Object Access For Roles
    }
}