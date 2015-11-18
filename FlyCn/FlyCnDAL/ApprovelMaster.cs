using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using Telerik.Web.UI;
using Messages = FlyCn.UIClasses.Messages;

 namespace FlyCn.FlyCnDAL
{
    public class ApprovelMaster
    {
        ErrorHandling eObj = new ErrorHandling();

        #region GeneralProperties
        public string RevisionID
        {
            get;
            set;
        }
        public string ApprovalID
        {
            get;
            set;
        }

        public string DocumentID
        {
            get;
            set;
        }
      
        public string DocumentType
        {
            get;
            set;
        }
        public string VerifierID
        {
            get;
            set;
        }
        public byte IsLevelManadatory
        {
            get;
            set;
        }
        public int VerifierLevel
        {
            get;
            set;
        }
        public int ApprovalStatus
        {
            get;
            set;
        }
        public DateTime ApprovalDate
        {
            get;
            set;
        }
        public string Approvaldate
        {
            get;
            set;
        }
     
        public string Remarks
        {
            get;
            set;
        }
        public string CreatedBy
        {
            get;
            set;
        }

        #endregion GeneralProperties

        #region getDataFromApprovelLevel
        public DataTable getDataFromApprovelLevel()
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetAprrovelLevelsDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;       
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            datatableobj = new DataTable();
            adapter.Fill(datatableobj);
            con.Close();
            return datatableobj;
        }

        #endregion getDataFromApprovelLevel

        #region getDataFromVarifierMaster
        public DataTable getDataFromVarifierMaster(int Level, string documentType, string projectNo)
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetVarifierDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Level", Level);
            cmd.Parameters.AddWithValue("@DocumentType", documentType);
            cmd.Parameters.AddWithValue("@ProjectNo", projectNo);
         
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            datatableobj = new DataTable();
            adapter.Fill(datatableobj);
            con.Close();
            return datatableobj;
        }

        #endregion getDataFromVarifierMaster

        #region GetVarifierEmailByIdTosentMail

        public DataTable GetVarifierEmailByIdTosentMail(int Level, string documentType, string projectNo, string varifierId)
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetVarifierDetailsByIdToSentMail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Level", Level);
            cmd.Parameters.AddWithValue("@DocumentType", documentType);
            cmd.Parameters.AddWithValue("@ProjectNo", projectNo);
            cmd.Parameters.AddWithValue("@varifierId", varifierId);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            datatableobj = new DataTable();
            adapter.Fill(datatableobj);
            con.Close();
            return datatableobj;
        }

        #endregion GetVarifierEmailByIdTosentMail

        #region getDataFromVarifierMasterDetailsByRevisoinId

        public DataTable getDataFromVarifierMasterDetailsByRevisoinId(string RevisionID)
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetVarifierDetailsByRevisionId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RevisionId", RevisionID);


            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            datatableobj = new DataTable();
            adapter.Fill(datatableobj);
            con.Close();
            return datatableobj;
        }
        #endregion  getDataFromVarifierMasterDetailsByRevisoinId

        #region getDataFromApprovalLogByLogId
        public DataTable getDataFromApprovalLogByLogId(string LogId)
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetVarifierDetailsByRevisionId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RevisionId", RevisionID);


            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            datatableobj = new DataTable();
            adapter.Fill(datatableobj);
            con.Close();
            return datatableobj;
        }

        #endregion getDataFromApprovalLogByLogId

        #region InsertApprovelMaster
        public int InsertApprovelMaster()
        {
           
            SqlConnection con = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("InsertApprovelMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ApprovalID", ApprovalID);
                cmd.Parameters.AddWithValue("@DocumentID", DocumentID);
                cmd.Parameters.AddWithValue("@RevisionID", RevisionID);
                cmd.Parameters.AddWithValue("@VerifierID", VerifierID);
                cmd.Parameters.AddWithValue("@VerifierLevel", VerifierLevel);
                cmd.Parameters.AddWithValue("@IslevelManadatory", IsLevelManadatory);
                if (ApprovalStatus != null)
                {
                    cmd.Parameters.AddWithValue("@ApprovalStatus", ApprovalStatus);
                }
                if (Approvaldate != null)
                {
                    cmd.Parameters.AddWithValue("@ApprovalDate", Approvaldate);
                }
                if (Remarks != null)
                {
                    cmd.Parameters.AddWithValue("@Remarks", Remarks);
                }

                cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                cmd.ExecuteScalar();
                var page = HttpContext.Current.CurrentHandler as Page;
                
                eObj.InsertionSuccessData(page,Messages.documentclosesuccessMessage);
                return 1;
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
                return 0;
            }
            finally
            {
                con.Close();
              
            }
        }

        #endregion InsertApprovelMaster

        #region InsertApprovalLog
        public int InsertApprovalLog()
        {
            SqlConnection con = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("InsertApprovalLog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ApprovalID", ApprovalID);
                cmd.ExecuteScalar();
                return 1;
            }
            catch (Exception ex)
            {
                //return 0;
                throw ex;

            }
            finally
            {
                con.Close();

            }
        }

        #endregion InsertApprovalLog

        #region UpdateApprovalMaster
        public int UpdateApprovalMaster(string Approvalid)
        {
            SqlConnection con = null;
            try
            {
                Guid approveid;
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApproveApprovalMasterByApprovalId";
                Guid.TryParse(Approvalid, out approveid);
                cmd.Parameters.Add("@ApprovalID", SqlDbType.UniqueIdentifier).Value = approveid;
                cmd.Parameters.Add("@ApprovalStatus", SqlDbType.Int).Value = ApprovalStatus;
                cmd.Parameters.Add("@ApprovalDate", SqlDbType.SmallDateTime).Value = ApprovalDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Remarks;
                SqlParameter outparamSendmail = cmd.Parameters.Add("@Sendmail", SqlDbType.Int);//mail status
                outparamSendmail.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int mailstatus = (int)outparamSendmail.Value;
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.UpdationSuccessData(page);
                return mailstatus;
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
              
            }
            finally
            {
                if (con != null)
                {

                    con.Dispose();

                }

            }

        }
        #endregion UpdateApprovalMaster
        #region GetAllPendingApprovalsByApprovalID
        public DataSet GetAllPendingApprovalsByApprovalID(Guid approvalID)//new get for login bypass
        {
            SqlConnection con = null;
            DataSet ds = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("[GetAllPendingApprovalsByApprovalID]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ApprovalID", SqlDbType.UniqueIdentifier).Value = approvalID;
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {
                if (con != null)
                {

                    con.Dispose();

                }
            }
            return ds;
        }
        #endregion GetAllPendingApprovalsByApprovalID

        #region GetAllPendingApprovalsByVerifierLevel
        public DataSet GetAllPendingApprovalsByVerifier(string paramverifierEmail)
        {
            SqlConnection con = null;
            DataSet ds = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetAllPendingApprovalsByVerifierEmail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@verifierEmail", SqlDbType.NVarChar,50).Value = paramverifierEmail;
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds);
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {
                if(con!=null)
                {
                    
                    con.Dispose();
                    
                }
            }
            return ds;
        }
