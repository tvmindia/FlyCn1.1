using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace FlyCn.FlyCnDAL
{
    public class DocumentMaster
    {
        #region documentmasterproperties

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
        public Guid LatestRevisionID//ref
        {
            get;
            set;
        }

        public int LatestStatus//ref
        {
            get;
            set;
        }
        public int LatestApprovedRevID//ref
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
                cmd.ExecuteNonQuery();
                DocumentID = (Guid)cmd.Parameters["@outDocumentID"].Value;
                RevisionID = (Guid)cmd.Parameters["@outRevisionID"].Value;
            }
            catch (Exception ex)
            {
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

        #region BindBOQ
        public DataTable BindBOQ(string projectno,string documenttype)
        {
            SqlConnection con = null;
            DataTable dt = null;
            SqlDataAdapter sda=null;
            try
            {
                
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[GetAllDocuments]";
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 10).Value = projectno;
                cmd.Parameters.Add("@documentType", SqlDbType.NVarChar, 3).Value = documenttype;
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                dt = new DataTable();
                sda.Fill(dt);
                return dt;
               
            }
            catch(Exception ex)
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
           
           
            
        }

        #endregion BindBOQ
        #region
        #endregion




        #endregion Documentmastermethods






    }
}