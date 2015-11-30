using FlyCn.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.FlyCnDAL
{
    
    public class Security
    {

        public string UserName
        {
            get;
            set;
        }
    

        public string PassWord
        {
            get;
            set;
        }

        public string ConfirmPassWord
        {
            get;
            set;
        }

        public string EmailId
        {
            get;
            set;
        }
        public string CreatedBy
        {
            get;
            set;
        }
        public string ContentPage
        {
            get;
            set;
        }
        public class PageSecurity
        {
            public bool isRead;
            public bool isWrite;
            public bool isDelete;
            public string isExecute;
            public bool isEdit;
            public bool isAdd;
            public bool isDenied;



            Boolean Read
            {
                get
                {
                    return isRead;
                }

            }
            Boolean Denied
            {
                get
                {
                    return isDenied;
                }
            }
            Boolean Add
            {
                get
                {
                    return isAdd;
                }
            }
            Boolean Edit
            {
                get
                {
                    return isEdit;
                }
            }
            Boolean Write
            {
                get
                {
                    return isWrite;
                }

            }
            Boolean Delete
            {
                get
                {
                    return isDelete;
                }

            }
            string Execute
            {
                get
                {
                    return isExecute;
                }

            }
            Boolean ReadOnly
            {
                get
                {

                    if (Read && (!Delete && !Write))
                    {
                        ReadOnly = true;
                    }

                    return ReadOnly;
                }
                set
                {
                    ReadOnly = value;
                }
            }
            
            public PageSecurity(string pageName, Page objPage)
            {
      

              var  MasterValue = objPage.Master;
              ContentPlaceHolder mpContentPlaceHolder1; 
              mpContentPlaceHolder1 = (ContentPlaceHolder)MasterValue.FindControl("ContentPlaceHolder1");
              var hdnSecurityField = (HiddenField)MasterValue.FindControl("hdnSecurityMaster");
          //    var hdnSecuritySubpage = (HiddenField)mpContentPlaceHolder1.FindControl("hdnSecurity");
              UIClasses.Const Const = new UIClasses.Const();
              FlyCnDAL.Security.UserAuthendication UA;
              var page = HttpContext.Current.CurrentHandler as Page;
              HttpContext context = HttpContext.Current;
              UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
              string usrname = UA.userName;
              Security sObj = new Security();
              string result;
              
     
              result = sObj.LoginSecurityCheck(usrname);
         
                 
                      
                hdnSecurityField.Value = result;
                if (result.Contains("w"))
                    isWrite = true;
                else 
                    if (result.Contains("e"))
                  isEdit = true;
              else 
                        if (result.Contains("a"))
                  isAdd = true;
              else 
                            if (result.Contains("r"))
                  isRead = true;
              else
                                if (result.Contains(""))
                  isDenied = true;
                if(result.Contains("d"))
                isDelete=true;
           
                //will be changed to db date based n page soon
                //if (userName == "User3")
                //{
                //    isRead = true;
                //    isWrite = false;
                //    isDelete = false;
                //    isExecute = "";
                //}
                //else
                //{

                //    isRead = true;
                //    isWrite = true;
                //    isDelete = true;
                //    isExecute = "X";
                //}
            
            }

        }
        public class UserAuthendication
        {

            public UserAuthendication(String userName, String password)
            {

                if (userName == password)
                {
                    isValidUser = true;
                    userN = userName;
                    project = "C00001";
                    GetUserDetails();
                }
                else
                {

                    isValidUser = false;
                }
            }


            public UserAuthendication(String userName, int specialAccessCode)
            {
                isValidUser = true;
                userN = userName;
                project = "C00001";
                GetUserDetails();
            }

            FlyCnDAL.DALConstants Constants = new FlyCnDAL.DALConstants();
            private Boolean isValidUser;
            private string userN;
            private string project;

            public Boolean ValidUser
            {
                get
                {

                    return isValidUser;
                }

            }
            public string userName
            {

                get
                {
                    return userN;
                }
            }
            public string projectNo
            {

                get
                {
                    return project;
                }
            }

            public string theme
            {
                get;
                set;
            }


            private void GetUserDetails()
            {
                try
                {
                    DataTable dt = new DataTable();
                    SqlConnection con = null;
                    SqlDataAdapter daObj;

                    dbConnection dcon = new dbConnection();
                    con = dcon.GetDBConnection();
                    SqlCommand cmdSelect = new SqlCommand("GetUserDetails", con);
                    cmdSelect.CommandType = CommandType.StoredProcedure;
                    cmdSelect.Parameters.AddWithValue("@UserName", userName);

                    daObj = new SqlDataAdapter(cmdSelect);
                    daObj.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["theme"] == null || dt.Rows[0]["theme"].ToString() == "")
                        {
                            theme = Constants.DefaultTheme;
                        }
                        else
                        {
                            theme = dt.Rows[0]["theme"].ToString();
                        }

                    }
                    else
                    {
                        theme = Constants.DefaultTheme;
                    }


                }
                catch (Exception)
                {
                    theme = Constants.DefaultTheme;
                }
            }



        }

        public int InsertUser()
        {
            ErrorHandling eObj = new ErrorHandling();

            SqlConnection con = null;
            try
            {
                DataSet dataset = new DataSet();

                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertMasterUsers";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@PassWord", PassWord);
                cmd.Parameters.AddWithValue("@ConfirmPassword", ConfirmPassWord);
                cmd.Parameters.AddWithValue("@EmailId", EmailId);
                cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                cmd.ExecuteScalar();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.InsertionSuccessData(page);
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



        public DataTable GetUser()
        {
            ErrorHandling eObj = new ErrorHandling()   ;
            SqlConnection con = null;
            DataTable dt = null;
            try
            {


                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();


                SqlCommand cmd = new SqlCommand("GetUser", con);
                cmd.CommandType = CommandType.StoredProcedure;




                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                dt = new DataTable();
                adapter.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;


            }
            finally
            {
                con.Close();

            }
        }

        public int DeleteUser(string Username, string PassWord)
        {
            ErrorHandling eObj = new ErrorHandling();
            SqlConnection conObj = null;
            try
            {
                dbConnection dcon = new dbConnection();
                conObj = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("DeleteUser", conObj);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", Username);
                cmd.Parameters.AddWithValue("@PassWord", PassWord);
                cmd.ExecuteScalar();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.DeleteSuccessData(page);
                return 1;
            }
            catch (SqlException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
            finally
            {
                conObj.Close();
            }
            return 0;
        }
        public string LoginSecurityCheck(string username)
           {

               if (username == "gopika" )
            //   || username == "amrutha" || username == "albert" || username == "anija")

                   return "rdew";
            else
            if (username == "amrutha")
               return "w";
            else
            if (username == "albert")
               return "rd"; 
            else
            if(username=="anija")
           {
                return "e";
            }
            else
            if (username == "aa")
            {
                return "r";
            }


               return "";
        }

        public void ReadOnly(ToolBar pagecontrols)
        {
            //DisableAllControls(pagecontrols);

            pagecontrols.AddButton.Visible = false;
            pagecontrols.EditButton.Visible = false;
            pagecontrols.DeclineButton.Visible = false;
            pagecontrols.DeleteButton.Visible = false;
            pagecontrols.ApproveButton.Visible = false;
            pagecontrols.RejectButton.Visible = false;
            pagecontrols.SaveButton.Visible = false;
     

        }
        public void AddEditOnly(ToolBar pagecontrols)
        {
            DisableAllControls(pagecontrols);
            pagecontrols.EditButton.Visible = true;
            pagecontrols.AddButton.Visible = true; 
            pagecontrols.SaveButton.Visible = true;
            pagecontrols.Visible = true;
                     
        }
        public void DisableAllControls(ToolBar pagecontrols)
        {

            pagecontrols.AddButton.Visible = false;
            pagecontrols.EditButton.Visible = false;
            pagecontrols.DeclineButton.Visible = false;
            pagecontrols.DeleteButton.Visible = false;
            pagecontrols.ApproveButton.Visible = false;
            pagecontrols.RejectButton.Visible = false;
            pagecontrols.SaveButton.Visible = false;

            //foreach (Control c in pagecontrols.Controls)
            //{

            //    c.Visible = false;
            //}

            //foreach (object o in pagecontrols)
            //{
            //    Control control = o as Control;
            //    if (control != null)
            //    {
            //        control.IsEnabled = false;
            //    }
            //}
            //    Control contrl = new Control();

            //    foreach (Control c in contrl.Controls)
            //    {

            //        if (c is TextBox)

            //            ((TextBox)c).Enabled = false;

            //        else if (c is Button)

            //            ((Button)c).Enabled = false;

            //        else if (c is RadioButton)

            //            ((RadioButton)c).Enabled = false;

            //        else if (c is ImageButton)

            //            ((ImageButton)c).Enabled = false;

            //        else if (c is CheckBox)

            //            ((CheckBox)c).Enabled = false;

            //        else if (c is DropDownList)

            //            ((DropDownList)c).Enabled = false;

            //        else if (c is HyperLink)

            //            ((HyperLink)c).Enabled = false;

            //        else if (c is UserControl)
            //        {

            //            //foreach (object o in toolbar. )
            //            //{
            //            //    Control control = o as Control;
            //            //    if (control != null)
            //            //    {
            //            //        control.IsEnabled = false;
            //            //    }
            //            //}
            //            ((UserControl)c).EnableViewState= false;
            //        }
            //        if (c is TreeView)
            //        {
            //            ((TreeView)c).Enabled = false;
            //        }
        }
    }
}
        
      


    

