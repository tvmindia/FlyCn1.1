using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using FlyCn.FlyCnDAL;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using FlyCn.UIClasses;

namespace FlyCn.WebServices
{
    /// <summary>
    /// Summary description for User
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class User : System.Web.Services.WebService
    {
        #region User Login
        [WebMethod]
        public string UserLogin(string username, string password)
        {
            //return msg data initialization
            DataSet ds = new DataSet();
            DataTable loginMsg = new DataTable();
            loginMsg.Columns.Add("Flag", typeof(Boolean));
            loginMsg.Columns.Add("Message", typeof(String));
            DataRow dr = loginMsg.NewRow();
            try
            {   
                //user credentials checking
                FlyCnDAL.Security.UserAuthendication UA = new FlyCnDAL.Security.UserAuthendication(username,password);
                if (UA.ValidUser)
                {
                    dr["Flag"] = true;
                    dr["Message"] = FlyCn.UIClasses.Messages.loginSuccessMessage ;
                }
                else
                {
                    dr["Flag"] = false;
                    dr["Message"] = FlyCn.UIClasses.Messages.loginUnsuccessMessage;
                }                
            }
            catch (Exception ex)
            {
                dr["Flag"] = false;
                dr["Message"] = ex.Message;                 //exception message to be passed as JSON
            }
            finally
            {
                //returning data
                loginMsg.Rows.Add(dr);
                ds.Tables.Add(loginMsg);
            }
            return getDbDataAsJSON(ds);
        }
        #endregion User Login

        #region User Details
        [WebMethod]
        public string UserDetails(string username)
        {  //return msg data initialization
            DataSet ds = new DataSet();
            DataTable OverView = new DataTable();
            OverView.Columns.Add("Item");
            OverView.Columns.Add("No");
           
            try
            {   //Retrieving user details
                DataRow dr = OverView.NewRow();
                FlyCnDAL.Users User = new FlyCnDAL.Users(username);
                
                //-----------Approval count
                ApprovelMaster approvelMaster = new ApprovelMaster();
                DataSet dataSet = new DataSet();
                dataSet = approvelMaster.GetAllPendingApprovalsByVerifier(User.UserEMail);
                dr["Item"] = "Approvals";
                dr["No"] = dataSet.Tables[0].Rows.Count;
                OverView.Rows.Add(dr);

                //-------------Punchlist count
                FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
                dataSet.Tables.Add(punchObj.GetPunchList());
                dr = OverView.NewRow();
                dr["Item"] = "Punch List";
                dr["No"] = dataSet.Tables[1].Rows.Count;
                OverView.Rows.Add(dr);

                //-----------packing to send
                ds.Tables.Add(OverView);
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
        #endregion User Details

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
