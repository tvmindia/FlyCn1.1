using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;

namespace FlyCn.FlyCnDAL
{
   
    public class DocumentMaster
    {
        #region documentmasterproperties
        ErrorHandling eObj = new ErrorHandling();
       
        public Guid DocumentID
        {
            get;
            set;
        }
        public string ProjectNo
        {
            get;
            set;
        }
        public string DocumentNo
        {
            get;
            set;
        }
        public string ClientDocNo
        {
            get;
            set;
        }
        public string DocumentType//ref
        {
            get;
            set;
        }
        public string DocumentOwner
        {
            get;
            set;
        }
        public string CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public DateTime CreatedDateGMT
        {
            get;
            set;
        }
        public string LatestRevisionID//ref
        {
            get;
            set;
        }

        public int LatestStatus//ref
        {
            get;
            set;
        }
        public string LatestApprovedRevID//ref
        {
            get;
            set;
        }

        public DateTime DocDate
        {
            get;
            set;
        }
        public string DocTitle
        {
            get;
            set;
        }
        public string RevNo
        {
            get;
            set;
        }


        #endregion documentmasterproperties

        #region RevisionMasterproperties

        public Guid RevisionID
        {
            get;
            set;
        }
   
   
        public string UpdatedBy
        {
            get;
            set;
        }
        public string UpdatedDate
        {
            get;
            set;
        }
        public DateTime UpdatedDateGMT
        {
            get;
            set;
        }
        public int RevisionStatus
        {
            get;
            set;
        }
        public DateTime ApprovedDate
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public string Remarks
        {
            get;
            set;
        }
        #endregion RevisionMasterproperties

    
        #region Documentmastermethods
        #region AddNewDocument
        /// <summary>
        /// inserting new document with revision details
        /// </summary>
        public void AddNewDocument()
        {
            SqlCommand cmd = null; ;
            SqlConnection con = null;
            try
            {
                cmd = new SqlCommand();
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[InsertDocumentMasterRevision]";
                cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 10).Value = ProjectNo;
                //cmd.Parameters.Add("@DocumentNo", SqlDbType.NVarChar, 50).Value = DocumentNo;
                cmd.Parameters.Add("@ClientDocNo", SqlDbType.NVarChar, 50).Value = ClientDocNo;
                cmd.Parameters.Add("@DocumentType", SqlDbType.NVarChar, 3).Value = DocumentType;
                cmd.Parameters.Add("@DocumentOwner", SqlDbType.NVarChar, 50).Value = DocumentOwner;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 50).Value = CreatedBy;
                //cmd.Parameters.Add("@CreatedDate",SqlDbType.SmallDateTime).Value=CreatedDate;
                //cmd.Parameters.Add("@CreatedDateGMT",SqlDbType.SmallDateTime).Value=CreatedDateGMT;
                //cmd.Parameters.Add("@LatestRevisionID", SqlDbType.UniqueIdentifier).Value = LatestRevisionID;
                //cmd.Parameters.Add("@LatestStatus", SqlDbType.SmallInt).Value = LatestStatus;
                //cmd.Parameters.Add("@LatestApprovedRevID", SqlDbType.UniqueIdentifier).Value = "NULL";
                //into revisiontable
                //cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar, 50).Value = UpdatedBy;
                //cmd.Parameters.Add("@UpdatedDate", SqlDbType.NVarChar, 50).Value = UpdatedDate;
                //cmd.Parameters.Add("@UpdatedDateGMT", SqlDbType.SmallDateTime).Value = UpdatedDateGMT;
                //cmd.Parameters.Add("@RevisionStatus", SqlDbType.SmallInt).Value = "NULL";
                //cmd.Parameters.Add("@ApprovedDate", SqlDbType.SmallDateTime).Value = ApprovedDate;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 255).Value = "Static value from code behind";
                //cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Remarks;
                cmd.Parameters.Add("@outDocumentID", SqlDbType.UniqueIdentifier).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@outRevisionID", SqlDbType.UniqueIdentifier).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@outDocumentNo", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                DocumentID = (Guid)cmd.Parameters["@outDocumentID"].Value;
                RevisionID = (Guid)cmd.Parameters["@outRevisionID"].Value;
                DocumentNo = cmd.Parameters["@outDocumentNo"].Value.ToString();

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
        }
        #endregion AddNewDocument

