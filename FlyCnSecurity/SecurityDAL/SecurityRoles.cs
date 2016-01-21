#region CopyRight

//All rights are reserved
//Created By   : SHAMILA T P
//Created Date : 16.1.2016


#endregion CopyRight

#region Included Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

#endregion Included Namespaces

namespace FlyCnSecurity.SecurityDAL
{
    public class SecurityRoles
    {
        DBconnection dcon = new DBconnection();

        #region Public Properties


        /// <summary>
        /// Object ID Property
        /// </summary>
        public string ObjId
        {
            get;
            set;
        }

        /// <summary>
        /// Level ID Property
        /// </summary>
        public string LevelID
        {
            get;
            set;
        }

        /// <summary>
        /// Parent ID Property
        /// </summary>
        public string ParentID
        {
            get;
            set;
        }

        /// <summary>
        /// Level Description Property
        /// </summary>
        public string LevelDesc
        {
            get;
            set;
        }

        /// <summary>
        /// Scope Property
        /// </summary>
        public string Scope
        {
            get;
            set;
        }

        /// <summary>
        ///Created By Property
        /// </summary>
        public string CreatedBy
        {
            get;
            set;
        }


        public int RoleID
        {
            get;
            set;
        }

        public string RoleName
        {
            get;
            set;
        }

        public string RoleType
        {
            get;
            set;
        }

        public int RoleScope
        {
            get;
            set;
        }

        public string ProjectGroup1
        {
            get;
            set;
        }

        public string ProjectGroup2
        {
            get;
            set;
        }

        public string ProjectGroup3
        {
            get;
            set;
        }

        public string AccessType
        {
            get;
            set;
        }

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



        #endregion Public Properties

        #region Insert Non-Project Role

        /// <summary>
        /// To register new object to object registration
        /// </summary>
        /// <returns></returns>
        public void InsertNonProjectRoles()
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = dcon.GetDBConnection();
                cmd = new SqlCommand("InsertNonProjectRoles", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = RoleID;
                cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar, 50).Value = RoleName;
                cmd.Parameters.Add("@RoleType", SqlDbType.NVarChar, 10).Value = RoleType;
                cmd.Parameters.Add("@RoleScope", SqlDbType.Int).Value = RoleScope;
                cmd.Parameters.Add("@ScopeValue", SqlDbType.NVarChar, 250).Value = ScopeValue;
                cmd.Parameters.Add("@ProjectGroup1", SqlDbType.NVarChar, 10).Value = ProjectGroup1;
                cmd.Parameters.Add("@ProjectGroup2", SqlDbType.NVarChar, 10).Value = ProjectGroup2;
                cmd.Parameters.Add("@ProjectGroup3", SqlDbType.NVarChar, 10).Value = ProjectGroup3;
                cmd.Parameters.Add("@AccessType", SqlDbType.NVarChar, 1).Value = AccessType;
                cmd.Parameters.Add("@Created_By", SqlDbType.NVarChar, 250).Value = Created_By;
                //cmd.Parameters.Add("@Created_Date", SqlDbType.SmallDateTime).Value = Created_Date;

                cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion Insert Non-Project Role

        #region Delete NonProjectRole By RoleID

        public void DeleteNonProjectRoleByRoleID()
        {
            SqlConnection conn = null;
            DataSet ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("DeleteNonProjectRoleByRoleID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleID", RoleID);

                cmd.ExecuteNonQuery();

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

        }

        #endregion Delete NonProjectRole By RoleID

        #region GetAllDetailsOfNonProjectRoles

        /// <summary>
        /// To selet all details of nonproject roles -so as to to populate gridview
        /// </summary>
        /// <returns>Dataset containing the details of all no project roles</returns>
        public DataSet GetAllDetailsOfNonProjectRoles()
        {
            SqlConnection conn = null;
            DataSet ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetAllDetailsOfNonProjectRoles", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);

                conn.Close();

                return ds;
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

        }

        #endregion GetAllDetailsOfNonProjectRoles


        #region UpdateNonProjectRolesByRoleID

        public void UpdateNonProjectRolesByRoleID()
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = dcon.GetDBConnection();
                cmd = new SqlCommand("UpdateNonProjectRolesByRoleID", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = RoleID;
                cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar, 50).Value = RoleName;
                cmd.Parameters.Add("@RoleType", SqlDbType.NVarChar, 10).Value = RoleType;
                cmd.Parameters.Add("@RoleScope", SqlDbType.Int).Value = RoleScope;
                cmd.Parameters.Add("@ProjectGroup1", SqlDbType.NVarChar, 10).Value = ProjectGroup1;
                cmd.Parameters.Add("@ProjectGroup2", SqlDbType.NVarChar, 10).Value = ProjectGroup2;
                cmd.Parameters.Add("@ProjectGroup3", SqlDbType.NVarChar, 10).Value = ProjectGroup3;
                cmd.Parameters.Add("@AccessType", SqlDbType.NVarChar, 1).Value = AccessType;
                cmd.Parameters.Add("@Created_By", SqlDbType.NVarChar, 250).Value = Created_By;
                cmd.Parameters.Add("@ScopeValue", SqlDbType.NVarChar, 250).Value = ScopeValue;

                //cmd.Parameters.Add("@Created_Date", SqlDbType.SmallDateTime).Value = Created_Date;

                cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion UpdateNonProjectRolesByRoleID

        #region Get All Role Type

        public DataSet GetRoleType()
        {
            SqlConnection conn = null;
            DataSet ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetAllRoletype", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);

                conn.Close();

                return ds;
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

        }

        #endregion Get All Role Type

        #region Get All Role Name

        public DataSet GetAllRoleName()
        {
            SqlConnection conn = null;
            DataSet ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetAllRoleName", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);

                conn.Close();

                return ds;
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

        }

        #endregion Get All Role Name

        #region Get All Role Scope

        public DataSet GetAllRoleScope()
        {
            SqlConnection conn = null;
            DataSet ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetRoleScope", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tableName", SqlDbType.NVarChar, 100).Value = TableName;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);

                conn.Close();

                return ds;
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

        }

        #endregion Get All Role Scope

        #region GetAllProjectGroup1Details

        public DataSet GetAllProjectGroup1Details()
        {
            SqlConnection conn = null;
            DataSet ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetAllProjectGroup1Details", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);

                conn.Close();

                return ds;
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

        }

        #endregion GetAllProjectGroup1Details

    }
}