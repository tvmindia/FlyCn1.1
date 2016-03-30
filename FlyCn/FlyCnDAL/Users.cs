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
        public string category
        {
            get;
            set;
        }
        public string categoryDesc
        {
            get;
            set;
        }
        public string categoryHelp
        {
            get;
            set;
        }
        public int displayOrder
        {
            get;
            set;
        }
        public string categoryType
        {
            get;
            set;
        }
        public string keyField
        {
            get;
            set;
        }
        public bool keyFieldGrpBy
        {
            get;
            set;
        }
        public string moduleId
        {
            get;
            set;
        }
        public int moduleActId
        {
            get;
            set;
        }
        public string fullDesc
        {
            get;
            set;
        }
        public string shortDesc
        {
            get;
            set;
        }
        public bool failApplicable
        {
            get;
            set;
        }
        public string startDateCaption
        {
            get;
            set;
        }
        public string statusCaption
        {
            get;
            set;
        }
        public string completeDateCaption
        {
            get;
            set;
        }
        public bool plannedStartDate
        {
            get;
            set;
        }
        public bool plannedCompleteDate
        {
            get;
            set;
        }
        public bool forecastStartDate
        {
            get;
            set;
        }
        public bool forecastEndDate
        {
            get;
            set;
        }
        public bool ActualStartDate
        {
            get;
            set;
        }
        public bool status
        {
            get;
            set;
        }
        public bool ActualCompleteDate
        {
            get;
            set;
        }
        public bool wbsId
        {
            get;
            set;
        }
        public bool ActivityId
        {
            get;
            set;
        }
        public bool budgetHours
        {
            get;
            set;
        }
        public bool spentHoursProductive
        {
            get;
            set;
        }
        public bool spentHoursNonProductive
        {
            get;
            set;
        }
        public bool activityWeight
        {
            get;
            set;
        }
        public bool quantitytoInstall
        {
            get;
            set;
        }
        public bool quantityInstalled
        {
            get;
            set;
        }
        public bool unitOfMeasure
        {
            get;
            set;
        }
        public bool completedBy
        {
            get;
            set;
        }
        public bool rfiRef_No
        {
            get;
            set;
        }
        public bool rfiDate
        {
            get;
            set;
        }
        public bool afiRef_No
        {
            get;
            set;
        }
        public bool afiDate
        {
            get;
            set;
        }
        public bool remarks
        {
            get;
            set;
        }
        public string totalCaption
        {
            get;
            set;
        }
        public string passedCaption
        {
            get;
            set;
        }
        public string failedCapton
        {
            get;
            set;
        }
        public string inProgressCaption
        {
            get;
            set;
        }
        public string testedCaption
        {
            get;
            set;
        }
        public string readyCaption
        {
            get;
            set;
        }
        public string notReadyCaption
        {
            get;
            set;
        }
        public string notTestedCaption
        {
            get;
            set;
        }
        public string balanceCaption
        {
            get;
            set;
        }
        public string updatedBy
        {
            get;
            set;
        }
        public DateTime updatedDate
        {
            get;
            set;
        }
        public bool quantityVerified
        {
            get;
            set;
        }
        public string projectNo
        {
            get;
            set;
        }
        public string Managecategory
        {
            get;
            set;
        }
        public bool KpiQty
        {
            get;
            set;
        }
        public int actCode
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
                eObj.InsertionSuccessData(page);
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
                eObj.InsertionSuccessData(page);
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
                eObj.DeleteSuccessData(page);
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
                eObj.DeleteSuccessData(page);
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

                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.UpdationSuccessData(page);
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

        #region GetAllModules
        public DataTable GetAllModules(string projectNo)
        {
            SqlConnection conn = null;
            DataTable ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetAllModuleDesc", conn);
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
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

        #endregion GetAllModules

        #region InsertProjectModules
        public DataTable InsertProjectModules(string moduleId,string projectNo)
        {
            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            CreatedBy = UA.userName;
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("InsertNonProjectModules", con);
                cmd.Parameters.Add("@moduleID", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.Parameters.Add("@projectNo", SqlDbType.NChar, 7).Value = projectNo;
                cmd.Parameters.Add("@createdBy", SqlDbType.NVarChar, 50).Value = CreatedBy;
                cmd.Parameters.Add("@CreatedDate", SqlDbType.SmallDateTime).Value = DateTime.Now;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                datatableobj = new DataTable();
                adapter.Fill(datatableobj);
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.InsertionSuccessData(page);
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
        #endregion InsertProjectModules

        #region DeleteModule
        public void DeleteModule(string moduleID,string projectNo)
        {

            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("DeleteModules", con);
                cmd.Parameters.Add("@moduleID", SqlDbType.NVarChar, 10).Value = moduleID;
                cmd.Parameters.Add("@projectNo", SqlDbType.NChar, 7).Value = projectNo;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                cmd.ExecuteNonQuery();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.DeleteSuccessData(page);
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
        #endregion DeleteModule

        #region GetAllCategories
        public DataTable GetAllCategories(string moduleId)
        {
            SqlConnection conn = null;
            DataTable ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetAllCategoryByModuleID", conn);
                cmd.Parameters.Add("@moduleId", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
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

        #endregion GetAllCategories

        #region GetAllModulesByProjectNo
        public DataTable GetAllModulesByProjectNo(string projectNo)
        {
            SqlConnection conn = null;
            DataTable ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetAllprjectmodule", conn);
                cmd.Parameters.Add("@projectNo", SqlDbType.NChar, 7).Value = projectNo;
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
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

        #endregion GetAllModulesByProjectNo

        #region GetProjectNameByProjectNo
        public DataTable GetProjectNameByProjectNo()
        {
              FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
              UIClasses.Const Const= new UIClasses.Const();
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            SqlConnection conn = null;
            DataTable ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetProjectName", conn);
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 7).Value =UA.projectNo ;
              
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
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

        #endregion GetProjectNameByProjectNo

        #region UpdateDefaultProject
        public void UpdateDefaultProject(string projectNo)
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
                SqlCommand cmd = new SqlCommand("SetDefaultProject", con);
                cmd.Parameters.Add("@def_ProjectNo", SqlDbType.VarChar, 50).Value = projectNo;
                cmd.Parameters.Add("@userName", SqlDbType.VarChar, 50).Value = UA.userName;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();

              
               
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
        #endregion UpdateDefaultProject

        #region GetProjectNoByUserName
        public DataTable GetProjectNoByUserName(string userName)
         {
            SqlConnection conn = null;
            DataTable ds = null;
           
            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                SqlCommand cmd = new SqlCommand("SelectDef_ProjectNo", conn);
                cmd.Parameters.Add("@userName", SqlDbType.VarChar, 50).Value = userName;

                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
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

        #endregion GetProjectNoByUserName

        #region GetAllModulesToManage
        public DataTable GetAllModulesToManage()
        {
            SqlConnection conn = null;
            DataTable ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetAllModulesToManage", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
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

        #endregion GetAllModulesToManage

        #region InsertCategories
        public DataTable InsertCategories(string moduleId, string projectNo)
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("InsertCategories", con);
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                cmd.Parameters.Add("@ModuleId", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.Parameters.Add("@category", SqlDbType.NVarChar, 25).Value = category;
                cmd.Parameters.Add("@categoryDesc", SqlDbType.NVarChar, 100).Value = categoryDesc;
                cmd.Parameters.Add("@categoryHelp", SqlDbType.NVarChar, 255).Value = categoryHelp;
                cmd.Parameters.Add("@displayOrder", SqlDbType.Int).Value = displayOrder;
                cmd.Parameters.Add("@categoryType", SqlDbType.NVarChar, 10).Value = categoryType;
                cmd.Parameters.Add("@keyField", SqlDbType.NVarChar, 50).Value = keyField;
                cmd.Parameters.Add("@keyFieldGrpBy", SqlDbType.Bit).Value = keyFieldGrpBy;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.InsertionSuccessData(page);
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
        #endregion InsertCategories

        #region DeleteCategories
        public void DeleteCategories(string category,string projectNo)
        {

            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("DeleteCategories", con);
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 25).Value = category;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                cmd.ExecuteNonQuery();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.DeleteSuccessData(page);
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
        #endregion DeleteCategories

        #region InsertModuleActivities
        public DataTable InsertModuleActivities()
        {
            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            string updatedby = UA.userName;
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("InsertModuleActivities", con);
                cmd.Parameters.Add("@FullDesc", SqlDbType.NVarChar, 50).Value = fullDesc; ;
                cmd.Parameters.Add("@ShortDesc", SqlDbType.NVarChar, 50).Value = shortDesc;
                cmd.Parameters.Add("@FailApplicable_YN", SqlDbType.Bit).Value = failApplicable;
                cmd.Parameters.Add("@Actual_StartDate_Caption", SqlDbType.NVarChar, 25).Value = startDateCaption;
                cmd.Parameters.Add("@Status_Caption", SqlDbType.NVarChar, 25).Value = statusCaption;
                cmd.Parameters.Add("@Actual_ComplDate_Caption", SqlDbType.NVarChar, 25).Value = completeDateCaption;
                cmd.Parameters.Add("@Planned_StartDate_OnOff", SqlDbType.Bit).Value = plannedStartDate;
                cmd.Parameters.Add("@Planned_ComplDate_OnOff", SqlDbType.Bit).Value = plannedCompleteDate;
                cmd.Parameters.Add("@Forecast_StartDate_OnOff", SqlDbType.Bit).Value = forecastStartDate;
                cmd.Parameters.Add("@Forecast_EndDate_OnOff", SqlDbType.Bit).Value = forecastEndDate;
                cmd.Parameters.Add("@Actual_StartDate_OnOff", SqlDbType.Bit).Value = ActualStartDate;
                cmd.Parameters.Add("@Status_OnOff", SqlDbType.Bit).Value = status;
                cmd.Parameters.Add("@Actual_ComplDate_OnOff", SqlDbType.Bit).Value = ActualCompleteDate;
                cmd.Parameters.Add("@WBS_ID_OnOff", SqlDbType.Bit).Value = wbsId;
                cmd.Parameters.Add("@Activity_ID_OnOff", SqlDbType.Bit).Value = ActivityId;
                cmd.Parameters.Add("@Budget_Hrs_OnOff", SqlDbType.Bit).Value = budgetHours;
                cmd.Parameters.Add("@Spent_Hrs_Productive_OnOff", SqlDbType.Bit).Value = spentHoursProductive;
                cmd.Parameters.Add("@Spent_Hrs_NonProductive_OnOff", SqlDbType.Bit).Value = spentHoursNonProductive;
                cmd.Parameters.Add("@Activity_Weight_OnOff", SqlDbType.NVarChar, 10).Value = activityWeight;
                cmd.Parameters.Add("@QtyTo_Install_OnOff", SqlDbType.NVarChar, 50).Value = quantitytoInstall;
                cmd.Parameters.Add("@Qty_Installed_OnOff", SqlDbType.Bit).Value = quantityInstalled;
                cmd.Parameters.Add("@UnitOfMeasure_OnOff", SqlDbType.Bit).Value = unitOfMeasure;
                cmd.Parameters.Add("@Completed_By_OnOff", SqlDbType.Bit).Value = completedBy;
                cmd.Parameters.Add("@RFI_RefNo_OnOff", SqlDbType.Bit).Value = rfiRef_No;
                cmd.Parameters.Add("@RFI_Date_OnOff", SqlDbType.Bit).Value = rfiDate;
                cmd.Parameters.Add("@AFI_RefNo_OnOff", SqlDbType.Bit).Value = afiRef_No;
                cmd.Parameters.Add("@AFI_Date_OnOff", SqlDbType.Bit).Value = afiDate;
                cmd.Parameters.Add("@Remarks_OnOff", SqlDbType.Bit).Value = remarks;
                cmd.Parameters.Add("@Total_Caption", SqlDbType.NVarChar, 25).Value = totalCaption;
                cmd.Parameters.Add("@Passed_Caption", SqlDbType.NVarChar, 25).Value = passedCaption;
                cmd.Parameters.Add("@Failed_Caption", SqlDbType.NVarChar, 25).Value = failedCapton;
                cmd.Parameters.Add("@InProgress_Caption", SqlDbType.NVarChar, 25).Value = inProgressCaption;
                cmd.Parameters.Add("@Tested_Caption", SqlDbType.NVarChar, 25).Value = testedCaption;
                cmd.Parameters.Add("@Ready_Caption", SqlDbType.NVarChar, 25).Value = readyCaption;
                cmd.Parameters.Add("@Not_Ready_Caption", SqlDbType.NVarChar, 25).Value = notReadyCaption;
                cmd.Parameters.Add("@Not_Tested_Caption", SqlDbType.NVarChar, 25).Value = notTestedCaption;
                cmd.Parameters.Add("@Balance_Caption", SqlDbType.NVarChar, 25).Value = balanceCaption;
                cmd.Parameters.Add("@Updated_By", SqlDbType.NVarChar, 256).Value = updatedby;
                cmd.Parameters.Add("@Updated_Date", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.Add("@Qty_Verified_OnOff", SqlDbType.Bit).Value = quantityVerified;
                cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                cmd.Parameters.Add("@ModuleID", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.Parameters.Add("@ModuleActID", SqlDbType.SmallInt).Value = moduleActId;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                datatableobj = new DataTable();
                adapter.Fill(datatableobj);
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.InsertionSuccessData(page);
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
        #endregion InsertModuleActivities

        #region DeleteModuleActivities
        public void DeleteModuleActivities(string projectNo, string moduleId,string fullDesc)
        {

            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("DeleteFromActLibrary", con);
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                cmd.Parameters.Add("@moduleId", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.Parameters.Add("@fullDesc", SqlDbType.NVarChar, 50).Value = fullDesc;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                cmd.ExecuteNonQuery();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.DeleteSuccessData(page);
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
        #endregion DeleteModuleActivities

        #region GetAllModuleActivities
        public DataTable GetAllModuleActivities(string projectNo,string moduleId)
        {
            SqlConnection conn = null;
            DataTable ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetAllModuleActivities", conn);
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                cmd.Parameters.Add("@moduleId", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
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

        #endregion GetAllModuleActivities

        #region InsertManageActivities
        public DataTable InsertManageActivities()
        {
            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            string updatedby = UA.userName;
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("ManageActivities", con);
                cmd.Parameters.Add("@FullDesc", SqlDbType.NVarChar, 50).Value = fullDesc; ;
                cmd.Parameters.Add("@ShortDesc", SqlDbType.NVarChar, 50).Value = shortDesc;
                cmd.Parameters.Add("@FailApplicable_YN", SqlDbType.Bit).Value = failApplicable;
                cmd.Parameters.Add("@Actual_StartDate_Caption", SqlDbType.NVarChar, 25).Value = startDateCaption;
                cmd.Parameters.Add("@Status_Caption", SqlDbType.NVarChar, 25).Value = statusCaption;
                cmd.Parameters.Add("@Actual_ComplDate_Caption", SqlDbType.NVarChar, 25).Value = completeDateCaption;
                cmd.Parameters.Add("@Planned_StartDate_OnOff", SqlDbType.Bit).Value = plannedStartDate;
                cmd.Parameters.Add("@Planned_ComplDate_OnOff", SqlDbType.Bit).Value = plannedCompleteDate;
                cmd.Parameters.Add("@Forecast_StartDate_OnOff", SqlDbType.Bit).Value = forecastStartDate;
                cmd.Parameters.Add("@Forecast_EndDate_OnOff", SqlDbType.Bit).Value = forecastEndDate;
                cmd.Parameters.Add("@Actual_StartDate_OnOff", SqlDbType.Bit).Value = ActualStartDate;
                cmd.Parameters.Add("@Status_OnOff", SqlDbType.Bit).Value = status;
                cmd.Parameters.Add("@Actual_ComplDate_OnOff", SqlDbType.Bit).Value = ActualCompleteDate;
                cmd.Parameters.Add("@WBS_ID_OnOff", SqlDbType.Bit).Value = wbsId;
                cmd.Parameters.Add("@Activity_ID_OnOff", SqlDbType.Bit).Value = ActivityId;
                cmd.Parameters.Add("@Budget_Hrs_OnOff", SqlDbType.Bit).Value = budgetHours;
                cmd.Parameters.Add("@Spent_Hrs_Productive_OnOff", SqlDbType.Bit).Value = spentHoursProductive;
                cmd.Parameters.Add("@Spent_Hrs_NonProductive_OnOff", SqlDbType.Bit).Value = spentHoursNonProductive;
                cmd.Parameters.Add("@Activity_Weight_OnOff", SqlDbType.NVarChar, 10).Value = activityWeight;
                cmd.Parameters.Add("@QtyTo_Install_OnOff", SqlDbType.NVarChar, 50).Value = quantitytoInstall;
                cmd.Parameters.Add("@Qty_Installed_OnOff", SqlDbType.Bit).Value = quantityInstalled;
                cmd.Parameters.Add("@UnitOfMeasure_OnOff", SqlDbType.Bit).Value = unitOfMeasure;
                cmd.Parameters.Add("@Completed_By_OnOff", SqlDbType.Bit).Value = completedBy;
                cmd.Parameters.Add("@RFI_RefNo_OnOff", SqlDbType.Bit).Value = rfiRef_No;
                cmd.Parameters.Add("@RFI_Date_OnOff", SqlDbType.Bit).Value = rfiDate;
                cmd.Parameters.Add("@AFI_RefNo_OnOff", SqlDbType.Bit).Value = afiRef_No;
                cmd.Parameters.Add("@AFI_Date_OnOff", SqlDbType.Bit).Value = afiDate;
                cmd.Parameters.Add("@Remarks_OnOff", SqlDbType.Bit).Value = remarks;
                cmd.Parameters.Add("@Total_Caption", SqlDbType.NVarChar, 25).Value = totalCaption;
                cmd.Parameters.Add("@Passed_Caption", SqlDbType.NVarChar, 25).Value = passedCaption;
                cmd.Parameters.Add("@Failed_Caption", SqlDbType.NVarChar, 25).Value = failedCapton;
                cmd.Parameters.Add("@InProgress_Caption", SqlDbType.NVarChar, 25).Value = inProgressCaption;
                cmd.Parameters.Add("@Tested_Caption", SqlDbType.NVarChar, 25).Value = testedCaption;
                cmd.Parameters.Add("@Ready_Caption", SqlDbType.NVarChar, 25).Value = readyCaption;
                cmd.Parameters.Add("@Not_Ready_Caption", SqlDbType.NVarChar, 25).Value = notReadyCaption;
                cmd.Parameters.Add("@Not_Tested_Caption", SqlDbType.NVarChar, 25).Value = notTestedCaption;
                cmd.Parameters.Add("@Balance_Caption", SqlDbType.NVarChar, 25).Value = balanceCaption;
                cmd.Parameters.Add("@Updated_By", SqlDbType.NVarChar, 256).Value = updatedby;
                cmd.Parameters.Add("@Updated_Date", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.Add("@Qty_Verified_OnOff", SqlDbType.Bit).Value = quantityVerified;
                cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                cmd.Parameters.Add("@ModuleID", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar,25).Value = Managecategory;
                cmd.Parameters.Add("@ModuleActID", SqlDbType.SmallInt).Value = moduleActId;
                cmd.Parameters.Add("@KPI_Qty_YN", SqlDbType.Bit).Value = KpiQty;
                cmd.Parameters.Add("@ActCode", SqlDbType.SmallInt).Value = actCode;
                SqlParameter outParamIsUpdated = cmd.Parameters.Add("@isUpdate",SqlDbType.Int);
                outParamIsUpdated.Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                var page = HttpContext.Current.CurrentHandler as Page;
                if(Convert.ToInt16(outParamIsUpdated.Value)==1)
                {
                    
                    eObj.UpdationSuccessData(page);
                }
                else
                {
                    eObj.InsertionSuccessData(page);
                }
             
              
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
        #endregion InsertManageActivities

        #region GetAllCategory
        public DataTable GetAllCategory(string projectNo,string moduleId)
        {
            SqlConnection conn = null;
            DataTable ds = null;

            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                SqlCommand cmd = new SqlCommand("GetAllCategory", conn);
                cmd.Parameters.Add("@moduleId", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 7).Value = projectNo;

                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
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

        #endregion GetAllCategory

        #region GetAllActivities
        public DataTable GetAllActivities(string projectNo, string moduleId,string category)
        {
            SqlConnection conn = null;
            DataTable ds = null;

            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                SqlCommand cmd = new SqlCommand("GetAllActivitiesToBindGrid", conn);
                cmd.Parameters.Add("@moduleId", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                cmd.Parameters.Add("@category", SqlDbType.NVarChar, 25).Value = category;
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
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

        #endregion GetAllActivities

        #region DeleteManageActivities
        public void DeleteManageActivities(string projectNo, string moduleId, string fullDesc,string mgCategory)
        {

            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("DeleteManageActivities", con);
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                cmd.Parameters.Add("@moduleId", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.Parameters.Add("@fullDesc", SqlDbType.NVarChar, 50).Value = fullDesc;
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 25).Value = mgCategory;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                cmd.ExecuteNonQuery();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.DeleteSuccessData(page);
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
        #endregion DeleteManageActivities

        #region GetAllSys_Activities
        public DataTable GetAllSys_Activities(string projectNo, string moduleId,string fullDesc,string category)
        {
            SqlConnection conn = null;
            DataTable ds = null;

            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                SqlCommand cmd = new SqlCommand("FillActivities", conn);
                cmd.Parameters.Add("@moduleId", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                if (category != "")
                {
                    cmd.Parameters.Add("@category", SqlDbType.NVarChar, 25).Value = category;
                }
                cmd.Parameters.Add("@fullDesc", SqlDbType.NVarChar, 50).Value = fullDesc;
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
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

        #endregion GetAllActivities

        #region SelectAllCategories
        public DataTable SelectAllCategories()
        {
            SqlConnection conn = null;
            DataTable ds = null;

            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                SqlCommand cmd = new SqlCommand("SelectAllCategories", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
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

        #endregion SelectAllCategories

        #region GetActivitiesToFindActCode
        public DataTable GetActivitiesToFindActCode(string projectNo, string moduleId)
        {
            SqlConnection conn = null;
            DataTable ds = null;

            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                SqlCommand cmd = new SqlCommand("GetActivitiesToFindActCode", conn);
                cmd.Parameters.Add("@moduleId", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 7).Value = projectNo;

                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
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
        #endregion GetActivitiesToFindActCode

        #region Getsys_ActLibraryToFindModuleActId
        public DataTable Getsys_ActLibraryToFindModuleActId(string projectNo, string moduleId)
        {
            SqlConnection conn = null;
            DataTable ds = null;

            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                SqlCommand cmd = new SqlCommand("Getsys_ActLibraryToFindModuleActId", conn);
                cmd.Parameters.Add("@moduleId", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 7).Value = projectNo;

                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
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
        #endregion Getsys_ActLibraryToFindModuleActId

        #region ValidateFullDesc
        public bool ValidateFullDesc(string CheckFullDesc,string moduleId,string projectNo,string category)
        {
            bool flag;
            SqlConnection con = null;
            try
            {

                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetAllDescriptions", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@moduleId", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                cmd.Parameters.Add("@fullDesc", SqlDbType.NVarChar, 50).Value = CheckFullDesc;
                cmd.Parameters.Add("@category", SqlDbType.NVarChar, 25).Value = category;
                SqlParameter outflag = cmd.Parameters.Add("@flag", SqlDbType.Bit);
                outflag.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                flag = (bool)outflag.Value;
                if (flag == true)
                {
                    return flag;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            return false;
        }

        #endregion ValidateFullDesc

        #region ValidateShortDesc
        public bool ValidateShortDesc(string CheckShortDesc, string moduleId, string projectNo, string category)
        {
            bool flag;
            SqlConnection con = null;
            try
            {

                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("ValidateShortDescription", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@moduleId", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                cmd.Parameters.Add("@shortDesc", SqlDbType.NVarChar, 50).Value = CheckShortDesc;
                cmd.Parameters.Add("@category", SqlDbType.NVarChar, 25).Value = category;
                SqlParameter outflag = cmd.Parameters.Add("@flag", SqlDbType.Bit);
                outflag.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                flag = (bool)outflag.Value;
                if (flag == true)
                {
                    return flag;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            return false;
        }

        #endregion ValidateShortDesc

        #region GetModuleId
        public DataTable GetModuleId(string moduleDesc)
        {
            SqlConnection conn = null;
            DataTable ds = null;

            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                SqlCommand cmd = new SqlCommand("GetModuleId", conn);
                cmd.Parameters.Add("@moduleDesc", SqlDbType.NVarChar, 50).Value = moduleDesc;
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
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
        #endregion GetModuleId

    }
    }
