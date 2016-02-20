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


        public bool AlreadyAdded = false;
        


        public string Created_By
        {
            get;
            set;
        }

        public DateTime Created_Date
        {
            get;
            set;
        }

        public string TableName
        {
            get;
            set;
        }


        public string ScopeValue
        {
            get;
            set;
        }


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

        public string ProjectNo
        {
            get;
            set;

        }

       
        public string Property1
        {
            get;
            set;
        }

        public string Property2
        {
            get;
            set;
        }

        public string Property3
        {
            get;
            set;
        }

        public int RoleID
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

        //--------------------------------------------------------------------------------------------------------------------------------------------------------


        #region Add Object Access For Roles

        public int AddObjectAccessForRoles()
        {
            int result = 0;
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = dcon.GetDBConnection();
                cmd = new SqlCommand("AddObjectAccessForRoles", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = RoleID;
                cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 10).Value = ProjectNo;
                cmd.Parameters.Add("@ObjId", SqlDbType.NVarChar, 10).Value = ObjectId;
                cmd.Parameters.Add("@Add", SqlDbType.Bit).Value = Add;
                cmd.Parameters.Add("@Edit", SqlDbType.Bit).Value = Edit;
                cmd.Parameters.Add("@Delete", SqlDbType.Bit).Value = Delete;
                cmd.Parameters.Add("@ReadOnly", SqlDbType.Bit).Value = ReadOnly;
                cmd.Parameters.Add("@Property1", SqlDbType.NVarChar, 10).Value = Property1;
                cmd.Parameters.Add("@Property2", SqlDbType.NVarChar, 10).Value = Property2;
                cmd.Parameters.Add("@Property3", SqlDbType.NVarChar, 10).Value = Property3;
                cmd.Parameters.Add("@Created_By", SqlDbType.NVarChar, 255).Value = Created_By;
                //cmd.Parameters.Add("@Created_Date", SqlDbType.SmallDateTime).Value = Created_Date;
                cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = RoleID;


                SqlParameter Output = new SqlParameter();
                Output.DbType = DbType.Int32;
                Output.ParameterName = "@Status";
                Output.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(Output);


                cmd.ExecuteNonQuery();

                result = Convert.ToInt32(Output.Value);



            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        #endregion Add Object Access For Roles

        public int DeleteObjectAccessForRoleByObjIdAndRoleId()
        {
            int result = 0;
            SqlConnection conn = null;
            SqlCommand cmd = null;
           
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("DeleteObjectAccessForRoleByObjIdAndRoleId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ObjId", SqlDbType.NVarChar, 10).Value = ObjectId;
                cmd.Parameters.AddWithValue("@RoleID", RoleID);


                SqlParameter Output = new SqlParameter("@Status", SqlDbType.Int);
                cmd.Parameters.Add(Output);
                Output.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                result = Convert.ToInt32(Output.Value);

                conn.Close();
             }
            catch (Exception ex)
            {
                throw ex;
            }


            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

            }
            return result;
        }
    }
}