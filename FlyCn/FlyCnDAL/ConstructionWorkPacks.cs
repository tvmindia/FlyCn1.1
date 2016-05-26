using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace FlyCn.FlyCnDAL
{
    public class ConstructionWorkPacks
    {
        #region private variables
        public DocumentMaster documentMaster = new DocumentMaster();
        ErrorHandling eObj = new ErrorHandling();
        #endregion private variables

        #region CWP_HeaderProperties
        public string revisionID
        {
            get;
            set;
        }
        public string projectNo
        {
            get;
            set;
        }
        public string revisionNo
        {
            get;
            set;
        }
        public DateTime? documentDate
        {
            get;
            set;
        }
        public string documentTitle
        {
            get;
            set;
        }
        public string planner
        {
            get;
            set;
        }
        public string remarks
        {
            get;
            set;
        }
        public string createdBy
        {
            get;
            set;
        }
        public string createdDate
        {
            get;
            set;
        }
        public string updatedBy
        {
            get;
            set;
        }
        public string updatedDate
        {
            get;
            set;
        }
        #endregion CWP_HeaderProperties

        #region AddNewCWPHeader
        public Guid AddNewCWPHeader()
        {
            SqlConnection con = null;
            try
            {
                documentMaster.AddNewDocument();//New Document and Revision is made here
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cwpcmd = new SqlCommand();
                cwpcmd.Connection = con;
                cwpcmd.CommandType = System.Data.CommandType.StoredProcedure;
                cwpcmd.CommandText = "InsertCWPHeader";
                cwpcmd.Parameters.Add("@RevisionID", SqlDbType.UniqueIdentifier).Value = documentMaster.RevisionID;
                cwpcmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 10).Value = documentMaster.ProjectNo;
                cwpcmd.Parameters.Add("@RevisionNo",SqlDbType.NVarChar,10).Value=revisionNo;
                cwpcmd.Parameters.Add("@DocumentDate",SqlDbType.SmallDateTime).Value=documentDate;
                cwpcmd.Parameters.Add("@DocumentTitle",SqlDbType.NVarChar,250).Value=documentTitle;
                cwpcmd.Parameters.Add("@Planner",SqlDbType.NVarChar,50).Value=planner;
                cwpcmd.Parameters.Add("@Remarks",SqlDbType.NVarChar).Value=remarks;
                cwpcmd.Parameters.Add("@CreatedBy",SqlDbType.NVarChar,50).Value=documentMaster.CreatedBy;
                cwpcmd.Parameters.Add("@CreatedDate",SqlDbType.SmallDateTime).Value=documentMaster.CreatedDate;
                SqlParameter OutparamId = cwpcmd.Parameters.Add("@OutparamId", SqlDbType.SmallInt);
                OutparamId.Direction = ParameterDirection.Output;
                SqlParameter OutRevisionId = cwpcmd.Parameters.Add("@OutRevisionID", SqlDbType.UniqueIdentifier);
                OutRevisionId.Direction = ParameterDirection.Output;
                cwpcmd.ExecuteNonQuery();
                if(int.Parse(OutparamId.Value.ToString())!=0)
                {

                    //not successfull duplicate entry
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.InsertionSuccessData(page,"Given data already exists,Duplicate Entry!");
                    
                }
                else
                {
                    //successfull
                     documentMaster.RevisionID = (Guid)(OutRevisionId.Value);//returning revison id to store in boq iframe hidddendfield
                     var page = HttpContext.Current.CurrentHandler as Page;
                     eObj.InsertionSuccessData(page);
                }
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
            return documentMaster.RevisionID;
        }
        #endregion AddNewCWPHeader

        #region UpdateCWPHeader
        /// <summary>
        /// Updates the BOQHeader
        /// </summary>
        public void UpdateCWPHeader()
        {
            SqlConnection con = null;
            try
            {
                // BoqHeaderDetails boqHeaderDetails = new BoqHeaderDetails();
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cwpcmd = new SqlCommand();
                cwpcmd.Connection = con;
                cwpcmd.CommandType = System.Data.CommandType.StoredProcedure;
                cwpcmd.CommandText = "UpdateCWPHeader";
                cwpcmd.Parameters.Add("@DocumentID", SqlDbType.UniqueIdentifier).Value = documentMaster.DocumentID;
                cwpcmd.Parameters.Add("@RevisionID", SqlDbType.UniqueIdentifier).Value = documentMaster.RevisionID;
                cwpcmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 10).Value = documentMaster.ProjectNo;
                cwpcmd.Parameters.Add("@ClientDocNo", SqlDbType.NVarChar, 50).Value = documentMaster.ClientDocNo;
                cwpcmd.Parameters.Add("@RevisionNo", SqlDbType.NVarChar, 10).Value = revisionNo;
                cwpcmd.Parameters.Add("@DocumentDate", SqlDbType.SmallDateTime).Value = documentDate;
                cwpcmd.Parameters.Add("@DocumentTitle", SqlDbType.NVarChar, 250).Value = documentTitle;
                cwpcmd.Parameters.Add("@Remarks",SqlDbType.NVarChar).Value=remarks;
                cwpcmd.Parameters.Add("@Planner",SqlDbType.NVarChar,50).Value=planner;
                cwpcmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar, 50).Value = updatedBy;
                cwpcmd.Parameters.Add("@UpdatedDate", SqlDbType.SmallDateTime).Value = updatedDate;
                SqlParameter OutparamId = cwpcmd.Parameters.Add("@OutparamId", SqlDbType.SmallInt);
                OutparamId.Direction = ParameterDirection.Output;

                cwpcmd.ExecuteNonQuery();
                if (int.Parse(OutparamId.Value.ToString()) != 0)
                {
                    //not successfull
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.UpdationSuccessData(page, "Not Updated");
                }
                else
                {
                    //successfull
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.UpdationSuccessData(page);
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
                    con.Dispose();
                }

            }
        }
        #endregion UpdateCWPHeader
    }
}