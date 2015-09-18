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
        /// <summary>
        /// inserting new document with revision details
        /// </summary>
        public void Addnewdocument()
        {
            SqlCommand cmd = null; ;
            SqlConnection con=null;
            try
            {
                cmd = new SqlCommand();
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp";

                cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 10).Value = ProjectNo;
                cmd.Parameters.Add("@DocumentNo", SqlDbType.NVarChar, 50).Value = DocumentNo;
                cmd.Parameters.Add("@ClientDocNo",SqlDbType.NVarChar,50).Value=ClientDocNo;
                cmd.Parameters.Add("@DocumentType",SqlDbType.NVarChar,3).Value=DocumentType;
                cmd.Parameters.Add("@DocumentOwner",SqlDbType.NVarChar,50).Value=DocumentOwner;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 50).Value = CreatedBy;
                cmd.Parameters.Add("@CreatedDate",SqlDbType.SmallDateTime).Value=CreatedDate;
                cmd.Parameters.Add("@CreatedDateGMT",SqlDbType.SmallDateTime).Value=CreatedDateGMT;
                cmd.Parameters.Add("@LatestRevisionID", SqlDbType.UniqueIdentifier).Value = LatestRevisionID;
                cmd.Parameters.Add("@LatestStatus", SqlDbType.SmallInt).Value = LatestStatus;
                cmd.Parameters.Add("@LatestApprovedRevID", SqlDbType.UniqueIdentifier).Value = LatestApprovedRevID;
                //into revisiontable
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar, 50).Value = UpdatedBy;
                cmd.Parameters.Add("@UpdatedDate", SqlDbType.NVarChar, 50).Value = UpdatedDate;
                cmd.Parameters.Add("@UpdatedDateGMT", SqlDbType.SmallDateTime).Value = UpdatedDateGMT;
                cmd.Parameters.Add("@RevisionStatus", SqlDbType.SmallInt).Value = RevisionStatus;
                cmd.Parameters.Add("@ApprovedDate", SqlDbType.SmallDateTime).Value = ApprovedDate;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 255).Value = Description;
                cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Remarks;

                cmd.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(con!=null)
                {
                    con.Dispose();
                }
            }


        }



        #endregion Documentmastermethods






    }
}