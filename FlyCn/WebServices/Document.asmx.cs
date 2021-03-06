﻿using FlyCn.FlyCnDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following  line. 
    [System.Web.Script.Services.ScriptService]
    public class Document : System.Web.Services.WebService
    {
        #region Approval Functions----------------------------------------------
       
        #region Approvals
        /// <summary>
        /// To get approval list
        /// </summary>
        /// <param name="username">User Name</param>
        /// <returns>JSON of list of approval items for the current user</returns>
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
        /// <summary>
        /// To approve a specific item
        /// </summary>
        /// <param name="username">User Name</param>
        /// <param name="approvid">Approval ID</param>
        /// <param name="revisionid">Revision ID</param>
        /// <param name="DocOwner">Document Owner</param>
        /// <param name="remarks">Remarks which can be empty</param>
        /// <returns>Message of pass or fail</returns>
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
        /// <summary>
        /// Decline a specific item from aproval list
        /// </summary>
        /// <param name="username">User Name</param>
        /// <param name="approvid">Approval ID</param>
        /// <param name="revisionid">Revision ID</param>
        /// <param name="DocOwner">Document Owner</param>
        /// <param name="remarks">Mandatory remarks</param>
        /// <returns>Message regarding this operation passed or failed</returns>
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
        /// <summary>
        /// TO reject an approval item
        /// </summary>
        /// <param name="username">User Name</param>
        /// <param name="approvid">Approval ID</param>
        /// <param name="revisionid">Revision ID</param>
        /// <param name="DocOwner">Document Owner</param>
        /// <param name="remarks">Mandatory Remarks</param>
        /// <returns>Message regarding this operation passed or failed</returns>
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
        /// <summary>
        /// To get any approval item's details
        /// </summary>
        /// <param name="approvid">Approval ID</param>
        /// <returns>JSON of item's details</returns>
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
        /// <summary>
        /// to get Lineitems of any approval item
        /// </summary>
        /// <param name="revid">revision ID</param>
        /// <param name="type">Document type</param>
        /// <param name="projectNo">Project number</param>
        /// <returns>JSON of lineitem's details with dynamic columns</returns>
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
        /// <summary>
        /// To get list of approvers for an approval item
        /// </summary>
        /// <param name="revid">Revision ID</param>
        /// <returns>JSON of list of approvers</returns>
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
        /// <summary>
        /// Webservice to give notification of new approval items
        /// </summary>
        /// <param name="username">user name</param>
        /// <param name="approvalIDs">list of approval IDs already known by the device, seperated by commas</param>
        /// <returns>Message with no.of.new approvals' count</returns>
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

        #region Punchlist Functions----------------------------------------------

        #region PunchList
        /// <summary>
        /// Get punchlist
        /// </summary>
        /// <param name="username">User Name</param>
        /// <returns>JSON of list of punchlist in which the user have to take action(ActionBy)</returns>
        [WebMethod]
        public string PunchList(string username)
        {  //return msg data initialization
            DataSet ds = new DataSet();
            try
            {   //Retrieving details
                FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
               // ds.Tables.Add(punchObj.GetPunchList());                   /////////////////to be changed ////////also check actionBy fields
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
        /// <summary>
        /// Retireving details about any punch item
        /// </summary>
        /// <param name="projNO"></param>
        /// <param name="ID">EIL ID</param>
        /// <param name="type">WEIL/CEIL/QEIL</param>
        /// <returns>Punch item Details</returns>
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
                        if (col.DataType.Name == "DateTime" && dr[col]!= DBNull.Value)                //to pick only date of DateTime from DB
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

        #region Punch Item Get Attatchment List
        /// <summary>
        /// Webservice to return list of attachment images of an punchlist item
        /// </summary>
        /// <param name="projNo">Project Number</param>
        /// <param name="punchID">EIL ID</param>
        /// <param name="EILtype">WEIL/CEIL/QEIL</param>
        /// <param name="isThumb">optional parameter to denote whether thumbanail images are enough</param>
        /// <returns>JSON of details of attachment images</returns>
        [WebMethod]
        public string PunchItemGetAttatchmentList(string projNo, string punchID, string EILtype)
        {
            //return msg data initialization
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {   //Retrieving details
                FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
                dt = punchObj.GetPunchListItemAttachments(projNo, punchID, EILtype);
                ds.Tables.Add(dt);
                //Giving coloumns of image details
                ArrayList imgColNames = new ArrayList();
                ArrayList imgFileNameCols = new ArrayList();
                ArrayList imgFileTypeCols = new ArrayList();
                imgColNames.Add("Image");
                imgFileNameCols.Add("AttachmentName");
                imgFileTypeCols.Add("FileType");

                return getDbDataAsJSON(ds, imgColNames, imgFileNameCols, imgFileTypeCols,true);
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
                return getDbDataAsJSON(ds);
            }
            finally
            {                
            }
        }
        #endregion Punch Item Get Attatchment List

        #region Punch Item Get Attatchment item
        /// <summary>
        /// Webservice to return list of attachment images of an punchlist item
        /// </summary>
        /// <param name="projNo">Project Number</param>
        /// <param name="punchID">EIL ID</param>
        /// <param name="EILtype">WEIL/CEIL/QEIL</param>
        /// <param name="isThumb">optional parameter to denote whether thumbanail images are enough</param>
        /// <returns>JSON of details of attachment images</returns>
        [WebMethod]
        public string PunchItemGetAttatchmentItem(string attachmentID)
        {
            //return msg data initialization
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            Guid attachid = new Guid(attachmentID);
            try
            {   //Retrieving details
                FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
                SqlDataReader reader = punchObj.MakeFile(attachid);

                dt.Load(reader);
                ds.Tables.Add(dt);

                //Giving coloumns of image details
                ArrayList imgColNames = new ArrayList();
                ArrayList imgFileNameCols = new ArrayList();
                ArrayList imgFileTypeCols = new ArrayList();
                imgColNames.Add("Image");
                imgFileNameCols.Add("AttachmentName");
                imgFileTypeCols.Add("FileType");

                return getDbDataAsJSON(ds, imgColNames, imgFileNameCols, imgFileTypeCols, false);
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
                return getDbDataAsJSON(ds);
            }
            finally
            {
            }
        }
        #endregion Punch Item Get Attatchment item
        
        #region Punch Item Add Attatchment
        /// <summary>
        /// Webservice to get new attachment file from mobile
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string PunchItemAddAttatchment()
        {
            try
            {
                HttpFileCollection MyFileCollection = HttpContext.Current.Request.Files;
                //Getting file dettails from http request
                if (MyFileCollection.Count > 0)
                {
//               string FilePath = Server.MapPath("~/tempImages/")+DateTime.Now.ToString("ddHHmmssfff")+MyFileCollection[0].FileName;
//               MyFileCollection[0].SaveAs(FilePath); //to save coming image to server folder
                Stream MyStream = MyFileCollection[0].InputStream;
                PunchList punchObj = new PunchList();
                
                punchObj.image = MyStream;
                MyStream.Flush();
                
                punchObj.FileType = "." + MyFileCollection[0].FileName.Split('.').Last();
                punchObj.fileUpload = MyFileCollection[0].FileName;
                
                if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["punchID"]))
                {
                    punchObj.id = int.Parse(HttpContext.Current.Request.Form["punchID"]);
                }
                if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["EILType"]))
                {
                    punchObj.EILType = HttpContext.Current.Request.Form["EILType"];
                }
                
                float Size = MyFileCollection[0].ContentLength/1024;
                float sizeinMB = Size / 1024;
                string fileSize;
                if ((int)sizeinMB == 0)
                {
                     fileSize = Size + "KB";
                }
                else
                {
                    fileSize = sizeinMB.ToString("0.00") + "MB";
                }
                
                punchObj.fileSize = fileSize;
                string userName="";string projNo="";
                if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["userName"]))
                { 
                    userName=HttpContext.Current.Request.Form["userName"];
                }
                if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["projNo"]))
                {
                    projNo = HttpContext.Current.Request.Form["projNo"];
                }

                punchObj.InsertEILAttachment(true,userName,projNo);

                }

                return "Message:"+FlyCn.UIClasses.Messages.SuccessfulUpload;
            }
            catch (Exception ex)
            {
                return "Message:" + ex.Message;
            }
            finally
            {
            }
        }
        #endregion Punch Item Add Attatchment
        
        #endregion Punchlist Functions----------------------------------------------

        #region JSON converter and sender
        /// <summary>
        /// JSON function without returning any images
        /// </summary>
        /// <param name="ds">Dataset</param>
        /// <returns>ds in JSON format</returns>
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
            catch (Exception ex)
            {
                //Return error message
                DataSet dserror = new DataSet();
                DataTable ErrorMsg = new DataTable();
                ErrorMsg.Columns.Add("Flag", typeof(Boolean));
                ErrorMsg.Columns.Add("Message", typeof(String));
                DataRow dr = ErrorMsg.NewRow();
                dr["Flag"] = false;
                dr["Message"] = ex.Message;
                ErrorMsg.Rows.Add(dr);
                ds.Tables.Add(ErrorMsg);
                return getDbDataAsJSON(dserror); ;
            }
            finally
            {

            }

        }
        /// <summary>
        /// JSON function with returning any images
        /// </summary>
        /// <param name="ds">Dataset</param>
        /// <param name="imgColName">Coloumn names array that contains images(data)</param>
        /// <param name="imgFileNameCol">Coloumn names array that contain file name</param>
        /// <param name="imgFileTypeCol">Coloumn names array that contain file type</param>
        /// <param name="isThumb">Optional parameter to say whether the thumbnail is enough for calling function</param>
        /// <returns>ds in JSON format with links to images that are temporarly stored in server folder</returns>
        public String getDbDataAsJSON(DataSet ds, ArrayList imgColName, ArrayList imgFileNameCol, ArrayList imgFileTypeCol,Boolean isThumb=false)
        {
            try
            {
                DataTable dt = ds.Tables[0];
                String filePath = Server.MapPath("~/tempImages/");      

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
                           row.Add(col.ColumnName, dr[col]);
                        }
                    }
                    //adding image details in JSON
                    for (int i = 0; i < imgColName.Count; i++)
                    {
                       
                                        if (dr[imgColName[i] as string] != DBNull.Value)
                                        {
                                            String fileURL = filePath + DateTime.Now.ToString("ddHHmmssfff") + dr[imgFileNameCol[i] as string].ToString().Replace(" ","_");
                                            if (!System.IO.File.Exists(fileURL))
                                            {
                                                byte[] buffer;
                                                if (isThumb)
                                                { switch(dr[imgFileTypeCol[i] as string].ToString())  //checking whether image file
                                                        {
                                                            case ".bmp":
                                                            case ".gif":
                                                            case ".png":
                                                            case ".jpg":
                                                            case ".jpeg": //imageFile confirmed
                                                                         buffer = MakeThumbnail((byte[])dr[imgColName[i] as string], 90, 90);//images are converted to thumbnails of 90*90px
                                                                         System.IO.File.WriteAllBytes(fileURL, buffer);
                                                                                    break;
                                                            default: //non-image file confirmed
                                                                //buffer = (byte[])dr[imgColName[i] as string];
                                                                                    break;
                                                        }
                                                }
                                                else
                                                {
                                                    buffer = (byte[])dr[imgColName[i] as string];
                                                    System.IO.File.WriteAllBytes(fileURL, buffer);
                                                }
                                            }
                                            row.Add(imgColName[i] as string, fileURL);
                                        }
                                        
                    }
                    rows.Add(row);
                }

                this.Context.Response.ContentType = "";

                return serializer.Serialize(rows);

            }
            catch (Exception ex)
            {
                //Return error message
                DataSet dsError = new DataSet();
                DataTable ErrorMsg = new DataTable();
                ErrorMsg.Columns.Add("Flag", typeof(Boolean));
                ErrorMsg.Columns.Add("Message", typeof(String));
                DataRow dr = ErrorMsg.NewRow();
                dr["Flag"] = false;
                dr["Message"] = ex.Message;
                ErrorMsg.Rows.Add(dr);
                dsError.Tables.Add(ErrorMsg);
                return getDbDataAsJSON(dsError);
            }
            finally
            {

            }
        }
        #endregion JSON converter and sender
     
        #region Utility Functions
        //----------------------------Function to make image thumbnail---------------------------------------------------
        public static byte[] MakeThumbnail(byte[] myImage, int thumbWidth, int thumbHeight)
        {
            using (MemoryStream ms = new MemoryStream())
            using (Image thumbnail = Image.FromStream(new MemoryStream(myImage)).GetThumbnailImage(thumbWidth, thumbHeight, null, new IntPtr()))
            {
                thumbnail.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        #endregion Utility Functions

    }
}