        #region GetAllDocuments
        public DataSet GetAllBOQDocumentHeader(string projectno, string documenttype)
        {
            SqlConnection con = null;
            DataSet ds = null;
            SqlDataAdapter sda = null;
            try
            {

                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[GetAllBOQDocumentHeader]";
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 10).Value = projectno;
                cmd.Parameters.Add("@documentType", SqlDbType.NVarChar, 3).Value = documenttype;
                sda = new SqlDataAdapter();
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
                    con.Close();
                }
            }
            return ds;
        }
       #endregion GetAllDocuments

        #region BindBOQHeader
        public DataSet BindBOQHeader(Guid Revisionid)//New BOQ header binding method used to bind hiddenfields
        {
            SqlConnection con = null;
            DataSet ds = null;
            SqlDataAdapter sda = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[GetAllBindBOQHeaderByRevisionID]";
                cmd.Parameters.Add("@RevisionID", SqlDbType.UniqueIdentifier).Value = Revisionid;
                sda = new SqlDataAdapter();
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
                    con.Close();
                }
            }
            return ds;
        }
        #endregion BindBOQHeader

        #region BindBOQ
        public DataSet BindBOQ(Guid RevisionID)
        {
            SqlConnection con = null;
            DataSet ds = null;
            SqlDataAdapter sda = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[GetAllBOQDocumentHeaderByRevisionID]";
                cmd.Parameters.Add("@RevisionID", SqlDbType.UniqueIdentifier).Value = RevisionID;
                sda = new SqlDataAdapter();
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
                    con.Close();
                }

            }
            return ds;
        }
        #endregion BindBOQ

        #region GetDocumentDetailsByRevisionID
        public void GetDocumentDetailsByRevisionID(Guid RevID)
        {
            SqlConnection con = null;
            DataSet ds = null;
            RevisionID = RevID;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetDocMasterByRevisionID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RevisionID", SqlDbType.UniqueIdentifier).Value =RevID;
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds);

                //---------- assign to properties --------------

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                   //DocumentID
                    Guid documentid;
                    Guid.TryParse(dr["DocumentID"].ToString(), out documentid);
                    ProjectNo = dr["ProjectNo"].ToString();
                    DocumentNo = dr["DocumentNo"].ToString();
                    ClientDocNo = dr["ClientDocNo"].ToString();
                    DocumentType = dr["DocumentType"].ToString();
                    DocumentOwner = dr["DocumentOwner"].ToString();
                    CreatedBy = dr["CreatedBy"].ToString();
                    CreatedDate =Convert.ToDateTime(dr["CreatedDate"].ToString());
                    CreatedDateGMT =Convert.ToDateTime(dr["CreatedDateGMT"]);
                    LatestRevisionID =dr["LatestRevisionID"].ToString();
                    LatestStatus =Convert.ToInt32(dr["LatestStatus"]);
                    LatestApprovedRevID =dr["LatestApprovedRevID"].ToString();
                    UpdatedBy = dr["UpdatedBy"].ToString();
                  
                    if ((dr["UpdatedDate"].ToString()!= null) && (dr["UpdatedDate"].ToString()!=""))
                    {
                        UpdatedDate = dr["UpdatedDate"].ToString();
                        
                }
                    if ((dr["UpdatedDateGMT"].ToString() != null)&&(dr["UpdatedDateGMT"].ToString() != ""))
                    {
                        UpdatedDateGMT = Convert.ToDateTime(dr["UpdatedDateGMT"]);
                    }
                    RevisionStatus = Convert.ToInt32(dr["RevisionStatus"]);
                    if ((dr["ApprovedDate"].ToString()!=null)&&(dr["ApprovedDate"].ToString()!=""))
                    {
                        ApprovedDate = Convert.ToDateTime(dr["ApprovedDate"]);
                    }
                    
                    Description = dr["Description"].ToString();
                    Remarks = dr["Remarks"].ToString();
                    GetOtherDetailsBasedonDocType(DocumentType);
                
                }





                //-----------------------------------------------
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
        }

        public void GetOtherDetailsBasedonDocType(string DocType) {

            switch (DocType)
            {
                case "BOQ":
                    BOQHeaderDetails BOQdoc=new BOQHeaderDetails();
                    BOQdoc.GetBOQHeader(RevisionID);
                    DocDate =Convert.ToDateTime(BOQdoc.DocumentDate);
                    RevNo = BOQdoc.RevisionNo;
                    DocTitle = BOQdoc.DocumentTitle;
                    break;

                case "CWP":
                    DocumentMaster docObj = new DocumentMaster();
                    docObj.BindCWPHeader(RevisionID);
                    DocDate = Convert.ToDateTime(docObj.DocDate);
                    RevNo = docObj.RevNo;
                    DocTitle = docObj.DocTitle;

                    break;
            }
        }

        #endregion GetDocumentDetailsByRevisionID

        #region EditOwnershipName
        public int EditOwnershipName(Guid @docid,string @username)
        {
            int result = 0;
            SqlConnection con = null;
            try
            {
                UIClasses.Const Const = new UIClasses.Const();
                FlyCnDAL.Security.UserAuthendication UA;
                HttpContext context = HttpContext.Current;
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                string editQuery = "UpdateDocumentMasterByDocumentID";
                SqlCommand cmdEdit=new SqlCommand(editQuery,con);
                cmdEdit.CommandType=CommandType.StoredProcedure;
                cmdEdit.Parameters.AddWithValue("@docid",DocumentID);
                cmdEdit.Parameters.AddWithValue("@username",UA.userName);
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
        #endregion EditOwnershipName


   
        #endregion Documentmastermethods

        #region GetRevisionIdByDocumentNo
        /// <summary>
        /// Get Revision id By DocumentNo
        /// </summary>
        /// <returns>return data table</returns>
        public DataTable GetRevisionIdByDocumentNo(string documentId)
        {

            SqlConnection con = null;
            DataTable dt = null;

            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GETLeftTreeNodeRevisionIdByDocumentNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DocumentId", documentId);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        #endregion  GetRevisionIdByDocumentNo


        #region GetDocumentIdByNo
        /// <summary>
        /// Get DocumentId By DocumentNo
        /// </summary>
        /// <returns>return data table</returns>
        public DataTable GetDocumentIdByNo(string documentId)
        {

            SqlConnection con = null;
            DataTable dt = null;

            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetDocumentIdByNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DocumentNo", documentId);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        #endregion  GetDocumentIdByNo

        #region GetRevisionNumberByRevisionId
        /// <summary>
        /// Get Revision Number By Revision Id
        /// </summary>
        /// <returns>return data table</returns>
        public DataTable GetRevisionNumberByRevisionId(string RevisionID)
        {

            SqlConnection con = null;
            DataTable dt = null;

            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetRevisionNumberByRevisionId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RevisionID", RevisionID);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        #endregion  GetRevisionNumberByRevisionId

        #region GetAllCWPDocumentHeader
        public DataSet GetAllCWPDocumentHeader(string projectno, string documenttype)
        {
            SqlConnection con = null;
            DataSet ds = null;
            SqlDataAdapter sda = null;
            try
            {

                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[GetAllCWPDocumentHeader]";
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 10).Value = projectno;
                cmd.Parameters.Add("@documentType", SqlDbType.NVarChar, 3).Value = documenttype;
                sda = new SqlDataAdapter();
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
                    con.Close();
                }
            }
            return ds;
        }
        #endregion GetAllCWPDocumentHeader


        #region BindCWPHeader
        public DataSet BindCWPHeader(Guid Revisionid)//New BOQ header binding method used to bind hiddenfields
        {
            SqlConnection con = null;
            DataSet ds = null;
            SqlDataAdapter sda = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[GetAllCWPHeaderByRevisionID]";
                cmd.Parameters.Add("@RevisionID", SqlDbType.UniqueIdentifier).Value = Revisionid;
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds);
                if(ds.Tables[0].Rows.Count>0)
                {
                    DocDate =Convert.ToDateTime(ds.Tables[0].Rows[0]["DocumentDate"]);
                    RevNo = ds.Tables[0].Rows[0]["RevisionNo"].ToString();
                    DocTitle = ds.Tables[0].Rows[0]["DocumentTitle"].ToString();
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
                if (con != null)
                {
                    con.Close();
                }
            }
            return ds;
        }
        #endregion BindCWPHeader
    }
}