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
        #region Approval Functions----------------------------------------------

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
                dr["Message"] = FlyCn.UIClasses.Messages.ApproveMsgToMobile;
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
                dr["Message"] = FlyCn.UIClasses.Messages.DeclinedMsgToMobile;
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
                dr["Message"] = FlyCn.UIClasses.Messages.RejectedMsgToMobile;
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
            {   
                //Retrieving details
                ApprovelMaster approvelMaster = new ApprovelMaster();
                DataTable dt = new DataTable();
                dt = approvelMaster.GetDocDetailList(revid, type,projectNo,true);

                //Creating a table(with coloumns HeaderID,HeaderTxt,itemsCount,1,2,3,......itemsCount) for sending tables with dynamic no.of.coloumns
                DataTable formattedDT = new DataTable();
                formattedDT.Columns.Add("HeaderID", typeof(string));
                formattedDT.Columns.Add("HeaderTxt", typeof(string));
                formattedDT.Columns.Add("itemsCount", typeof(int));
                for (int i = 1; i <= (dt.Columns.Count-4) ; i++)                  // -4 because HeaderID,HeaderTxt,RevisionID, and ProjectNo are excluded
                {
                    formattedDT.Columns.Add(""+i+"", typeof(string));
                }
                //inserting values to formatted new table
                foreach (DataRow dr in dt.Rows)
                {
                    DataRow formattedDR = formattedDT.NewRow();
                    formattedDR["HeaderID"] =dr["HeaderID"];
                    formattedDR["HeaderTxt"] = dr["HeaderTxt"];
                    formattedDR["itemsCount"] = dt.Columns.Count - 4;
                    int i=1;
                    foreach (DataColumn col in dt.Columns)
                    {
                        if ((col.ColumnName != "HeaderID") && (col.ColumnName != "HeaderTxt") && (col.ColumnName != "RevisionID") && (col.ColumnName != "ProjectNo"))
                        {
                            formattedDR[""+i+""] = col.ColumnName + " : " + dr[col];    //value with coloumn name
                            i++;
                        }
                    }
                    formattedDT.Rows.Add(formattedDR);
                }
                ds.Tables.Add(formattedDT);
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

        #region Approvers
        [WebMethod]
        public string Approvers(string revid)
        {  //return msg data initialization
            DataSet ds = new DataSet();
            try
            {   //Retrieving details
                ApprovelMaster approvelMaster = new ApprovelMaster();
                Guid revisionID = new Guid(revid);
                ds = approvelMaster.GetAllPendingApprovalsByVerifierLevel(revisionID);
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

        #region Notification
        [WebMethod]
        public string Notification(string username, string approvalIDs)
        {  //return msg data initialization
            DataSet dsData = new DataSet();
            DataSet ds = new DataSet();
            try
            {   //Retrieving details
                FlyCnDAL.Users User = new FlyCnDAL.Users(username);
                ApprovelMaster approvelMaster = new ApprovelMaster();
                dsData = approvelMaster.GetAllPendingApprovalsByVerifier(User.UserEMail);
                List<String> approvalIDsList = approvalIDs.Split(',').ToList();
                int count = 0;
                foreach (DataRow dr in dsData.Tables[0].Rows)
                {
                    if (!approvalIDsList.Contains(dr["ApprovalID"].ToString()))
                    {
                        count++;
                    }
                }
                DataTable returnMsg = new DataTable();
                returnMsg.Columns.Add("Flag", typeof(Boolean));
                returnMsg.Columns.Add("Message", typeof(String));
                returnMsg.Columns.Add("Count", typeof(int));
                returnMsg.Columns.Add("Interval", typeof(int));
                DataRow drMsg = returnMsg.NewRow();
                drMsg["Flag"] = true;
                drMsg["Message"] = FlyCn.UIClasses.Messages.NotificationMsgToMobile.Replace("$", count.ToString()).Replace("items", count == 1 ? "item" : "items");
                drMsg["Interval"] = 2;                                               //time inteval to next notification check from client side
                drMsg["Count"] = count;
                returnMsg.Rows.Add(drMsg);
                ds.Tables.Add(returnMsg);
            }
            catch (Exception ex)
            {   //Return error message
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

        #endregion Approval Functions----------------------------------------------

        #region Punchlist Functions

        #region PunchList
        [WebMethod]
        public string PunchList(string username)
        {  //return msg data initialization
            DataSet ds = new DataSet();
            try
            {   //Retrieving details
                FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
                ds.Tables.Add(punchObj.GetPunchList("WEIL"));                   /////////////////to be changed ////////also check actionBy fields
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
        
        #region PunchList Item Details
        [WebMethod]
        public string PunchListItemDetails(string projNO, string ID,string type)
        {   //return msg data initialization
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {   //Retrieving details
                FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
                dt = punchObj.GetPunchListItemDetailsForMobile(projNO, ID, type);

                //Creating a table(with coloumns itemsCount,1,2,3,......itemsCount) for sending tables with dynamic no.of.coloumns
                DataTable formattedDT = new DataTable();
                formattedDT.Columns.Add("itemsCount", typeof(int));
                for (int i = 1; i <= (dt.Columns.Count); i++)
                {
                    formattedDT.Columns.Add("" + i + "", typeof(string));
                }
                //inserting values to formatted new table
                foreach (DataRow dr in dt.Rows)
                {
                    DataRow formattedDR = formattedDT.NewRow();
                    formattedDR["itemsCount"] = dt.Columns.Count;
                    int i = 1;
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.DataType.Name == "DateTime")                //to pick only date of DateTime from DB
                            {
                                DateTime date = DateTime.Parse(dr[col].ToString());
                                formattedDR["" + i + ""] = col.ColumnName + "$$" + date.ToString("dd-MMM-yyyy");
                            }
                        else
                            { 
                            formattedDR["" + i + ""] = col.ColumnName + "$$" + dr[col];             //value with coloumn name
                            }
                        i++;
                    }
                    formattedDT.Rows.Add(formattedDR);
                }
                ds.Tables.Add(formattedDT);
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

        #endregion Punchlist Functions

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
