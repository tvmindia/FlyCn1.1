#region CopyRight

//All rights are reserved
//Created By   : SHAMILA T P
//Created Date :14.12.2015

#endregion CopyRight

#region Included Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


#endregion Included Namespaces

namespace FlyCnSecurity.SecurityDAL
{
    public class SecurityObjects
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


        //////////////////////////////NonProject role public properties

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

        
        #region Methods

        

        #region Get All Objects With ParentID Null

        /// <summary>
        /// To get all objects with parent id equals null
        /// </summary>
        /// <returns>Dataset containing level description and level ID , of objects having parent id null </returns>
        public DataSet GetAllObjectsWithParentIDNull()
        {
            SqlConnection conn = null;
            DataSet ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetAllObjectsWithParentIDNull", conn);
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

        #endregion Get All Objects With ParentID Null

        #region Get All Objects With ParentID Is Not Null

        /// <summary>
        /// To get all objects with parent id equals null
        /// </summary>
        /// <returns>Dataset containing level description and level ID , of objects having parent id null </returns>
        public DataSet GetAllObjectsWithParentIDIsNotNull()
        {
            SqlConnection conn = null;
            DataSet ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetAllObjectsWithParentIDIsNotNull", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LevelID", LevelID);

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

        #endregion Get All Objects With ParentID Null

        #region GetPreviousListItem
        /// <summary>
        /// To get previous list item 
        /// </summary>
        /// <returns></returns>
        public DataSet GetPreviousListItem()
        {
            SqlConnection conn = null;
            DataSet ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetPreviousListItem", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LevelID", LevelID);

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

        #endregion GetPreviousListItem

        #region Get Data On Navigation
        
        public DataSet GetDataOnNavigation()
        {
            SqlConnection conn = null;
            DataSet ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetDataOnNavigation", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ParentID", ParentID);

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

        #endregion Get Data On Navigation

        #region Register New Object

        /// <summary>
        /// To register new object to object registration
        /// </summary>
        /// <returns></returns>
        public void RegisterNewObject()
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = dcon.GetDBConnection();
                cmd = new SqlCommand("RegisterNewObject", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ObjId", SqlDbType.NVarChar, 10).Value = ObjId;
                cmd.Parameters.Add("@LevelID", SqlDbType.NVarChar, 20).Value = LevelID;
                cmd.Parameters.Add("@ParentID", SqlDbType.NVarChar, 20).Value = ParentID;
                cmd.Parameters.Add("@LevelDesc", SqlDbType.NVarChar, 255).Value = LevelDesc;
                cmd.Parameters.Add("@Scope", SqlDbType.NVarChar, 7).Value = Scope;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 255).Value = CreatedBy;

                cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion Register New Object

        #region Get Last ObjID

        /// <summary>
        /// To get objID from object registration ,(so as to increment it by one when s new object get inserted)
        /// </summary>
        /// <returns></returns>
        public int GetLastObjIDFromObjectRegistration()
        {
            int objID = 0;

            SqlConnection conn = null;

            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            //conn.Open();

            try
            {
                conn = dcon.GetDBConnection();

                cmd = new SqlCommand("GetLastObjIDFromObjectRegistration", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter OutparamId = cmd.Parameters.Add("@OutparamId", SqlDbType.SmallInt);
                OutparamId.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                objID = int.Parse(OutparamId.Value.ToString());
                //cmd = Convert.ToInt32(cmd.ExecuteScalar());

                return objID;
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
        #endregion Get Last ObjID

        #region Populate Gridview
       
        public DataSet PopulateGridview()
        {
            SqlConnection conn = null;
            DataSet dsGridview = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetObjectDetailstoGridview", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LevelID", LevelID);

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dsGridview = new DataSet();
                da.Fill(dsGridview);

                conn.Close();

                return dsGridview;
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

        #endregion Populate Gridview

        #region Delete Object By Id
        
        public void DeleteObjectByID()
        {
            SqlConnection conn = null;
            DataSet ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("DeleteObjectByObjID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ObjId", ObjId);

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

        #endregion Delete Object By id

        #region Get Object ID By LevelID
       
        public int GetObjectIDByLevelID()
        {
            int objID = 0;

            SqlConnection conn = null;

            SqlCommand cmd = null;

            //conn.Open();

            try
            {
                conn = dcon.GetDBConnection();

                cmd = new SqlCommand("GetObjectIDByLevelID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LevelID", LevelID);

                SqlParameter OutparamId = cmd.Parameters.Add("@OutparamId", SqlDbType.SmallInt);
                OutparamId.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                objID = int.Parse(OutparamId.Value.ToString());
                //cmd = Convert.ToInt32(cmd.ExecuteScalar());

                return objID;
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

        #endregion Get Object ID By LevelID


        public DataSet GetRegisteredModules()
        {
            DataSet dataset = null;
            SqlConnection con = null;
            
            con = dcon.GetDBConnection();

            SqlCommand cmd = new SqlCommand("GetObjectDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoleId", RoleID);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dataset = new DataSet();
            adapter.Fill(dataset);
            con.Close();
            return dataset;

        }

        #endregion Methods

    }
}