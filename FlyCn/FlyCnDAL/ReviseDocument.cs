using FlyCn.UIClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using Messages = FlyCn.UIClasses.Messages;
namespace FlyCn.FlyCnDAL
{
    public class ReviseDocument
    {
        public string RevisionID
        {
            get;
            set;
        }

        public string RevisionNo
        {
            get;
            set;
        }
        public string DocumentNo
        {
            get;
            set;
        }

       
        public string DocumentId
        {
            get;
            set;
        }
        public string Remarks
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }
        public int RevisionStatus
        {
            get;
            set;
        }

        public int Flag
        {
            get;
            set;
        }
        ErrorHandling eObj = new ErrorHandling();

        #region InsertReviseDocument
        public int InsertReviseDocument()
        {

            SqlConnection con = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("InsertRevisedDocument", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RevisionId", RevisionID);
                cmd.Parameters.AddWithValue("@Remarks", Remarks);
                cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                cmd.Parameters.AddWithValue("@RevisionStatus", RevisionStatus);
                cmd.Parameters.AddWithValue("@RevisionNo", RevisionNo);
              
                cmd.Parameters.AddWithValue("@DocumentId",DocumentId );
               
                cmd.ExecuteScalar();
                var page = HttpContext.Current.CurrentHandler as Page;

                eObj.InsertionSuccessData(page, Messages.documentrevisesuccessMessage);
                Flag = 1;
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

        #endregion InsertReviseDocument

        public DataTable GetDocumentIdByNo()
        {

            SqlConnection con = null;
            DataTable dt = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetDocumentIdByNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DocumentNo", DocumentNo);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
    }

}