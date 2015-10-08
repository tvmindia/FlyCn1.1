using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

 namespace FlyCn.FlyCnDAL
{
    public class ApprovelMaster
    {


        public Guid RevisionID
        {
            get;
            set;
        }
        public Guid ApprovalID
        {
            get;
            set;
        }

        public Guid DocumentID
        {
            get;
            set;
        }
        public Guid VerifierID
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




        public DataTable InsertApprovelMaster()
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("InsertApprovelMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ApprovalID", ApprovalID);
            cmd.Parameters.AddWithValue("@DocumentID", DocumentID);
            cmd.Parameters.AddWithValue("@RevisionID", RevisionID);
            cmd.Parameters.AddWithValue("@VerifierID", VerifierID);
            cmd.Parameters.AddWithValue("@VerifierLevel", VerifierLevel);
            cmd.Parameters.AddWithValue("@ApprovalStatus", ApprovalStatus);
            cmd.Parameters.AddWithValue("@ApprovalDate", ApprovalDate);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            datatableobj = new DataTable();
            adapter.Fill(datatableobj);
            con.Close();
            return datatableobj;
        }
    }
}