#endregion GetAllPendingApprovalsByVerifierLevel

        #region GetallapprovalByRevisionid

        public DataSet GetAllPendingApprovalsByVerifierLevel(Guid revisionid)
        {
            SqlConnection con = null;
            DataSet ds = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetAllApprovelsByRevisionid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RevisionID", SqlDbType.UniqueIdentifier).Value = revisionid;
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Dispose();
                }
            }
            return ds;
        }
        #endregion GetallapprovalByRevisionid

        #region GetVarifierDetailsById

        public DataTable GetVarifierDetailsById(int level,string varifierId)
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetVarifierEmailByLevel", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VarifierLevel", level);
            cmd.Parameters.AddWithValue("@VerifierID", varifierId);
           
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            datatableobj = new DataTable();
            adapter.Fill(datatableobj);
            con.Close();
            return datatableobj;
        }

        #endregion GetVarifierDetailsById

        #region BindTree
        public void BindTree(Telerik.Web.UI.RadTreeView myTree)
        {
            myTree.Nodes.Clear();

        }
        #endregion BindTree

        #region LoadInputScreen

        public void LoadInputScreen(RadPane myContentPane)
        {
            myContentPane.ContentUrl = "ApprovalDocument.aspx";
        }

        #endregion LoadInputScreen

        #region GetDocDetailList

        public DataTable GetDocDetailList(string revid, string type)
        {
            SqlConnection con = null;
            DataTable dt = new DataTable();
            SqlDataAdapter da = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                UIClasses.Const Const = new UIClasses.Const();
                FlyCnDAL.Security.UserAuthendication UA;

                HttpContext context = HttpContext.Current;
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];

                string SelectQuery = "GetDocDetailsByProjectNoDocumentTypeRevisionId";
                SqlCommand cmdSelect = new SqlCommand(SelectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@projectno", "C00001");
                cmdSelect.Parameters.AddWithValue("@RevisionID", revid);
                cmdSelect.Parameters.AddWithValue("@type", type);
                da = new SqlDataAdapter(cmdSelect);
                da.Fill(dt);


            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return dt;
        }

        #endregion GetDocDetailList

        #region GetDocHeaderDetails

        public DataTable GetDocHeaderDetails(string revid, string type)
        {
            SqlConnection con = null;
            DataTable dt = new DataTable();
            SqlDataAdapter da = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                UIClasses.Const Const = new UIClasses.Const();
                FlyCnDAL.Security.UserAuthendication UA;

                HttpContext context = HttpContext.Current;
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];

                string SelectQuery = "GetDocDetailsByProjectNoRevisionID";
                SqlCommand cmdSelect = new SqlCommand(SelectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@projectno", "C00001");
                cmdSelect.Parameters.AddWithValue("@RevisionID", revid);
                cmdSelect.Parameters.AddWithValue("@type", type);
                da = new SqlDataAdapter(cmdSelect);
                da.Fill(dt);


            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return dt;
        }

        #endregion GetDocHeaderDetails

        #region GetApprovalLogId
        public DataTable GetApprovalLogId(string approvalId)
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetApprovalLogId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@approvalId",approvalId);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            datatableobj = new DataTable();
            adapter.Fill(datatableobj);
            con.Close();
            return datatableobj;
        }

        #endregion GetApprovalLogId

        #region GetUserNameByLogId
        public string GetUserNameByLogId(string LogId)
        {
            string userName="";
            int norows;
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetUserNameByLogId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LogId", LogId);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            datatableobj = new DataTable();
            adapter.Fill(datatableobj);
            norows = datatableobj.Rows.Count;
            if (norows > 0)
            {
                userName = datatableobj.Rows[0]["UserName"].ToString();
            }
            else
            {
                userName = "No User Found";
            }
            con.Close();
            return userName;
        }

        #endregion GetUserNameByLogId


        public DataTable GetAllDocumentStatus()
        {
            SqlConnection con = null;
            DataTable dt = null;
            SqlDataAdapter sda = null;
            try
            {

                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetApprovelStatus";
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                dt = new DataTable();
                sda.Fill(dt);

            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return dt;
        }
    }
}