using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyCn.UIClasses
{
    public class Const
    {
     //   public string LoginSession = "LoginDetails";
        public string LoginSession {
            get {
                return "LoginDetails";
            }
        }


        public string HomePage
        {
            get
            {
                return "Home.aspx";
            }
        }

        public string Default {
            get
            {
                return "Default.aspx";
            }
        }

        public string HomePageURL
        {
            get
            {
                return "~/Home.aspx";
            }
        }
        public string ApprovalPageURL
        {
            get
            {
                return "Approvals.aspx";
            }

        }
    }

      public static class Messages
      {
          public static string documentclosesuccessMessage
          {
              get { return "Document Successfully Closed"; }
      }

          public static string documentrevisesuccessMessage
          {
              get { return "Document Successfully Revised"; }
          }
          public static string loginSuccessMessage
          {
              get { return "Successfully Logged in"; }
          }
          public static string loginUnsuccessMessage
          {
              get { return "Login Unsuccessfull"; }
          }


          public static string InsertionSuccessfull
          {
              get { return "Inserted Successfully"; }
          }

          public static string UpdationSuccessfull
          {
              get { return "Updated Successfully"; }
          }

          public static string DeletionSuccessfull
          {
              get { return "Deleted Successfully"; }
          }
      }
      
}