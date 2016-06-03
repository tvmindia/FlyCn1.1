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
        public CWPDetails cwpDetailsObj = new CWPDetails();
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
                cwpcmd.Parameters.Add("@RevisionNo", SqlDbType.NVarChar, 10).Value = revisionNo;
                cwpcmd.Parameters.Add("@DocumentDate", SqlDbType.SmallDateTime).Value = documentDate;
                cwpcmd.Parameters.Add("@DocumentTitle", SqlDbType.NVarChar, 250).Value = documentTitle;
                cwpcmd.Parameters.Add("@Planner", SqlDbType.NVarChar, 50).Value = planner;
                cwpcmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = remarks;
                cwpcmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 50).Value = documentMaster.CreatedBy;
                cwpcmd.Parameters.Add("@CreatedDate", SqlDbType.SmallDateTime).Value = documentMaster.CreatedDate;
                SqlParameter OutparamId = cwpcmd.Parameters.Add("@OutparamId", SqlDbType.SmallInt);
                OutparamId.Direction = ParameterDirection.Output;
                SqlParameter OutRevisionId = cwpcmd.Parameters.Add("@OutRevisionID", SqlDbType.UniqueIdentifier);
                OutRevisionId.Direction = ParameterDirection.Output;
                cwpcmd.ExecuteNonQuery();
                if (int.Parse(OutparamId.Value.ToString()) != 0)
                {

                    //not successfull duplicate entry
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.InsertionSuccessData(page, "Given data already exists,Duplicate Entry!");

                }
                else
                {
                    //successfull
                    documentMaster.RevisionID = (Guid)(OutRevisionId.Value);//returning revison id to store in boq iframe hidddendfield
                    var page = HttpContext.Current.CurrentHandler as Page;
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
                cwpcmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = remarks;
                cwpcmd.Parameters.Add("@Planner", SqlDbType.NVarChar, 50).Value = planner;
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
                eObj.MandatoryFieldsData(page);
              //  throw ex;
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

        #region BindCWPData()
        public DataTable BindCWPData(string TableName, string moduleID, string category, bool ISbaseTable = false)
        {

            string FieldValue = "";
            string result = "";
            DataTable dt = null;
            dbConnection dcon = new dbConnection();
            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            try
            {
                dcon.GetDBConnection();
                SystemDefenitionDetails sd = new SystemDefenitionDetails();
                if (ISbaseTable)
                {
                    dt = sd.getFieldNames(TableName, UA.projectNo, true);
                }
                else
                {
                    dt = sd.getFieldNames(TableName, UA.projectNo);
                }

                if ((dt.Rows.Count > 0) || (dt != null))
                {
                    string temp = dt.Rows[0]["Field_Name"].ToString();
                    SqlCommand cmd = new SqlCommand("GetCWPAllocateTags", dcon.SQLCon);
                    cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 7).Value = UA.projectNo;
                    cmd.Parameters.Add("@ModuleID", SqlDbType.NVarChar, 10).Value = moduleID;
                 //   cmd.Parameters.Add("@CategoryDesc", SqlDbType.NVarChar, 25).Value = category;
                    cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 100).Value = category;
                    cmd.CommandType = CommandType.StoredProcedure;
                    // cmd.Parameters.AddWithValue("@TableName", TableName);
                    //cmd.Parameters.AddWithValue("@ModuleID", moduleID);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FieldValue = FieldValue + dt.Rows[i]["Field_Name"] + ",";
                    }
                    FieldValue = FieldValue + ",";
                    FieldValue = FieldValue.TrimEnd(',');
                    result = FieldValue + ",";
                    cmd.Parameters.AddWithValue("@p_selectedFields", result);

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    dt = new DataTable();
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);


            }
            return dt;
        }
        #endregion BindCWPData()

    }

    public class CWPDetails
    {
        ErrorHandling eObj = new ErrorHandling();
        #region PublicProperties
        public Guid itemID
        {
            get;
            set;
        }
        public Guid revisionID
        {
            get;
            set;
        }
        public string projectNo
        {
            get;
            set;
        }
        public string moduleId
        {
            get;
            set;
        }
        public string category
        {
            get;
            set;
        }
        public string keyField
        {
            get;
            set;
        }
        public string keyValue
        {
            get;
            set;
        }
        public string createBy
        {
            get;
            set;
        }
        public DateTime createdDate
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
        #endregion PublicProperties

        #region GetKeyFieldFromSys_Categories
        public DataTable GetKeyFieldFromSys_Categories(string projectNo, string moduleId, string category)
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
                cmd.CommandText = "[GetKeyFieldFromSys_Categories]";
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                cmd.Parameters.Add("@moduleID", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.Parameters.Add("@category", SqlDbType.NVarChar, 25).Value = category;
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


        #endregion GetKeyFieldFromSys_Categories

        #region  AddCWPDetails
        /// <summary>
        /// Add CWP Details into the table
        /// </summary>
        /// <returns></returns>
        public Guid AddCWPDetails()
        {

            SqlConnection con = null;
            try
            {

                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cwpcmd = new SqlCommand();
                cwpcmd.Connection = con;
                cwpcmd.CommandType = System.Data.CommandType.StoredProcedure;
                cwpcmd.CommandText = "[InsertCWPDetails]";
                cwpcmd.Parameters.Add("@RevisionID", SqlDbType.UniqueIdentifier).Value = revisionID;
                cwpcmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 10).Value = projectNo;
                cwpcmd.Parameters.Add("@ModuleID", SqlDbType.NVarChar, 10).Value = moduleId;
                cwpcmd.Parameters.Add("@Category", SqlDbType.NVarChar,25).Value = category;
                cwpcmd.Parameters.Add("@KeyField", SqlDbType.NVarChar, 50).Value = keyField;
                cwpcmd.Parameters.Add("@KeyValue", SqlDbType.NVarChar,50).Value = keyValue;
                cwpcmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar,50).Value = createBy;
                cwpcmd.Parameters.Add("@CreatedDate", SqlDbType.SmallDateTime).Value = createdDate;

                SqlParameter OutparmItemId = cwpcmd.Parameters.Add("@OutputItemID", SqlDbType.UniqueIdentifier);
                OutparmItemId.Direction = ParameterDirection.Output;

                cwpcmd.ExecuteNonQuery();

                if (OutparmItemId.Value.ToString() == "")
                {
                    //not successfull   

                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.InsertionSuccessData(page, "Insert not Successfull,Duplicate Entry!");

                }
                else
                {
                    //successfull
                    itemID = (Guid)OutparmItemId.Value;
                    var page = HttpContext.Current.CurrentHandler as Page;
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
                if (con != null)
                {
                    con.Dispose();
                }

            }
            return itemID;
        }
        #endregion  AddCWPDetails

        #region GetAllCWPDetail
        public DataTable GetAllCWPDetail(Guid revId,string projNo)
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
                cmd.CommandText = "[GetAllCWPDetail]";
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 10).Value = projNo;
                cmd.Parameters.Add("@RevisionID", SqlDbType.UniqueIdentifier).Value = revId;
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


        #endregion GetAllCWPDetail

        #region DeleteFromCWPDetail
        public void DeleteFromCWPDetail(Guid itemId)
        {

            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("DeleteFromCWPDetail", con);
                cmd.Parameters.Add("@ItemID", SqlDbType.UniqueIdentifier).Value = itemId;
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
        #endregion DeleteFromCWPDetail
    }
}
