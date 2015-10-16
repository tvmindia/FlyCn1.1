using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

 namespace FlyCn.FlyCnDAL
{
    public class ApprovelMaster
    {
        ErrorHandling eObj = new ErrorHandling();

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
        public string ApprovalDate
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


        public DataTable getDataFromVarifierMaster(int Level,string documentType,string projectNo)
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
                if (ApprovalDate != null)
                {
                    cmd.Parameters.AddWithValue("@ApprovalDate", ApprovalDate);
                }
                if (Remarks != null)
                {
                    cmd.Parameters.AddWithValue("@Remarks", Remarks);
                }

                cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                cmd.ExecuteScalar();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.InsertionSuccessData(page);
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

        #endregion InsertApprovelMaster


#region GetAllPendingApprovalsByVerifierLevel
        public DataSet GetAllPendingApprovalsByVerifierLevel(int paramverifierLevel)
        {
            SqlConnection con = null;
            DataSet ds = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetAllPendingApprovalsByVerifierLevel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@verifierLevel", SqlDbType.Int).Value = paramverifierLevel;
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

    }
}