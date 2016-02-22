using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FlyCn.UIClasses;
using FlyCnSecurity.SecurityDAL;
using System.Web.UI;

namespace FlyCn.FlyCnDAL
{
    public class Users
    {

        #region public properties
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

        public string Password
        {
            get;
            set;
        }

        public string CreatedBy
        {
            get;
            set;
        }
        public string Theme
        {
            get;
            set;
        }
        public bool Active
        {
            get;
            set;
        }

        public string TableName
        {
            get;
            set;
        }
        public string UserId
        {
            get;
            set;
        }
        public int RoleID
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public string UpdatedBy
        {
            get;
            set;
        }
        public DateTime UpdatedDate
        {
            get;
            set;
        }
        #endregion public properties

        #region private variables
        ErrorHandling eObj = new ErrorHandling();
        #endregion private variables
        /// <summary>
        /// Get User Details By User Name
        /// </summary>
        /// <param name="userName">User Name</param>
        public Users(string userName)
        {
            DataTable dtobj = new DataTable();
            dtobj = GetUserDetailsByUserName(userName);
            UserName = dtobj.Rows[0]["UserName"].ToString();
            UserEMail = dtobj.Rows[0]["EmailId"].ToString();         
            CreatedBy = dtobj.Rows[0]["CreatedBy"].ToString();

        }

        /// <summary>
        ///  Get User Details By User Email
        /// </summary>
        /// <param name="userEmail">User Email</param>
        /// <param name="Type">1 = By Email</param>
        public Users(string userEmail,int Type)
        {
            DataTable dtobj = new DataTable();
            dtobj = GetUserDetailsByUserEmail(userEmail);
            UserName = dtobj.Rows[0]["UserName"].ToString();
            UserEMail = dtobj.Rows[0]["EmailId"].ToString();
            CreatedBy = dtobj.Rows[0]["CreatedBy"].ToString();

        }

        public Users()
        {
            DataTable dtObj = new DataTable();
            dtObj = GetAllUsers();

        }

        #region GetUserDetailsByUserName
        public DataTable GetUserDetailsByUserName(string userName)
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetUserDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", userName);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                datatableobj = new DataTable();
                adapter.Fill(datatableobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return datatableobj;
        }
        #endregion GetUserDetailsByUserName

        #region GetUserDetailsByUserEmail
        public DataTable GetUserDetailsByUserEmail(string userEmail)
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetUserDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", userEmail);
                cmd.Parameters.AddWithValue("@IsEmail", 1);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                datatableobj = new DataTable();
                adapter.Fill(datatableobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return datatableobj;
        }
        #endregion GetUserDetailsByUserEmail

        #region GetAllUserDetails
        public DataTable GetAllUsers()
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetAllUserDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                datatableobj = new DataTable();
                adapter.Fill(datatableobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return datatableobj;
        }
        #endregion GetAllUserDetails

        #region InsertM_Users
        public void InsertM_Users()
        {
            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            CreatedBy = UA.userName;
           
            SqlConnection con = null;
           
            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("InsertM_Users", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@PassWord", Password);
                cmd.Parameters.AddWithValue("@EmailId", UserEMail);
                cmd.Parameters.AddWithValue("@Theme", Theme);
                cmd.Parameters.AddWithValue("@Active", Active);
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);

                cmd.ExecuteNonQuery();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.InsertionSuccessData(page,"New User Created Successfully..!!!");
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {
                con.Close();
            }
           
        }
        #endregion InsertM_Users

