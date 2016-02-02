
#region CopyRight

//All rights are reserved
//Created By   : SHAMILA T P
//Created Date : Feb-1-2016

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
    public class SecurityUsers
    {

        #region Global Variables

        DBconnection dcon = new DBconnection();

        public string TotalPermission = string.Empty;
        public string permission = string.Empty;

        public string ObjId
        {
            get;
            set;
        }


        public int RoleID
        {
            get;
            set;
        }

        public string LevelID
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }


        public bool GlobalAdd = false;

        public bool GlobalEdit = false;

        public bool GlobalDelete = false;

        public bool GlobalReadOnly = false;

        #endregion Global Variables

//------------ * Getting Permission String * --------//

        #region Get LevelID By ObjID

        /// <summary>
        ///Get level id by obj id to go to upper hierarchy by trimming levelid
        /// </summary>
        /// <returns></returns>
        public string GetLevelIDByObjID()
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            
            try
            {
                conn = dcon.GetDBConnection();

                cmd = new SqlCommand("GetLevelIDByObjID", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@objID", SqlDbType.NVarChar, 10).Value = ObjId;

                SqlParameter levelID = cmd.Parameters.Add("@levelID", SqlDbType.VarChar, 20);
                levelID.Direction = ParameterDirection.Output;


                cmd.ExecuteNonQuery();
                LevelID = levelID.Value.ToString();
                
                return LevelID;
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

        #endregion Get LevelID By ObjID

        #region Get ObjectID By LevelID
        public int GetObjectIDByLevelID()
        {
            int objID = 0;

            SqlConnection conn = null;
            SqlCommand cmd = null;

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

        #endregion Get ObjectID By LevelID

        #region Get Object Access For Role

        public DataSet GetObjectAccessForRole()
        {
            SqlConnection conn = null;
            DataSet dsObjectAccess = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetObjectAccessForRole", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ObjId", ObjId);
                cmd.Parameters.AddWithValue("@RoleID", RoleID);

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dsObjectAccess = new DataSet();
                da.Fill(dsObjectAccess);

                conn.Close();

                return dsObjectAccess;
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
        #endregion Get Object Access For Role

        #region Get Permission String

        /// <summary>
        /// To get permission string
        /// </summary>
        /// <param name="objID"></param>
        public string GetPermissionString(string objID, string rollID)
        {
  //---------*Case of multiple roles : get individual roles by spliting the user input and call the fn for each role and add all permission to get total permission*-----------//
            if (rollID.Contains(','))
            {

                string[] roleIdArray = rollID.Split(',');
                int roleIdCount = roleIdArray.Length;

                for (int i = 0; i < roleIdCount; i++)
                {
                    rollID = roleIdArray[i];
                    TotalPermission = GetPermissionString(objID, rollID);

                }
            }



            int rowCount = 0;
            string Add = string.Empty;
            string Edit = string.Empty;
            string Delete = string.Empty;
            string ReadOnly = string.Empty;

            DataSet dsObjectAccess = null;

            dsObjectAccess = new DataSet();

           RoleID = Convert.ToInt32(rollID);
           ObjId = objID;
            dsObjectAccess = GetObjectAccessForRole();

            //----------------* To go to the top hierarchy if the particular object does'nt have permission(NULL) *---------//

            if (dsObjectAccess.Tables[0].Rows.Count == 0)
            {
                ObjId = objID;
                string levelID =GetLevelIDByObjID();

                int count = levelID.Split('.').Length - 1;

                for (int i = count; i >= 1; i--)
                {
                    string str = levelID;
                    string ext = levelID.Substring(0, str.LastIndexOf("."));

                    levelID = ext;

                  LevelID = ext;
                    objID =GetObjectIDByLevelID().ToString();

                    TotalPermission = GetPermissionString(objID, rollID);

                }
            }

//----------------*Get the permission as object itself having permission *--------------//

            else
            {
                rowCount = dsObjectAccess.Tables[0].Rows.Count;

                if (rowCount > 0)
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        Add = dsObjectAccess.Tables[0].Rows[i][0].ToString();
                        Edit = dsObjectAccess.Tables[0].Rows[i][1].ToString();
                        Delete = dsObjectAccess.Tables[0].Rows[i][2].ToString();
                        ReadOnly = dsObjectAccess.Tables[0].Rows[i][3].ToString();

                        bool add = Convert.ToBoolean(Add);
                        bool edit = Convert.ToBoolean(Edit);
                        bool delete = Convert.ToBoolean(Delete);
                        bool readOnly = Convert.ToBoolean(ReadOnly);

                        string permissionTemp = add.ToString() + "," + edit.ToString() + "," + delete.ToString() + "," + readOnly.ToString();
                        permission = AddPermissionForMultipleRoles(permissionTemp);//-------*Permission of individual object splitted by comma is passed to the fn to add permission *----------//

                    }

                }

            }

            return permission;

        }

        #endregion  Get Permission String

        #region Add Permission For Multiple Roles
        /// <summary>
        /// To add permission of multiple roles
        /// </summary>
        /// <param name="PermissionInBit"></param>
        /// <returns></returns>
        public string AddPermissionForMultipleRoles(string PermissionInBit) //-----* Function recieves  Permission string of individual object splitted by comma *-------//
        {

            string tot_Permission = string.Empty;
            string[] permissionArray = PermissionInBit.Split(',');

            //----* Split permission string to get AERD values seperately *-------//

            string addChar = permissionArray[0];
            string editChar = permissionArray[1];
            string deletChar = permissionArray[2];
            string readonlyChar = permissionArray[3];

            bool add = Convert.ToBoolean(addChar);
            bool edit = Convert.ToBoolean(editChar);
            bool delete = Convert.ToBoolean(deletChar);
            bool readOnly = Convert.ToBoolean(readonlyChar);

            //----* Add permission of current object with public variables for AERD which is defined in role access class *------//

            GlobalAdd = add |GlobalAdd;
           GlobalEdit = edit | GlobalEdit;
            GlobalDelete = delete | GlobalDelete;
            GlobalReadOnly = readOnly |GlobalReadOnly;

            //Conversion of permission to AEDR format instead of boolean values
            if (GlobalAdd == true)
            {
                tot_Permission = tot_Permission + "A";
            }
            if (GlobalEdit == true)
            {
                tot_Permission = tot_Permission + "E";
            }
            if (GlobalDelete == true)
            {
                tot_Permission = tot_Permission + "D";
            }
            if (GlobalReadOnly == true)
            {
                tot_Permission = tot_Permission + "R";
            }

            if (GlobalAdd == false && GlobalEdit == false && GlobalDelete == false && GlobalReadOnly == false)
            {
                tot_Permission = "No access";
            }


            //tot_Permission = roleAccessObj.Add.ToString() + roleAccessObj.Edit.ToString() + roleAccessObj.Delete.ToString() + roleAccessObj.ReadOnly.ToString();

            return tot_Permission;
        }

        #endregion Add Permission For Multiple Roles

//-------------------------------------------------------//

//-------Access Permission Of A Particular User------//

        #region Get All Details Of UsersInRoles
        public DataTable GetAllDetailsOfUsersInRoles(string UserName)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataAdapter adapter = null;
            DataTable datatableobj = null;

            try
            {
                conn = dcon.GetDBConnection();
                cmd = new SqlCommand("GetAllUsersInRoles", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 256).Value = UserName;
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                datatableobj = new DataTable();
                adapter.Fill(datatableobj);

            }
            catch (Exception)
            {

                throw;
            }


            return datatableobj;
        }

        #endregion Get All Details Of UsersInRoles

        #region Get User Access

        public string GetUserAccess(string UserName, string LevelDesc,string ProjectNo=null)
        {
            string usrAccess = string.Empty;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            DataTable dtUserInRoles = null;

            try
            {
                conn = dcon.GetDBConnection();

                cmd = new SqlCommand("GetObjIDByLevelDesc", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LevelDesc", SqlDbType.NVarChar, 255).Value = LevelDesc;

                SqlParameter OutparamId = cmd.Parameters.Add("@ObjId", SqlDbType.NVarChar, 10);
                OutparamId.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                string objID = OutparamId.Value.ToString();

                dtUserInRoles = GetAllDetailsOfUsersInRoles(UserName);
                int roleId = Convert.ToInt32(dtUserInRoles.Rows[0]["RoleID"]);

                usrAccess = GetPermissionString(objID, roleId.ToString());

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
            return usrAccess;
        }

        #endregion Get User Access


//-------------------------------------------------------//
    }
}