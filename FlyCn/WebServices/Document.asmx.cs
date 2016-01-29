using FlyCn.FlyCnDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace FlyCn.WebServices
{
    /// <summary>
    /// Summary description for Document
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Document : System.Web.Services.WebService
    {


        #region Approvals
        [WebMethod]
        public string Approvals(string username)
        {  //return msg data initialization
            DataSet ds = new DataSet();
            try
            {   //Retrieving details
                FlyCnDAL.Users User = new FlyCnDAL.Users(username);
                ApprovelMaster approvelMaster = new ApprovelMaster();
                ds = approvelMaster.GetAllPendingApprovalsByVerifier(User.UserEMail);
            }
            catch (Exception ex)
            {
                //Return error message
                DataTable ErrorMsg = new DataTable();
                ErrorMsg.Columns.Add("Flag", typeof(Boolean));
                ErrorMsg.Columns.Add("Message", typeof(String));
                DataRow dr = ErrorMsg.NewRow();
                dr["Flag"] = false;
                dr["Message"] = ex.Message;
                ErrorMsg.Rows.Add(dr);
                ds.Tables.Add(ErrorMsg);
            }
            finally
            {
            }
            return getDbDataAsJSON(ds);
        }
        #endregion

        #region ApproveItem
        [WebMethod]
        public string ApproveItem(string username, string approvid, string revisionid,string DocOwner, string remarks)
        {  //return msg data initialization   approvid, revisionid, DocOwner,UA.userName);
            DataSet ds = new DataSet();
            try
            {   //Retrieving details
                FlyCnDAL.Users User = new FlyCnDAL.Users(username);
                ApprovelMaster approvelMaster = new ApprovelMaster();
                approvelMaster.RevisionID = revisionid;
                approvelMaster.ApprovalID = approvid;
                approvelMaster.ApprovalStatus = 4;//4 means approved
                approvelMaster.ApprovalDate = System.DateTime.Now;
                approvelMaster.Remarks = remarks;
                approvelMaster.UpdateApprovalMaster(approvid, revisionid, DocOwner, username);
                //success message
                DataTable SuccessMsg = new DataTable();
                SuccessMsg.Columns.Add("Flag", typeof(Boolean));
                SuccessMsg.Columns.Add("Message", typeof(String));
                DataRow dr = SuccessMsg.NewRow();
                dr["Flag"] = true;
                dr["Message"] = "Approved";
                SuccessMsg.Rows.Add(dr);
                ds.Tables.Add(SuccessMsg);
            }
            catch (Exception ex)
            {
                //Return error message
                DataTable ErrorMsg = new DataTable();
                ErrorMsg.Columns.Add("Flag", typeof(Boolean));
                ErrorMsg.Columns.Add("Message", typeof(String));
                DataRow dr = ErrorMsg.NewRow();
                dr["Flag"] = false;
                dr["Message"] = ex.Message;
                ErrorMsg.Rows.Add(dr);
                ds.Tables.Add(ErrorMsg);
            }
            finally
            {
            }
            return getDbDataAsJSON(ds);
        }
        #endregion

        #region DeclineItem
        [WebMethod]
        public string DeclineItem(string username, string approvid, string revisionid, string DocOwner, string remarks)
        {  //return msg data initialization   approvid, revisionid, DocOwner,UA.userName);
            DataSet ds = new DataSet();
            try
            {   //Retrieving details
                FlyCnDAL.Users User = new FlyCnDAL.Users(username);
                ApprovelMaster approvelMaster = new ApprovelMaster();
                approvelMaster.RevisionID = revisionid;
                approvelMaster.ApprovalID = approvid;
                approvelMaster.ApprovalStatus = 2;
                approvelMaster.ApprovalDate = System.DateTime.Now;
                approvelMaster.Remarks = remarks;
                approvelMaster.DeclineApprovalMaster(approvid, revisionid, DocOwner, username);
                //success message
                DataTable SuccessMsg = new DataTable();
                SuccessMsg.Columns.Add("Flag", typeof(Boolean));
                SuccessMsg.Columns.Add("Message", typeof(String));
                DataRow dr = SuccessMsg.NewRow();
                dr["Flag"] = true;
                dr["Message"] = "Declined";
                SuccessMsg.Rows.Add(dr);
                ds.Tables.Add(SuccessMsg);
            }
            catch (Exception ex)
            {
                //Return error message
                DataTable ErrorMsg = new DataTable();
                ErrorMsg.Columns.Add("Flag", typeof(Boolean));
                ErrorMsg.Columns.Add("Message", typeof(String));
                DataRow dr = ErrorMsg.NewRow();
                dr["Flag"] = false;
                dr["Message"] = ex.Message;
                ErrorMsg.Rows.Add(dr);
                ds.Tables.Add(ErrorMsg);
            }
            finally
            {
            }
            return getDbDataAsJSON(ds);
        }
        #endregion

        #region RejectItem
        [WebMethod]
        public string RejectItem(string username, string approvid, string revisionid, string DocOwner, string remarks)
        {  //return msg data initialization   approvid, revisionid, DocOwner,UA.userName);
            DataSet ds = new DataSet();
            try
            {   //Retrieving details
                FlyCnDAL.Users User = new FlyCnDAL.Users(username);
                ApprovelMaster approvelMaster = new ApprovelMaster();
                approvelMaster.RevisionID = revisionid;
                approvelMaster.ApprovalID = approvid;
                approvelMaster.ApprovalStatus = 3;
                approvelMaster.ApprovalDate = System.DateTime.Now;
                approvelMaster.Remarks = remarks;
                approvelMaster.RejectApprovalMaster(approvid, revisionid, DocOwner, username);
                //success message
                DataTable SuccessMsg = new DataTable();
                SuccessMsg.Columns.Add("Flag", typeof(Boolean));
                SuccessMsg.Columns.Add("Message", typeof(String));
                DataRow dr = SuccessMsg.NewRow();
                dr["Flag"] = true;
                dr["Message"] = "Rejected";
                SuccessMsg.Rows.Add(dr);
                ds.Tables.Add(SuccessMsg);
            }
            catch (Exception ex)
            {
                //Return error message
                DataTable ErrorMsg = new DataTable();
                ErrorMsg.Columns.Add("Flag", typeof(Boolean));
                ErrorMsg.Columns.Add("Message", typeof(String));
                DataRow dr = ErrorMsg.NewRow();
                dr["Flag"] = false;
                dr["Message"] = ex.Message;
                ErrorMsg.Rows.Add(dr);
                ds.Tables.Add(ErrorMsg);
            }
            finally
            {
            }
            return getDbDataAsJSON(ds);
        }
        #endregion

        #region ApprovalItemDetails
        [WebMethod]
        public string ApprovalItemDetails(string approvid)
        {  //return msg data initialization   approvid, revisionid, DocOwner,UA.userName);
            DataSet ds = new DataSet();
            try
            {   //Retrieving details
                ApprovelMaster approvelMaster = new ApprovelMaster();
                ds = approvelMaster.GetPendingApprovalsDetailsByApprovalID(approvid);
            }
            catch (Exception ex)
            {
                //Return error message
                DataTable ErrorMsg = new DataTable();
                ErrorMsg.Columns.Add("Flag", typeof(Boolean));
                ErrorMsg.Columns.Add("Message", typeof(String));
                DataRow dr = ErrorMsg.NewRow();
                dr["Flag"] = false;
                dr["Message"] = ex.Message;
                ErrorMsg.Rows.Add(dr);
                ds.Tables.Add(ErrorMsg);
            }
            finally
            {
            }
            return getDbDataAsJSON(ds);
        }
        #endregion
        
        #region LineItems
        [WebMethod]
        public string LineItems(string revid, string type, string projectNo)
        {  //return msg data initialization
            DataSet ds = new DataSet();
            try
            {   //Retrieving details
                ApprovelMaster approvelMaster = new ApprovelMaster();
                DataTable dt = new DataTable();
                dt = approvelMaster.GetDocDetailList(revid, type,projectNo,true);
                ds.Tables.Add(dt);
            }
            catch (Exception ex)
            {
                //Return error message
                DataTable ErrorMsg = new DataTable();
                ErrorMsg.Columns.Add("Flag", typeof(Boolean));
                ErrorMsg.Columns.Add("Message", typeof(String));
                DataRow dr = ErrorMsg.NewRow();
                dr["Flag"] = false;
                dr["Message"] = ex.Message;
                ErrorMsg.Rows.Add(dr);
                ds.Tables.Add(ErrorMsg);
            }
            finally
            {
            }
            return getDbDataAsJSON(ds);
        }
        #endregion

        #region PunchList
        [WebMethod]
        public string PunchList(string username)
        {  //return msg data initialization
            DataSet ds = new DataSet();
            try
            {   //Retrieving details
                FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
                ds.Tables.Add(punchObj.GetPunchList("WEIL"));
            }
            catch (Exception ex)
            {
                //Return error message
                DataTable ErrorMsg = new DataTable();
                ErrorMsg.Columns.Add("Flag", typeof(Boolean));
                ErrorMsg.Columns.Add("Message", typeof(String));
                DataRow dr = ErrorMsg.NewRow();
                dr["Flag"] = false;
                dr["Message"] = ex.Message;
                ErrorMsg.Rows.Add(dr);
                ds.Tables.Add(ErrorMsg);
            }
            finally
            {
            }
            return getDbDataAsJSON(ds);
        }
        #endregion
       
        #region JSON converter and sender
        public String getDbDataAsJSON(DataSet ds)
        {
            try
            {
                DataTable dt = ds.Tables[0];
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;
                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }

                this.Context.Response.ContentType = "";

                return serializer.Serialize(rows);

            }
            catch (Exception)
            {

                return "";
            }
            finally
            {

            }

        }
        public String getDbDataAsJSON(SqlCommand cmd, ArrayList imgColName, ArrayList imgFileNameCol)
        {
            try
            {
                DataSet ds = null;
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = ds.Tables[0];
                String filePath = Server.MapPath("~/tempImages/");      //temporary folder to store images

                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;
                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    //adding data in JSON
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (!imgColName.Contains(col.ColumnName))
                        {
                            if (!imgFileNameCol.Contains(col.ColumnName))
                                row.Add(col.ColumnName, dr[col]);
                        }
                    }
                    //adding image details in JSON
                    for (int i = 0; i < imgColName.Count; i++)
                    {
                        if (dr[imgColName[i] as string] != DBNull.Value)
                        {
                            String fileURL = filePath + DateTime.Now.ToString("ddHHmmssfff") + dr[imgFileNameCol[i] as string];
                            if (!System.IO.File.Exists(fileURL))
                            {
                                byte[] buffer = (byte[])dr[imgColName[i] as string];
                                System.IO.File.WriteAllBytes(fileURL, buffer);
                            }
                            row.Add(imgColName[i] as string, fileURL);
                        }
                    }
                    rows.Add(row);
                }

                this.Context.Response.ContentType = "";

                return serializer.Serialize(rows);

            }
            catch (Exception)
            {

                return "";
            }
            finally
            {

            }
        }
        #endregion JSON converter and sender

    }
}