        #region ValidateUsername
        public bool ValidateUsername(string CheckUser)
        {
            bool flag;
            SqlConnection con = null;
            try
            {
             
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("CheckUserName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = CheckUser;
                SqlParameter outflag = cmd.Parameters.Add("@flag", SqlDbType.Bit);
                outflag.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                flag = (bool)outflag.Value;
                if(flag==true)
                {
                    return flag;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(con!=null)
                {
                    con.Close();
                }
            }

            return false;
        }

        #endregion ValidateUsername

        #region SelectAllUsers
        public DataTable SelectUsersToDropDown()
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            DBconnection dcon = new DBconnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("SelectAllUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                datatableobj = new DataTable();
                adapter.Fill(datatableobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return datatableobj;
        }
        #endregion SelectAllUsers

        #region SelectProjectRoles
        public DataTable ProjectLevelToDropDown()
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            DBconnection dcon = new DBconnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("SelectProjectLevel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                datatableobj = new DataTable();
                adapter.Fill(datatableobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return datatableobj;
        }
        #endregion SelectProjectRoles

        #region CurrentRoles
        public DataTable CurrentUserRoles(string UserID)
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            DBconnection dcon = new DBconnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("DisplayUserRoles", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 256).Value = UserID;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                datatableobj = new DataTable();
                adapter.Fill(datatableobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return datatableobj;
        }
        #endregion CurrentRoles

        #region AssignRoles
        public DataTable AssignUserRoles(int RoleScope, string ScopeValue)
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            DBconnection dcon = new DBconnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("AssignUserRoles", con);
                cmd.Parameters.Add("@RoleScope", SqlDbType.Int).Value = RoleScope;
                cmd.Parameters.Add("@ScopeValue", SqlDbType.VarChar).Value = ScopeValue;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                datatableobj = new DataTable();
                adapter.Fill(datatableobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return datatableobj;
        }
        #endregion AssignRoles

        #region InsertAssignedRoles
        public DataTable InsertAssignedRoles()
        {
            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            CreatedBy = UA.userName;
            DataTable datatableobj = null;
            SqlConnection con = null;
            DBconnection dcon = new DBconnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("SaveAssignedRoles", con);
                cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 256).Value = UserId;
                cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = RoleID;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 50).Value = CreatedBy;
                cmd.Parameters.Add("@CreatedDate", SqlDbType.SmallDateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar, 50).Value = CreatedBy;
                cmd.Parameters.Add("@UpdatedDate", SqlDbType.SmallDateTime).Value = DateTime.Now;
                cmd.CommandType = CommandType.StoredProcedure;
               
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                
                datatableobj = new DataTable();
                adapter.Fill(datatableobj);
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.InsertionSuccessData(page,"Data Saved Successfully..!!!");
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return datatableobj;
        }
        #endregion InsertAssignedRoles

        #region DeleteUser
        public void DeleteUser(string UserID,int RoleID)
        {
            
            SqlConnection con = null;
            DBconnection dcon = new DBconnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("DeleteRoles", con);
                cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 256).Value = UserID;
                cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = RoleID;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                cmd.ExecuteNonQuery();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.InsertionSuccessData(page, "Data Updated Successfully..!!!");
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {
                con.Close();
            }
          
        }
        #endregion DeleteUser

        #region Get All Role Name

        public DataSet GetAllRoleName()
        {
            SqlConnection conn = null;
            DataSet ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DBconnection dcon = new DBconnection();
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
            DBconnection dcon = new DBconnection();
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

        #region DeleteM_User
        public void DeleteM_User(string UserID)
        {

            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("DeleteUserDetails", con);
                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = UserID;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                cmd.ExecuteNonQuery();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.InsertionSuccessData(page, "User Deleted Successfully..!!!");
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
        #endregion DeleteM_User

        #region EditM_users
        public int EditM_users(string UserID)
        {
            int result = 0;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            try
            {

                con = dcon.GetDBConnection();
                string editQuery = "UpdateUserDetails";
                SqlCommand cmdEdit = new SqlCommand(editQuery, con);
                cmdEdit.CommandType = CommandType.StoredProcedure;
                cmdEdit.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = UserID;
                cmdEdit.Parameters.Add("@PassWord", SqlDbType.VarChar, 50).Value = Password;
                cmdEdit.Parameters.Add("@EmailId", SqlDbType.VarChar, 50).Value = UserEMail;
                cmdEdit.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
                result = cmdEdit.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        #endregion EditM_users
    }
}